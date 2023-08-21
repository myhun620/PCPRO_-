using MMCWHPNET;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPRO_실기
{
    public class Servo : Actuator, IMotorTeach, IMotorConfig
    {
        bool svrEnable;
        short vel;
        double cmdPos, actPos, errPos, encoder;
        bool pLimit, home, nLimit;

        short accJog, accInch, accOrg, accPos;
        short decJog, decInch, decOrg, decPos;
        double velJog, velInch, velOrg1, velOrg2, velOrg3, velPos;
        short accTempOrg;
        double velTempOrg;

        RptMsg rptZr;
        Step stepZr;
        PLC plc;

        #region Property
        public bool SvrEnable { get => svrEnable; }
        public double CmdPos { get => cmdPos; }
        public double ActPos { get => actPos; }
        public double ErrPos { get => errPos; }
        public double Encoder { get => encoder; }
        public short Vel { get => vel; }
        public bool PLimit { get => pLimit; }
        public bool Home { get => home; }
        public bool NLimit { get => nLimit; }
        public short AccJog { get => accJog; set => accJog = value; }
        public short AccInch { get => accInch; set => accInch = value; }
        public short AccOrg { get => accOrg; set => accOrg = value; }
        public short AccPos { get => accPos; set => accPos = value; }
        public short DecJog { get => decJog; set => decJog = value; }
        public short DecInch { get => decInch; set => decInch = value; }
        public short DecOrg { get => decOrg; set => decOrg = value; }
        public short DecPos { get => decPos; set => decPos = value; }
        public double VelJog { get => velJog; set => velJog = value; }
        public double VelInch { get => velInch; set => velInch = value; }
        public double VelOrg1 { get => velOrg1; set => velOrg1 = value; }
        public double VelOrg2 { get => velOrg2; set => velOrg2 = value; }
        public double VelOrg3 { get => velOrg3; set => velOrg3 = value; }
        public double VelPos { get => velPos; set => velPos = value; }
        #endregion

        public Servo(short axNo, PLC moudule1PLC) : base(axNo)
        {
            this.plc = moudule1PLC;
            svrEnable = false;
            vel = 0;
            cmdPos = 0;
            actPos = 0;
            errPos = 0;
            encoder = 0;
            pLimit = false;
            home = false;
            nLimit = false;
            accJog = 100; accInch = 10; accOrg = 10; accPos = 10;
            decJog = 100; decInch = 10; decOrg = 10; decPos = 10;
            velJog = 2000; velInch = 2000; velOrg1 = 2000; velOrg2 = 5000; velOrg3 = 2000; velPos = 2000;
            rptZr = RptMsg.READY;
            stepZr = Step.STEP00;
            accTempOrg = 0;
            velTempOrg = 0;
        }
        public void ServoOn()
        {
            MMCLib.set_amp_enable(AxNo, 1);
        }
        public void ServoOff()
        {
            MMCLib.set_amp_enable(AxNo, 0);
        }
        public void Clear()
        {
            MMCLib.clear_status(AxNo);
            MMCLib.set_position(AxNo, 0);
            MMCLib.frames_clear(AxNo);
        }
        public void Stop()
        {
            MMCLib.set_stop(AxNo);
            MMCLib.mmcDelay(100);
            MMCLib.clear_status(AxNo);
        }
        public void Reset()
        {
            MMCLib.amp_fault_reset(AxNo);
            MMCLib.mmcDelay(100);
            MMCLib.amp_fault_set(AxNo);
        }
        public void GetSvrInfo()
        {
            short state = 0;
            MMCLib.get_amp_enable(AxNo, ref state);
            svrEnable = state == 1 ? true : false;
        }
        public void GetLimitInfo()
        {
            short source = MMCLib.axis_source(AxNo);
            home = (source & (1 << 0)) != 0 ? true : false;
            pLimit = (source & (1 << 1)) != 0 ? true : false;
            nLimit = (source & (1 << 2)) != 0 ? true : false;
        }
        public void GetPosInfo()
        {
            MMCLib.get_position(AxNo, ref encoder);
            MMCLib.get_command(AxNo, ref cmdPos);
            MMCLib.get_error(AxNo, ref errPos);
            vel = MMCLib.get_velocity(AxNo);
            MMCLib.get_counter(AxNo, ref actPos);
        }
        public void JogMove(Dir dir)
        {
            switch (dir)
            {
                case Dir.FWD:
                case Dir.RIGHT:
                case Dir.DOWN:
                    MMCLib.v_move(AxNo, VelJog, AccJog);
                    break;
                case Dir.BWD:
                case Dir.LEFT:
                case Dir.UP:
                    MMCLib.v_move(AxNo, -VelJog, AccJog);
                    break;
            }
        }
        public void JogStop()
        {
            MMCLib.v_move_stop(AxNo);
        }
        public void InchingMove(double dist)
        {
            MMCLib.r_move(AxNo, dist * sym.GearRatio, VelInch, AccInch);
        }
        public RptMsg ZeroReturn(CmdMsg cmd)
        {
            switch (stepZr)
            {
                case Step.STEP00:
                    if (cmd == CmdMsg.START)
                    {
                        rptZr = RptMsg.BUSY;
                        velTempOrg = velJog;
                        accTempOrg = accJog;
                        velJog = VelOrg1;
                        accJog = accOrg;
                        stepZr = Step.STEP01;
                    }
                    break;
                case Step.STEP01:
                    if (AxNo == 2)
                    {
                        JogMove(Dir.FWD);
                        stepZr = Step.STEP02;
                    }
                    else if (AxNo == 3)
                    {
                        JogMove(Dir.FWD);
                        stepZr = Step.STEP02;
                    }
                    break;
                case Step.STEP02:
                    if (AxNo == 2 && plc.cartridgeXAxisHome == 1)   // 2 : X
                    {
                        JogStop();
                        stepZr = Step.STEP03;
                    }
                    if (AxNo == 3 && plc.cartridgeZAxisHome == 1)   // 3 : Z
                    {
                        JogStop();
                        stepZr = Step.STEP03;
                    }
                    break;
                case Step.STEP03:
                    if (MMCLib.axis_done(AxNo) == 1)
                    {
                        velJog = velOrg2;
                        stepZr = Step.STEP04;
                    }
                    break;
                case Step.STEP04:
                    if (AxNo == 2)
                    {
                        JogMove(Dir.BWD);
                        stepZr = Step.STEP05;
                    }
                    else if (AxNo == 3)
                    {
                        JogMove(Dir.BWD);
                        stepZr = Step.STEP05;
                    }
                    break;
                case Step.STEP05:
                    if (AxNo == 2 && plc.cartridgeXAxisHome == 0)
                    {
                        JogStop();
                        stepZr = Step.STEP06;
                    }
                    if (AxNo == 3 && plc.cartridgeZAxisHome == 0)
                    {
                        JogStop();
                        stepZr = Step.STEP06;
                    }
                    break;
                case Step.STEP06:
                    if (MMCLib.axis_done(AxNo) == 1)
                    {
                        velJog = velOrg3;
                        stepZr = Step.STEP07;
                    }
                    break;
                case Step.STEP07:
                    if (AxNo == 2)
                    {
                        JogMove(Dir.FWD);
                        stepZr = Step.STEP08;
                    }
                    else if (AxNo == 3)
                    {
                        JogMove(Dir.FWD);
                        stepZr = Step.STEP08;
                    }
                    break;
                case Step.STEP08:
                    if (AxNo == 2 && plc.cartridgeXAxisHome == 1)
                    {
                        JogStop();
                        stepZr = Step.STEP09;
                    }
                    if (AxNo == 3 && plc.cartridgeZAxisHome == 1)
                    {
                        JogStop();
                        stepZr = Step.STEP09;
                    }
                    break;
                case Step.STEP09:
                    if (MMCLib.axis_done(AxNo) == 1)
                    {
                        velJog = velTempOrg;
                        AccJog = accTempOrg;
                        Clear();
                        stepZr = Step.STEP100;
                    }
                    break;
                case Step.STEP100:
                    rptZr = RptMsg.COMPLETE;
                    stepZr = Step.STEP101;
                    break;
                case Step.STEP101:
                    if (cmd == CmdMsg.END)
                    {
                        rptZr = RptMsg.READY;
                        stepZr = Step.STEP00;
                    }
                    break;
            }

            return rptZr;
        }
        public void SaveConfig()
        {
            FileStream fs = new FileStream($"Config_{AxNo}.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine($"AccJog:{AccJog}");
            sw.WriteLine($"AccInch:{AccInch}");
            sw.WriteLine($"AccOrg:{AccOrg}");
            sw.WriteLine($"AccPos:{AccPos}");
            sw.WriteLine($"DecJog:{DecJog}");
            sw.WriteLine($"DecInch:{DecInch}");
            sw.WriteLine($"DecOrg:{DecOrg}");
            sw.WriteLine($"DecPos:{DecPos}");
            sw.WriteLine($"VelJog:{VelJog}");
            sw.WriteLine($"VelInch:{VelInch}");
            sw.WriteLine($"VelOrg1:{VelOrg1}");
            sw.WriteLine($"VelOrg2:{VelOrg2}");
            sw.WriteLine($"VelOrg3:{VelOrg3}");
            sw.WriteLine($"VelPos:{VelPos}");

            sw.Close();
            fs.Close();
        }
        public void LoadConfig()
        {
            FileStream fs = new FileStream($"Config_{AxNo}.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            while (!sr.EndOfStream)
            {
                string str = sr.ReadLine();
                string[] temp = str.Split(':');

                switch (temp[0])
                {

                    case "AccJog":
                        AccJog = Convert.ToInt16(temp[1]);
                        break;

                    case "AccInch":
                        AccInch = Convert.ToInt16(temp[1]);
                        break;

                    case "AccOrg":
                        AccOrg = Convert.ToInt16(temp[1]);
                        break;

                    case "AccPos":
                        AccPos = Convert.ToInt16(temp[1]);
                        break;

                    case "DecJog":
                        DecJog = Convert.ToInt16(temp[1]);
                        break;

                    case "DecInch":
                        DecInch = Convert.ToInt16(temp[1]);
                        break;

                    case "DecOrg":
                        DecOrg = Convert.ToInt16(temp[1]);
                        break;

                    case "DecPos":
                        DecPos = Convert.ToInt16(temp[1]);
                        break;

                    case "VelJog":
                        VelJog = Convert.ToDouble(temp[1]);
                        break;

                    case "VelInch":
                        VelInch = Convert.ToDouble(temp[1]);
                        break;

                    case "VelOrg1":
                        VelOrg1 = Convert.ToDouble(temp[1]);
                        break;

                    case "VelOrg2":
                        VelOrg2 = Convert.ToDouble(temp[1]);
                        break;

                    case "VelOrg3":
                        VelOrg3 = Convert.ToDouble(temp[1]);
                        break;

                    case "VelPos":
                        VelPos = Convert.ToDouble(temp[1]);
                        break;

                }
            }

            sr.Close();
            fs.Close();
        }
    }

}

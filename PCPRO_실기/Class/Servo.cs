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

        short accJog, accOrg, accPos;
        double velJog, velOrg1, velOrg2, velOrg3, velPos;
        short accTempOrg;
        double velTempOrg;

        RptMsg rptZr;
        Step stepZr;
        PLC plc;

        #region Property
        public bool SvrEnable { get => svrEnable; }
        public short AccJog { get => accJog; set => accJog = value; }
        public short AccPos { get => accPos; set => accPos = value; }
        public double VelJog { get => velJog; set => velJog = value; }
        public double VelOrg1 { get => velOrg1; set => velOrg1 = value; }
        public double VelPos { get => velPos; set => velPos = value; }
        #endregion

        public Servo(short axNo, PLC moudule1PLC) : base(axNo)
        {
            this.plc = moudule1PLC;
            svrEnable = false;
            accJog = 100; accOrg = 10; accPos = 10;
            velJog = 2000; velOrg1 = 2000; velOrg2 = 5000; velOrg3 = 2000; velPos = 2000;
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
        public void GetSvrInfo()
        {
            short state = 0;
            MMCLib.get_amp_enable(AxNo, ref state);
            svrEnable = state == 1 ? true : false;
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
                    if (AxNo == 2 && plc._plc1DeviceX[(int)Module1X.cartridgeXAxisHome])   // 2 : X
                    {
                        JogStop();
                        stepZr = Step.STEP03;
                    }
                    if (AxNo == 3 && plc._plc1DeviceX[(int)Module1X.cartridgeZAxisHome])   // 3 : Z
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
                    if (AxNo == 2 && plc._plc1DeviceX[(int)Module1X.cartridgeXAxisHome])
                    {
                        JogStop();
                        stepZr = Step.STEP06;
                    }
                    if (AxNo == 3 && plc._plc1DeviceX[(int)Module1X.cartridgeZAxisHome])
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
                    if (AxNo == 2 && plc._plc1DeviceX[(int)Module1X.cartridgeXAxisHome])
                    {
                        JogStop();
                        stepZr = Step.STEP09;
                    }
                    if (AxNo == 3 && plc._plc1DeviceX[(int)Module1X.cartridgeZAxisHome])
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
    }

}

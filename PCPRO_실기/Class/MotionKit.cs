using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MMCWHPNET;

namespace PCPRO_실기
{
    public class MotionKit : IMotionTeach
    {
        public string str;

        Servo[] axes;
        DIO dio;
        Cylinder gripper;

        RptMsg[] rptZr;
        CmdMsg[] cmdZr;
        RptMsg rptOrg;
        Step stepOrg;

        bool orgDone;

        Point[] posXY;
        double[] posZ;

        RptMsg rptPnp;
        Step stepPnp;

        RptMsg rptInit;
        Step stepInit;

        PLC module1PLC;

        #region Property

        public Servo[] Axes { get => axes; }
        public bool OrgDone { get => orgDone; }
        public Point[] PosXY { get => posXY; set => posXY = value; }
        public double[] PosZ { get => posZ; set => posZ = value; }
        public DIO Dio { get => dio; }
        public Cylinder Gripper { get => gripper; }

        public Servo this[int idx]
        {
            get { return axes[idx]; }
        }
        #endregion

        public MotionKit(PLC module1PLC)
        {
            this.module1PLC = module1PLC;

            axes = new Servo[2];
            axes[0] = new Servo(2, module1PLC);     // X축
            axes[1] = new Servo(3, module1PLC);     // Z축
            dio = new DIO();
            gripper = new Cylinder(3, dio);
            rptZr = new RptMsg[3];
            cmdZr = new CmdMsg[3] { CmdMsg.CHECK, CmdMsg.CHECK, CmdMsg.CHECK };
            rptOrg = RptMsg.READY;
            stepOrg = Step.STEP00;
            orgDone = false;
            posXY = new Point[25];
            for (int i = 0; i < 25; i++)
            {
                posXY[i].X = 0;
                posXY[i].Y = 0;
            }
            XYPositionInit();
            stepPnp = Step.STEP00;
            stepInit = Step.STEP00;
        }

        private void XYPositionInit()
        {
            int startPosX = -39302;
            int startPosY = -2100;
            int offsetPosX = -10219;
            int offsetPosY = -12053;

            for (int i = 0; i < 25; i++)
            {
                if (i == 0) // 1열
                {
                    PosXY[0].X = startPosX;
                    PosXY[0].Y = startPosY;
                }
                else if (i / 5 == 0)
                {
                    PosXY[i].X = PosXY[i - 1].X - offsetPosX;
                    PosXY[i].Y = PosXY[i - 1].Y;
                }
                else if (i == 5)    // 2열
                {
                    PosXY[i].X = startPosX;
                    PosXY[i].Y = PosXY[i - 1].Y + offsetPosY;
                }
                else if (i / 5 == 1)
                {
                    PosXY[i].X = PosXY[i - 1].X - offsetPosX;
                    PosXY[i].Y = PosXY[i - 1].Y;
                }
                else if (i == 10)   // 3열
                {
                    PosXY[i].X = startPosX;
                    PosXY[i].Y = PosXY[i - 1].Y + offsetPosY;
                }
                else if (i / 5 == 2)
                {
                    PosXY[i].X = PosXY[i - 1].X - offsetPosX;
                    PosXY[i].Y = PosXY[i - 1].Y;
                }
                else if (i == 15)   // 4열
                {
                    PosXY[i].X = startPosX;
                    PosXY[i].Y = PosXY[i - 1].Y + offsetPosY;
                }
                else if (i / 5 == 3)
                {
                    PosXY[i].X = PosXY[i - 1].X - offsetPosX;
                    PosXY[i].Y = PosXY[i - 1].Y;
                }
                else if (i == 20)   // 5열
                {
                    PosXY[i].X = startPosX;
                    PosXY[i].Y = PosXY[i - 1].Y + offsetPosY;
                }
                else if (i / 5 == 4)
                {
                    PosXY[i].X = PosXY[i - 1].X - offsetPosX;
                    PosXY[i].Y = PosXY[i - 1].Y;
                }

            }
                string str = posXY[24].X.ToString();
        }
        public short bdInit()
        {
            short len = 1;
            long[] addr = new long[1] { 0xD8000000 };
            return MMCLib.mmc_initx(len, addr);
        }
        public RptMsg Origin(CmdMsg cmd)
        {
            switch (stepOrg)
            {
                case Step.STEP00:
                    if (cmd == CmdMsg.START)
                    {
                        rptOrg = RptMsg.BUSY;
                        orgDone = false;
                        stepOrg = Step.STEP01;
                    }
                    break;
                case Step.STEP01:
                    for (int i = 0; i < 2; i++)
                    {
                        rptZr[i] = axes[i].ZeroReturn(cmdZr[i]);
                        if (rptZr[i] == RptMsg.READY && cmdZr[i] == CmdMsg.CHECK)
                        {
                            cmdZr[i] = CmdMsg.START;
                        }
                        else if (rptZr[i] == RptMsg.BUSY)
                        {
                            cmdZr[i] = CmdMsg.CHECK;
                        }
                        else if (rptZr[i] == RptMsg.COMPLETE)
                        {
                            cmdZr[i] = CmdMsg.END;
                        }
                    }
                    if (rptZr[0] == RptMsg.READY && cmdZr[0] == CmdMsg.END &&
                        rptZr[1] == RptMsg.READY && cmdZr[1] == CmdMsg.END)
                    {
                        cmdZr[0] = CmdMsg.CHECK;
                        cmdZr[1] = CmdMsg.CHECK;
                        stepOrg = Step.STEP100;
                    }
                    break;
                case Step.STEP100:
                    rptOrg = RptMsg.COMPLETE;
                    stepOrg = Step.STEP101;
                    break;
                case Step.STEP101:
                    if (cmd == CmdMsg.END)
                    {
                        rptOrg = RptMsg.READY;
                        orgDone = true;
                        stepOrg = Step.STEP00;
                    }
                    break;
            }

            return rptOrg;
        }
        public void posXY_Move(int posNo)
        {
            short[] map_array = new short[2] { 2, 3 };
            MMCLib.map_axes(3, map_array);
            MMCLib.set_move_speed(axes[0].VelPos);  // 속도 
            MMCLib.set_move_accel(axes[0].AccPos);  // 가감속
            MMCLib.move_2(posXY[posNo].X, posXY[posNo].Y);
        }
        public RptMsg CartridgeRun(int targetPos, CmdMsg cmd)
        {
            switch (stepPnp)
            {
                case Step.STEP00:
                    if (cmd == CmdMsg.START)
                    {
                        rptPnp = RptMsg.BUSY;
                        stepPnp = Step.STEP01;
                    }
                    break;
                case Step.STEP01:
                    if (MMCLib.axis_done(2) == 1)
                    {
                        posXY_Move(targetPos);
                        stepPnp = Step.STEP02;
                    }
                    break;
                case Step.STEP02:
                    if (MMCLib.axis_done(2) == 1)
                    {
                        stepPnp = Step.STEP03;
                    }
                    break;
                case Step.STEP03:
                    if (MMCLib.axis_done(2) == 1 && MMCLib.axis_done(3) == 1)
                    {
                        stepPnp = Step.STEP100;
                    }
                    break;
                case Step.STEP100:
                    rptPnp = RptMsg.COMPLETE;
                    stepPnp = Step.STEP101;
                    break;
                case Step.STEP101:
                    if (cmd == CmdMsg.END)
                    {
                        rptPnp = RptMsg.READY;
                        stepPnp = Step.STEP00;
                    }
                    break;
                default:
                    break;
            }

            return rptPnp;
        }
        public RptMsg InitPos(CmdMsg cmd)
        {
            switch (stepInit)
            {
                case Step.STEP00:
                    if (cmd == CmdMsg.START)
                    {
                        rptInit = RptMsg.BUSY;
                        stepInit = Step.STEP01;
                    }
                    break;
                case Step.STEP01:
                    stepInit = Step.STEP02;
                    break;
                case Step.STEP02:
                    if (gripper.Sen_Open)
                    {
                        posXY_Move(0);
                        stepInit = Step.STEP03;
                    }
                    break;
                case Step.STEP03:
                    if (MMCLib.axis_done(0) == 1 && MMCLib.axis_done(1) == 1 && MMCLib.axis_done(2) == 1)
                    {
                        stepInit = Step.STEP100;
                    }
                    break;
                case Step.STEP100:
                    rptInit = RptMsg.COMPLETE;
                    stepInit = Step.STEP101;
                    break;
                case Step.STEP101:
                    if (cmd == CmdMsg.END)
                    {
                        rptInit = RptMsg.READY;
                        stepInit = Step.STEP00;
                    }
                    break;
                default:
                    break;
            }
            return rptInit;
        }
    }
}

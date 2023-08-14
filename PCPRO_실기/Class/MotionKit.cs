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

        public MotionKit()
        {
            axes = new Servo[3];
            axes[0] = new Servo(0);
            axes[1] = new Servo(1);
            axes[2] = new Servo(2);
            dio = new DIO();
            gripper = new Cylinder(3, dio);
            rptZr = new RptMsg[3];
            cmdZr = new CmdMsg[3] { CmdMsg.CHECK, CmdMsg.CHECK, CmdMsg.CHECK };
            rptOrg = RptMsg.READY;
            stepOrg = Step.STEP00;
            orgDone = false;
            posXY = new Point[8];
            for (int i = 0; i < 8; i++)
            {
                posXY[i].X = 0;
                posXY[i].Y = 0;
            }
            posZ = new double[2];
            posZ[0] = 0;
            posZ[1] = 0;
            stepPnp = Step.STEP00;
            stepInit = Step.STEP00;
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
                    for (int i = 0; i < 3; i++)
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
                        rptZr[1] == RptMsg.READY && cmdZr[1] == CmdMsg.END &&
                        rptZr[2] == RptMsg.READY && cmdZr[2] == CmdMsg.END)
                    {
                        cmdZr[0] = CmdMsg.CHECK;
                        cmdZr[1] = CmdMsg.CHECK;
                        cmdZr[2] = CmdMsg.CHECK;
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
        public void posXY_Save()
        {
            int idx = 0;
            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    posXY[idx].X = (int)(axes[0].ActPos + x * 28000);
                    posXY[idx].Y = (int)(axes[1].ActPos + y * 28000);
                    idx++;
                }
            }
        }
        public void posZ_Save(int posNo)
        {
            posZ[posNo] = axes[2].ActPos;
        }
        public void posXY_Move(int posNo)
        {
            short[] map_array = new short[2] { 0, 1 };
            MMCLib.map_axes(3, map_array);
            MMCLib.set_move_speed(axes[0].VelPos);
            MMCLib.set_move_accel(axes[0].AccPos);
            MMCLib.move_2(posXY[posNo].X, posXY[posNo].Y);
        }
        public void posZ_Move(int posNo)
        {
            MMCLib.start_move(2, posZ[posNo], axes[2].VelPos, axes[2].AccPos);
        }
        public RptMsg PickNPlace(int startPos, int endPos, CmdMsg cmd)
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
                    gripper.GripOpen();
                    stepPnp = Step.STEP02;
                    break;
                case Step.STEP02:
                    if (Gripper.Sen_Open)
                    {
                        posZ_Move(0);
                        stepPnp = Step.STEP03;
                    }
                    break;
                case Step.STEP03:
                    if (MMCLib.axis_done(2) == 1)
                    {
                        posXY_Move(startPos);
                        stepPnp = Step.STEP04;
                    }
                    break;
                case Step.STEP04:
                    if (MMCLib.axis_done(0) == 1 && MMCLib.axis_done(1) == 1)
                    {
                        posZ_Move(1);
                        stepPnp = Step.STEP05;
                    }
                    break;
                case Step.STEP05:
                    if (MMCLib.axis_done(2) == 1)
                    {
                        gripper.GripClose();
                        stepPnp = Step.STEP06;
                    }
                    break;
                case Step.STEP06:
                    if (Gripper.Sen_Close)
                    {
                        posZ_Move(0);
                        stepPnp = Step.STEP07;
                    }
                    break;
                case Step.STEP07:
                    if (MMCLib.axis_done(2) == 1)
                    {
                        posXY_Move(endPos);
                        stepPnp = Step.STEP08;
                    }
                    break;
                case Step.STEP08:
                    if (MMCLib.axis_done(0) == 1 && MMCLib.axis_done(1) == 1)
                    {
                        posZ_Move(1);
                        stepPnp = Step.STEP09;
                    }
                    break;
                case Step.STEP09:
                    if (MMCLib.axis_done(2) == 1)
                    {
                        gripper.GripOpen();
                        stepPnp = Step.STEP10;
                    }
                    break;
                case Step.STEP10:
                    if (Gripper.Sen_Open)
                    {
                        posZ_Move(0);
                        stepPnp = Step.STEP11;
                    }
                    break;
                case Step.STEP11:
                    if (MMCLib.axis_done(2) == 1)
                    {
                        posXY_Move(0);
                        stepPnp = Step.STEP12;
                    }
                    break;
                case Step.STEP12:
                    if (MMCLib.axis_done(0) == 1 && MMCLib.axis_done(1) == 1)
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
                    gripper.GripOpen();
                    stepInit = Step.STEP02;
                    break;
                case Step.STEP02:
                    if (gripper.Sen_Open)
                    {
                        posZ_Move(0);
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

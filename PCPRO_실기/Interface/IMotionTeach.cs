﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPRO_실기
{
    public interface IMotionTeach
    {
        void posXY_Move(int posNo);
        Point[] PosXY { get; set; }
        double[] PosZ { get; set; }
        bool OrgDone { get; }
        DIO Dio { get; }
        Cylinder Gripper { get; }
        RptMsg CartridgeRun(int endPos, CmdMsg cmd);

    }
}

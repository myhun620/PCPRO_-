using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPRO_실기
{
    public class sym
    {
        public const double GearRatio = 1000.0;
    }
    public enum Dir
    {
        FWD, BWD, LEFT, RIGHT, UP, DOWN
    }
    public enum RptMsg
    {
        READY, BUSY, COMPLETE
    }
    public enum CmdMsg
    {
        CHECK, START, END
    }
    public enum Step
    {
        STEP00, STEP01, STEP02, STEP03, STEP04, STEP05, STEP06, STEP07, STEP08, STEP09, STEP10, STEP11, STEP12, STEP13,
        STEP100, STEP101
    }
    public enum LogModule
    {
        SAVE, LOAD, RECEIVE, SEND
    }
}

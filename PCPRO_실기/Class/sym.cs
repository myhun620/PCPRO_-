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
        CHECK, START, END, DONE
    }
    public enum Step
    {
        STEP00, STEP01, STEP02, STEP03, STEP04, STEP05, STEP06, STEP07, STEP08, STEP09, STEP10, 
        STEP11, STEP12, STEP13, STEP14, STEP15, STEP16, STEP17, STEP18, STEP19, STEP20,
        STEP100, STEP101
    }
    public enum LogModule
    {
        SAVE, LOAD, RECEIVE, SEND
    }
    
    public enum Axis
    {
        X, Z
    }

    public enum Module1X
    {
            // Module1 X접점
        md1_SupplyCylinderFWD = 2,
        md1_SupplyCylinderBWD, 
        cartridgeZAxisUpLimit = 10,
        cartridgeZAxisDownLimit,
        cartridgeZAxisHome, cartridgeXAxisRightLimit, cartridgeXAxisLeftLimit, cartridgeXAxisHome,
    }
    public enum ModulePanel
    {
        // 판넬
        start, 
        stop, 
        emo, 
        manual, 
        auto, 
        reset
    }
    public enum Module1Y
    {
        // Module1 Y접점
        md1_suppplyCylinderFWD = 3, 
        md1_suppplyCylinderBWD, 
        md1_conveyorOnOff = 8, 
        md1_CartredgeZAxisInterlock
    }
    public enum Module2X
    {
        // Module2 X접점
        productCylinderFWD = 1, 
        productCylinderBWD, productSensor, transferCylinderLeft, transferCylinderRight, 
        transferCylinderDown, transferCylinderUp, transferGrip, transferUnGrip, supplyCylinderCW, 
        supplyCylinderCCW, supplyCylinderDown, supplyCylinderUp
    }
    public enum Module2Y
    { 
        // Module1 Y접점
        md2_productCylinderFWD = 3, 
        md2_productCylinderBWD, 
        md2_TransferCylinderRight, 
        md2_TransferCylinderLeft,
        md2_TransferCylinderDown, 
        md2_TransferCylinderUp, 
        md2_TransferCylinderGripOnOff,
        md2_supplyCylinderCW, 
        md2_supplyCylinderCCW, 
        md2_supplyCylinderUpDown
    }
}

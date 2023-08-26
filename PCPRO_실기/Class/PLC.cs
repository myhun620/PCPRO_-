using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActUtlTypeLib;
using System.Threading;
using System.Timers;

namespace PCPRO_실기
{
    public class PLC
    {
        ActUtlType _plc;
        public int IRet;
        public bool bThdReadPLC;
        private string moduleNum;

        public short gerDevice;

        public System.Timers.Timer Timer;

        public bool[] _plc1DeviceX;
        public bool[] _plc1DevicePanel;
        public bool[] _plc1DeviceY;

        public bool[] _plc2DeviceX;
        public bool[] _plc2DevicePanel;
        public bool[] _plc2DeviceY;

        public PLC(ActUtlType act, string moduleNum)
        {
            _plc = act;
            this.moduleNum = moduleNum;
            IRet = 99;

            _plc1DeviceX = new bool[32];
            _plc1DevicePanel = new bool[32];
            _plc1DeviceY = new bool[32];
            
            _plc2DeviceX = new bool[32];
            _plc2DevicePanel = new bool[32];
            _plc2DeviceY = new bool[32];

            // 타이머로..
            Timer = new System.Timers.Timer();
            Timer.Interval = 200;
            Timer.Elapsed += TimerIOUpdate;
            Timer.Start();
        }

        public void PLCRead(string device)
        {
            _plc.GetDevice2(device, out gerDevice);
        }

        public int PLCOpen()
        {
            int i = _plc.Open();
            //thdReadPLC = new Thread(new ThreadStart(ReadDevices));
            //thdReadPLC.Start();
            bThdReadPLC = true;

            return i;
        }

        private void ReadPLCDevice(string startDevice, bool[] readDevice) 
        {
            short temp;
            _plc.ReadDeviceBlock2(startDevice, 1, out temp);
            for (int i = 0; i < 16; i++)
                readDevice[i] = (temp & (1 << i)) != 0 ? true : false;
        }
        private void TimerIOUpdate(object sender, ElapsedEventArgs e)
        {

            if (moduleNum == "Module1")
            {
    
                ReadPLCDevice("X0", _plc1DeviceX);
                ReadPLCDevice("X10", _plc1DevicePanel);
                ReadPLCDevice("Y20", _plc1DeviceY);
            }
            else if (moduleNum == "Module2")
            {
                ReadPLCDevice("X0", _plc2DeviceX);
                ReadPLCDevice("X10", _plc2DevicePanel);
                ReadPLCDevice("Y20", _plc2DeviceY);
            }
        }
        public void PLCWrite(string device, short data)
        {
            _plc.SetDevice2(device, data);
        }
    }
}

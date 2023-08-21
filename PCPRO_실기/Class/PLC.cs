using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActUtlTypeLib;
using System.Threading;

namespace PCPRO_실기
{
    public class PLC
    {
        ActUtlType _plc;
        public int IRet;
        public Thread thdReadPLC;
        public bool bThdReadPLC;

        public short gerDevice;
        public short cartridgeZAxisUpLimit;
        public short cartridgeZAxisDownLimit;
        public short cartridgeZAxisHome;
        public short cartridgeXAxisUpLimit;
        public short cartridgeXAxisDownLimit;
        public short cartridgeXAxisHome;

        public PLC(ActUtlType act)
        {
            _plc = act;
            thdReadPLC = new Thread(new ThreadStart(ReadDevices));
        }

        public void PLCRead(string device)
        {
            _plc.GetDevice2(device, out gerDevice);

        }

        public int PLCOpen()
        {
            int i = _plc.Open();
            thdReadPLC.Start();
            bThdReadPLC = true;

            return i;
        }

        public void ReadDevices()
        {
            while (bThdReadPLC)
            {
                _plc.GetDevice2("X0A", out cartridgeZAxisUpLimit);
                _plc.GetDevice2("X0B", out cartridgeZAxisDownLimit);
                _plc.GetDevice2("X0C", out cartridgeZAxisHome);
                _plc.GetDevice2("X0D", out cartridgeXAxisUpLimit);
                _plc.GetDevice2("X0E", out cartridgeXAxisDownLimit);
                _plc.GetDevice2("X0F", out cartridgeXAxisHome);
            }
            Thread.Sleep(10);
        }

        public void PLCWrite(string device, short data)
        {
            _plc.SetDevice2(device, data);
        }
    }
}

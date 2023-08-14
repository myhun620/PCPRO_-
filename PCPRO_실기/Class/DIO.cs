using MMCWHPNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPRO_실기
{
    public class DIO
    {
        bool[] _in, _out;
        public bool[] In { get => _in; set => _in = value; }
        public bool[] Out { get => _out; set => _out = value; }
        public DIO()
        {
            _in = new bool[32];
            _out = new bool[32];
        }
        public void BitUpdate()
        {
            int inBuf = 0, outBuf = 0;
            int bitMask = 1;
            MMCLib.get_option_io(0,ref inBuf);
            MMCLib.get_option_out_io(0,ref outBuf);

            inBuf = ~inBuf;
            outBuf = ~outBuf;

            for(int bitNo=0;bitNo<32; bitNo++)
            {
                _in[bitNo] = (inBuf & (bitMask << bitNo)) != 0 ? true : false;
                _out[bitNo] = (outBuf & (bitMask << bitNo)) != 0 ? true : false;
            }
        }
        public void BitOn(short bitNo)
        {
            MMCLib.reset_option_bit(bitNo);
        }
        public void BitOff(short bitNo)
        {
            MMCLib.set_option_bit(bitNo);
        }
    }
}

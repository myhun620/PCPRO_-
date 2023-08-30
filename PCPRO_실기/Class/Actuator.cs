using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPRO_실기
{
    public abstract class Actuator
    {
        readonly short axNo;
        public short AxNo
        {
            get { return axNo; }
        }
        public Actuator(short axNo)
        {
            this.axNo = axNo;
        }
    }
}

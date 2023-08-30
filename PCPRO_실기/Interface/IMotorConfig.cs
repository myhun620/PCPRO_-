using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPRO_실기
{
    public interface IMotorConfig
    {
        short AccJog { get; set; }
        short AccPos { get; set; }
        double VelJog { get; set; }
        double VelOrg1 { get; set; }
        double VelPos { get; set; }
    }
}

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
        short AccInch { get; set; }
        short AccOrg { get; set; }
        short AccPos { get; set; }
        short DecJog { get; set; }
        short DecInch { get; set; }
        short DecOrg { get; set; }
        short DecPos { get; set; }
        double VelJog { get; set; }
        double VelInch { get; set; }
        double VelOrg1 { get; set; }
        double VelOrg2 { get; set; }
        double VelOrg3 { get; set; }
        double VelPos { get; set; }
        void SaveConfig();
    }
}

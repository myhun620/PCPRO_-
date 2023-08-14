using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPRO_실기
{
    public interface IMotorTeach
    {
        void JogMove(Dir dir);
        void JogStop();
        void InchingMove(double dist);
    }
}

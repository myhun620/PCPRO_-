using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPRO_실기
{
    public class Cylinder : Actuator
    {
        bool sen_Open, sen_Close;
        DIO dio;

        public bool Sen_Open { get => sen_Open; set => sen_Open = value; }
        public bool Sen_Close { get => sen_Close; set => sen_Close = value; }

        public Cylinder(short axNo, DIO dio) : base(axNo)
        {
            sen_Open = false;
            sen_Close = false;
            this.dio = dio;
        }
        public void GripOpen()
        {
            dio.BitOn(1);
            dio.BitOff(0);
        }
        public void GripClose()
        {
            dio.BitOn(0);
            dio.BitOff(1);
        }
        public void GetSensor()
        {
            sen_Open = !dio.In[1];
            sen_Close = dio.In[1];
        }
    }
}

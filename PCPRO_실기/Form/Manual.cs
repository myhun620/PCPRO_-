using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ActUtlTypeLib;


namespace PCPRO_실기
{
    public partial class Manual : Form
    {
        // 필드 영역
        MotionKit motionKit;
        Axis X, Z;
        PLC module1PLC, module2PLC;
        

        public Manual(MotionKit motion, PLC module1PLC, PLC module2PLC)
        {
            InitializeComponent();

            this.motionKit = motion;

            this.module1PLC = module1PLC;
            this.module2PLC = module2PLC;
        }


        private void ActuatorManualControl(object sender, EventArgs e)
        {
            // 구동기 수동 제어
            Button btn = sender as Button;
            int tag = int.Parse(btn.Tag.ToString());

            // 모듈1 공급 실린더
            if (tag == 0)   // 모듈1 공급 실린더 전진
            {
                module1PLC.PLCWrite("Y24", 0);
                module1PLC.PLCWrite("Y23", 1);
            }
            else if (tag == 1) // 모듈1 공급 실린더 후진
            {
                module1PLC.PLCWrite("Y23", 0);
                module1PLC.PLCWrite("Y24", 1);
            }

            // 모듈1 컨베이어
            if (tag == 2) // 모듈1 컨베이어 작동
            {
                module1PLC.PLCWrite("Y28", 1);
            }
            else if (tag == 3)  // 모듈1 컨베이어 정지
            {
                module1PLC.PLCWrite("Y28", 0);

            }

            // 모듈2 공급실린더
            if (tag == 8)   // 모듈2 공급실린더 업
            {
                module2PLC.PLCWrite("Y2C", 0);
            }
            // 모듈2 공급실린더
            else if (tag == 9) // 모듈2 공급실린더 다운
            {
                module2PLC.PLCWrite("Y2C", 1);
            }
            else if (tag == 10) // 모듈2 공급실린더 ccw
            {
                module2PLC.PLCWrite("Y2A", 0);
                module2PLC.PLCWrite("Y2B", 1);
            }
            else if (tag == 11) // 모듈2 공급실린더 cw
            {
                module2PLC.PLCWrite("Y2B", 0);
                module2PLC.PLCWrite("Y2A", 1);
            }

            // 제품밀착실린더
            if (tag == 12)  // 제품밀착실린더 전진
            {
                module2PLC.PLCWrite("Y24", 0);
                module2PLC.PLCWrite("Y23", 1);
            }
            else if (tag == 13) // 제품밀착실린더 후진
            {
                module2PLC.PLCWrite("Y23", 0);
                module2PLC.PLCWrite("Y24", 1);
            }

            // 이송실린더
            if (tag == 14)  // 이송실린더 업
            {
                module2PLC.PLCWrite("Y27", 0);
                module2PLC.PLCWrite("Y28", 1);
            }
            else if (tag == 15) // 이송실링더 다운
            {
                module2PLC.PLCWrite("Y28", 0);
                module2PLC.PLCWrite("Y27", 1);
            }
            else if (tag == 16) // 이송실링더 left
            {
                module2PLC.PLCWrite("Y25", 0);
                module2PLC.PLCWrite("Y26", 1);
            }
            else if (tag == 17) // 이송실링더 right
            {
                module2PLC.PLCWrite("Y26", 0);
                module2PLC.PLCWrite("Y25", 1);
            }
            else if (tag == 18) // 이송실링더 grip
            {
                module2PLC.PLCWrite("Y29", 1);
            }
            else if (tag == 19) // 이송실링더 unngrip
            {
                module2PLC.PLCWrite("Y29", 0);
            }
        }
                
        #region 디자인
        private void ButtonColor_Down(object sender, MouseEventArgs e) // 버튼 컬러 바꾸기 함수
        {
           Button btn = sender as Button;
            btn.BackColor = Color.YellowGreen;
        }

        private void ButtonColor_Up(object sender, MouseEventArgs e) // 버튼 컬러 바꾸기 함수
        {
            Button btn = sender as Button;
            btn.BackColor = SystemColors.Control;
        }
        #endregion



        private void MMC_JogMoveMouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            int tag = int.Parse(btn.Tag.ToString());

            if (tag == 4)
            {
                motionKit[(int)Axis.Z].JogMove(Dir.BWD);
            }
            else if (tag == 5)
            {
                motionKit[(int)Axis.Z].JogMove(Dir.FWD);
            }
            else if (tag == 6)
            {
                motionKit[(int)Axis.X].JogMove(Dir.FWD);
            }
            else if (tag == 7)
            {
                motionKit[(int)Axis.X].JogMove(Dir.BWD);
            }

            ButtonColor_Down(sender, e);
        }

        private void MMC_JogMoveMouseUp(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            int tag = int.Parse(btn.Tag.ToString());

            if (tag == 4)
            {
                motionKit[(int)Axis.Z].JogStop();
            }
            else if (tag == 5)
            {
                motionKit[(int)Axis.Z].JogStop();
            }
            else if (tag == 6)
            {
                motionKit[(int)Axis.X].JogStop();
            }
            else if (tag == 7)
            {
                motionKit[(int)Axis.X].JogStop();
            }

            ButtonColor_Up(sender, e);
        }
    }
}

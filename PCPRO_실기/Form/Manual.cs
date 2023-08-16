using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PCPRO_실기
{
    public partial class Manual : Form
    {
        // 필드 영역
        MotionKit motionkit;
        
        public Manual(MotionKit motionkit)
        {
            InitializeComponent();
            
            this.motionkit = motionkit;
        }


        private void ActuatorManualControl(object sender, EventArgs e)
        {
            // 구동기 수동 제어
            Button btn = sender as Button;
            int tag = int.Parse(btn.Tag.ToString());

            // 모듈1 공급 실린더
            if (tag == 0)   // 모듈1 공급 실린더 전진
            {
                motionkit.posXY_Move(1);
            }
            else if (tag == 1) // 모듈1 공급 실린더 후진
            {

            }

            // 모듈1 컨베이어
            if (tag == 2) // 모듈1 컨베이어 작동
            {

            }
            else if (tag == 3)  // 모듈1 컨베이어 후진
            {

            }

            // 모듈1 Z축
            if (tag == 4)   // 모듈1 Z축 상승
            {

            }
            else if (tag == 5)  // 모듈1 Z축 하강
            {

            }

            // 모듈1 X축
            if (tag == 6) // 모듈1 X축 Left
            {

            }
            else if (tag == 7)  // 모듈1 X축 Right
            {

            }

            // 모듈2 공급실린더
            if (tag == 8)   // 모듈2 공급실린더 업
            {

            }
            
            // 모듈2 공급실린더
            else if (tag == 9) // 모듈2 공급실린더 다운
            {

            }
            else if (tag == 10) // 모듈2 공급실린더 ccw
            {

            }
            else if (tag == 11) // 모듈2 공급실린더 cw
            {

            }

            // 제품밀착실린더
            if (tag == 12)  // 제품밀착실린더 전진
            {

            }
            else if (tag == 13) // 제품밀착실린더 후진
            {

            }

            // 이송실린더
            if (tag == 14)  // 이송실린더 업
            {

            }
            else if (tag == 15) // 이송실링더 다운
            {

            }
            else if (tag == 16) // 이송실링더 left
            {

            }
            else if (tag == 17) // 이송실링더 right
            {

            }
            else if (tag == 18) // 이송실링더 grip
            {

            }
            else if (tag == 19) // 이송실링더 unngrip
            {

            }
        }

        private void RealTimeDisplay()
        {
            // 입력접점 실시간 표시
        }

        private void RunCondition()
        {
            // 운전 조건
        }

        public void StopCondition() { }

        

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
    }
}

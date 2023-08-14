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

            if (tag == 0)
            {
                motionkit.posXY_Move(1);
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

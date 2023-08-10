using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using ActUtlTypeLib;    // MX Component .dll

namespace PCPRO_실기
{
    public partial class EQUIPMENT01 : Form
    {
        const string IECEIPAddress = "";
        ActUtlType plc;
        public EQUIPMENT01()
        {
            InitializeComponent();
            // 메인폼 관련 초기화
            //WindowState = FormWindowState.Maximized; // form 최대 사이즈 적용

            // IECE 연결 초기화


            // PLC 연결(MX Component) 초기화
            // plc.ActLogicalStationNumber = 0;

        }

        private void EQUIPMENT01_Load(object sender, EventArgs e)
        {
            //// 로그인 페이지
            //Login_Page login_Page = new Login_Page();
            //login_Page.Location = new Point(((this.Width / 2) - (login_Page.Width / 2)), ((this.Height / 2) - (login_Page.Height / 2)));
            //login_Page.ShowDialog();
            //if (!login_Page.login_OkNG)
            //{
            //    Application.Exit();
            //}
        }

        private void BtnAction(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int tag = int.Parse(btn.Tag.ToString());
            int tabIndex = btn.TabIndex;

            // 버튼별 동작
            if (tabIndex == 1 && tag == 8)
            {
                FileIO fi = new FileIO();
                fi.FileIOFuction(1, 1, "");
            }

            if (tabIndex == 1 && tag == 9)
            {
                FileIO fi = new FileIO();
                fi.FileIOFuction(2, 1, "");
                for (int i = 0; i < fi.LogString.Length; i++)
                {
                    tb_Message.AppendText(fi.LogString[i] + "\r\n");
                }
            }

            if (tabIndex == 1 && tag == 6)
            {
                Manual manual = new Manual();
                if (manual.Visible == true)
                {
                    return;
                }
                manual.Location = new Point(1135, 0);
                manual.Height = Screen.PrimaryScreen.Bounds.Height - 40;
                manual.Show();
            }

            if (tabIndex == 1 && tag == 11) // 메세지 텍스트박스 클리어
            {
                tb_Message.Clear();
            }

        }



        private void TestResultTextBox(string msg)
        {
            tb_Message.AppendText(msg);
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
    }
}



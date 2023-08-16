using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

using SocketNet;
//using ActUtlTypeLib;    // MX Component .dll

namespace PCPRO_실기
{
    public partial class EQUIPMENT01 : Form
    {
        Socket socket = new Socket();
        const string IECEIPAddress = "";
        MotionKit motionkit;

        // Thread 선언
        bool bStatusUpdateThread;
        Thread statusUpdateThread;
        
        //ActUtlType plc;
        public EQUIPMENT01()
        {
            InitializeComponent();
            // 메인폼 관련 초기화
            WindowState = FormWindowState.Maximized; // form 최대 사이즈 적용

            // IECE 연결 초기화



            // PLC 연결(MX Component) 초기화
            // plc.ActLogicalStationNumber = 0;

            // MMC 연결 초기화
            motionkit = new MotionKit();

            // Thread 초기화
            bStatusUpdateThread = true;
            statusUpdateThread = new Thread(new ThreadStart(StatusUpdate));
            statusUpdateThread.Start();
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

            // 모듈1 운전모드
            if (tabIndex == 1 && tag == 5)  // 자동운전
            {
                
            }
            if (tabIndex == 1 && tag == 6)  // 메뉴얼
            {
                Manual manual = new Manual(motionkit);
                if (manual.Visible == true)
                {
                    return;
                }
                manual.Location = new Point(Screen.PrimaryScreen.Bounds.Width - manual.Width, 0);
                manual.Height = this.Height;
                manual.ShowDialog();
            }
            if (tabIndex == 1 && tag == 7)  // 1Cycle
            {

            }

            // 모듈2 운전모드
            if (tabIndex == 2 && tag == 5)  // 자동운전
            {

            }
            if (tabIndex == 2 && tag == 6)  // 메뉴얼
            {
                Manual manual = new Manual(motionkit);
                if (manual.Visible == true)
                {
                    return;
                }
                manual.Location = new Point(Screen.PrimaryScreen.Bounds.Width - manual.Width, 0);
                manual.Height = this.Height;
                manual.ShowDialog();
            }
            if (tabIndex == 2 && tag == 7)  // 1Cycle
            {

            }

            // Log 버튼
            if (tabIndex == 1 && tag == 8)  // log save
            {
                FileIO fi = new FileIO();
                fi.FileIOFuction(1, 1, "");
            }

            if (tabIndex == 1 && tag == 9)  // send log load
            {
                FileIO fi = new FileIO();
                fi.FileIOFuction(2, 1, "");
                for (int i = 0; i < fi.LogString.Length; i++)
                {
                    tb_Message.AppendText(fi.LogString[i] + "\r\n");
                }
            }

            if (tabIndex == 1 && tag == 10)  // receive log load
            {
                
            }

            if (tabIndex == 1 && tag == 11) // 메세지 텍스트박스 클리어
            {
                tb_Message.Clear();
            }

            // IECS 연결
            if (tabIndex == 3 && tag == 0)
            {
                string ipAddress = tb_iecsIPAddress.Text;
                // TCP/IP 서버연결 추가
            }
            else if (tabIndex == 3 && tag == 1)
            {
                // IECS 연결 끊기
            }


            // PLC/MMC 연결
            if (tabIndex == 3 && tag == 2)
            {
                // PLC 연결 추가
                motionkit.bdInit();
            }
            else if (tabIndex == 3 && tag == 4)
            {
                // PLC / MMC 연결 끊기
                
            }

            // Log OFF
            if (tabIndex == 3 && tag == 6)
            {
                // 로그인 페이지
                Login_Page login_Page = new Login_Page();
                login_Page.Location = new Point(((this.Width / 2) - (login_Page.Width / 2)), ((this.Height / 2) - (login_Page.Height / 2)));
                login_Page.ShowDialog();
                if (!login_Page.login_OkNG)
                {
                    Application.Exit();
                }
            }

        }

        // 
        private void StatusUpdate()
        {
            while (!bStatusUpdateThread)
            {
                Thread.Sleep(10);
            }
        }

        private void TestResultTextBox(string msg)
        {
            tb_Message.AppendText(msg);
        }

        #region Form관련 영역
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
        private void EQUIPMENT01_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Thread 종료
            bStatusUpdateThread = false;
            statusUpdateThread.Interrupt();
        }

        private void EQUIPMENT01_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Thread 종료
            statusUpdateThread.Join();
        }
        #endregion

    }
}



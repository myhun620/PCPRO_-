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

using System.Net;
using System.Net.Sockets;

using SocketProtocol;   // 서버프로그램과 연결 클래스
using ActUtlTypeLib;    // MX Component .dll

namespace PCPRO_실기
{
    public partial class EQUIPMENT01 : Form
    {
        // Socket socket = new Socket();
        const string IECEIPAddress = "";
        MotionKit motionkit;

        // 자동운전관련 필드
        private int autoStep;

        // Thread 선언
        bool bStatusUpdateThread;
        Thread statusUpdateThread;
        GroupBox[] gb;

        //ActUtlType plc;
        public EQUIPMENT01()
        {
            InitializeComponent();
            // 메인폼 관련 초기화
            WindowState = FormWindowState.Maximized; // form 최대 사이즈 적용
            gb = new GroupBox[3]
            {
                gb_equipmentStatus,
                gb_module1,
                gb_module2
            };

            // IECE 연결 초기화

            //자동운전관련필드 초기화
            autoStep = -1;


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
            // 로그인 페이지
            Login_Page login_Page = new Login_Page();
            login_Page.Location = new Point(((this.Width / 2) - (login_Page.Width / 2)), ((this.Height / 2) - (login_Page.Height / 2)));
            login_Page.ShowDialog();
            if (!login_Page.login_OkNG)
            {
                Application.Exit();
            }
        }



        // 각 버튼별 Action 함수
        private void BtnAction(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int tag = int.Parse(btn.Tag.ToString());
            int tabIndex = btn.TabIndex;

            // 버튼별 동작

            // EQP1
            if (tabIndex == 1 && tag == 1)  // 자동운전
            {
                autoStep = 0;   // 자동운전 시작
                RunModeStatus(gb, "RUN");
            }
            if (tabIndex == 1 && tag == 2)  // 메뉴얼
            {
                RunModeStatus(gb, "STOP");
                Manual manual = new Manual(motionkit);
                if (manual.Visible == true)
                {
                    return;
                }
                manual.Location = new Point(Screen.PrimaryScreen.Bounds.Width - manual.Width, 0);
                manual.Height = this.Height;

                manual.ShowDialog();
            }
            if (tabIndex == 1 && tag == 3)  // Equipment 1Cycle
            {
                RunModeStatus(gb, "RUN");
            }

            if (tabIndex == 1 && tag == 4)  // Module1 1Cycle
            {
                RunModeStatus(gb_module1, "RUN");
            }
            if (tabIndex == 1 && tag == 5)  // Module2 1Cycle
            {
                RunModeStatus(gb_module2, "RUN");
            }

            // Log 버튼
            if (tabIndex == 1 && tag == 6)  // log save
            {
                FileIO fi = new FileIO();
                fi.FileIOFuction(LogModule.SAVE, LogModule.RECEIVE, "RECEIVE");
                fi.FileIOFuction(LogModule.SAVE, LogModule.SEND, "SEND");
            }

            if (tabIndex == 1 && tag == 7)  // send log load
            {
                FileIO fi = new FileIO();
                fi.FileIOFuction(LogModule.LOAD, LogModule.RECEIVE, "");
                for (int i = 0; i < fi.LogString.Length; i++)
                {
                    tb_Message.AppendText(fi.LogString[i] + "\r\n");
                }
            }

            if (tabIndex == 1 && tag == 8)  // receive log load
            {
                FileIO fi = new FileIO();
                fi.FileIOFuction(LogModule.LOAD, LogModule.SEND, "");
                for (int i = 0; i < fi.LogString.Length; i++)
                {
                    tb_Message.AppendText(fi.LogString[i] + "\r\n");
                }
            }

            if (tabIndex == 1 && tag == 9) // 메세지 텍스트박스 클리어
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
            else if (tabIndex == 3 && tag == 3)
            {
                // PLC / MMC 연결 끊기

            }

            // DIO Form 열기
            if (tabIndex == 3 && tag == 4)
            {
                IOForm io = new IOForm();
                if (io.Visible == true)
                {
                    return;
                }
                io.Location = new Point(Screen.PrimaryScreen.Bounds.Width - io.Width, 0);
                io.Height = this.Height;
                io.ShowDialog();
            }

            // Servo Teach Form 열기
            if (tabIndex == 3 && tag == 5)
            {
                Teach tc = new Teach();
                if (tc.Visible == true)
                {
                    return;
                }
                tc.Location = new Point(Screen.PrimaryScreen.Bounds.Width - tc.Width, 0);
                tc.Height = this.Height;
                tc.ShowDialog();
            }

            // Initialize
            if (tabIndex == 3 && tag == 6)
            {
                RunModeStatus(gb, "PAUSE");
            }

            // Log OFF
            if (tabIndex == 3 && tag == 7)
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

        /// <summary>
        /// 운영상태 버튼 상태 변경
        /// </summary>
        /// <param name="gb"></param>
        /// <param name="num">RUN, STOP, PAUSE, EMS</param>
        private void RunModeStatus(GroupBox[] gb, string num)
        {
            for (int i = 0; i < gb.Length; i++)
            {
                foreach (Control control in gb[i].Controls)
                {
                    if (control is Button button)
                    {
                        control.Enabled = false;
                        control.BackColor = SystemColors.Control;
                    }
                }
            }

            for (int i = 0; i < gb.Length; i++)
            {
                foreach (Control control in gb[i].Controls)
                {
                    if (control is Button button)
                    {
                        if (control.Tag.ToString() != num)
                        {
                            control.Enabled = false;
                        }
                        else if (control.Tag.ToString() == num && control.Tag.ToString() == "RUN")
                        {
                            control.BackColor = Color.YellowGreen;
                        }
                        else if (control.Tag.ToString() == num && control.Tag.ToString() == "STOP")
                        {
                            control.BackColor = Color.Brown;
                        }
                        else if (control.Tag.ToString() == num && control.Tag.ToString() == "PAUSE")
                        {
                            control.BackColor = Color.Violet;
                        }
                        else
                        {
                            control.BackColor = Color.Red;
                        }
                    }
                }
            }
        }

        private void RunModeStatus(GroupBox gb, string num)
        {

            foreach (Control control in gb.Controls)
            {
                if (control is Button button)
                {
                    control.Enabled = false;
                    control.BackColor = SystemColors.Control;
                }
            }

            foreach (Control control in gb.Controls)
            {
                if (control is Button button)
                {
                    if (control.Tag.ToString() != num)
                    {
                        control.Enabled = false;
                    }
                    else if (control.Tag.ToString() == num && control.Tag.ToString() == "RUN")
                    {
                        control.BackColor = Color.YellowGreen;
                    }
                    else if (control.Tag.ToString() == num && control.Tag.ToString() == "STOP")
                    {
                        control.BackColor = Color.Brown;
                    }
                    else if (control.Tag.ToString() == num && control.Tag.ToString() == "PAUSE")
                    {
                        control.BackColor = Color.Violet;
                    }
                    else
                    {
                        control.BackColor = Color.Red;
                    }
                }
            }
        }

        #region Thread
        // Main form 모듈별 상태 업데이트 Thread
        private void StatusUpdate()
        {
            while (!bStatusUpdateThread)
            {
                try
                {
                    switch (autoStep)
                    {
                        // Module1 동작 영역
                        case 0:// 제품 카트리지 이동?? Servo 동작
                            // 작성 필요
                            break;
                        case 1: // 컨베이어 작동
                            break;
                        case 2: // 컨베이어 정지
                            break;
                        case 3: // Pick-Up Unit Cylinder Z축 하강
                            break;
                        case 4: // Pick-Up Unit Rotator -90도 회전
                            break;
                        case 5: // Pick-Up Unit Cylinder Z축 상승
                            break;
                        case 6: // 공급 실린더 전진
                            break;
                        case 7: // 공급 실린더 후진
                            break;
                        // Module2 동작 영역
                        case 8: // 이송 실린더 Down
                            break;
                        case 9: // 이송 실린더 Grip
                            break;
                        case 10: // 이송 실린더 Up
                            break;
                        case 11: // 이송 실린더 Right
                            break;
                        case 12: // 이송 실린더 Down
                            break;
                        case 13: // 이송 실린더 Ungrip
                            break;
                        case 14: // 이송 실린더 Left
                            break;
                        case 15: // 공급 실린더 CW
                            break;
                        case 16: // 공급 실린더 정지
                            break;
                        case 17: // 검사기 동작??
                            break;
                        case 18: // 공급 실린더 CW
                            break;
                        case 19: // 공급 실린더 정지
                            break;
                        case 20: // 제품밀착 실린더 전진
                            break;
                        case 21: // 제품밀착 실린더 후진
                            break;
                        default:
                            break;
                    }
                }
                catch (ThreadInterruptedException)
                {
                    throw;
                }
                catch (ThreadAbortException)
                {
                    bStatusUpdateThread = false;
                    return;
                }
                catch (SocketException)
                {
                    bStatusUpdateThread = false;
                    return;
                }
                Thread.Sleep(10);
            }
        }

        #endregion
        // Test 용으로 임시사용
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



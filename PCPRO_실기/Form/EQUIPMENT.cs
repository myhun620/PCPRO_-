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
        // 원점복귀 필드
        RptMsg rptOrg;
        CmdMsg cmdOrg;
        RptMsg rptInit;
        CmdMsg cmdInit;

        // MMC 필드
        MotionKit motionkit;

        // PLC 필드
        ActUtlType module1, module2;
        PLC module1PLC, module2PLC;
        Axis X, Z;

        // 자동운전관련 필드
        private int autoStep;
        // 

        // Thread 선언
        bool bStatusUpdateThread;
        Thread statusUpdateThread;
        GroupBox[] gb;
        NetWork tcpClientNetWork;

      
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
            tb_iecsIPAddress.Text = "210.181.151.224";
            tb_iecsPort.Text = "20000";


            //자동운전관련필드 초기화
            autoStep = -1;


            // PLC 연결(MX Component) 초기화
            module1 = new ActUtlType();
            module2 = new ActUtlType();

            module1.ActLogicalStationNumber = 1;
            module2.ActLogicalStationNumber = 2;

            module1PLC = new PLC(module1);
            module2PLC = new PLC(module2);

            // MMC 연결 초기화
            motionkit = new MotionKit(module1PLC);

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
                // Protocol ptcMessage = new Protocol();
                // ptcMessage.Name = Modulename.Feed;
                // tcpClientNetWork.SendMessage(ptcMessage);
                RunModeStatus(gb, "RUN");
            }

            if (tabIndex == 1 && tag == 2)  // 정지
            {
                RunModeStatus(gb, "STOP");
            }

            if (tabIndex == 1 && tag == 3)  // 일시정지
            {
                RunModeStatus(gb, "PAUSE");
            }

            if (tabIndex == 1 && tag == 4)  // 메뉴얼
            {
                RunModeStatus(gb, "STOP");
                Manual manual = new Manual(motionkit, module1PLC, module2PLC);
                
                
                if (manual.Visible == true)
                {
                    return;
                }
                manual.Location = new Point(Screen.PrimaryScreen.Bounds.Width - manual.Width, 0);
                manual.Height = this.Height;

                manual.ShowDialog();
            }
            if (tabIndex == 1 && tag == 5)  // Equipment 1Cycle
            {
                RunModeStatus(gb, "RUN");
            }

            if (tabIndex == 1 && tag == 6)  // Module1 1Cycle
            {
                RunModeStatus(gb_module1, "RUN");
            }
            if (tabIndex == 1 && tag == 7)  // Module2 1Cycle
            {
                RunModeStatus(gb_module2, "RUN");
            }

            if (tabIndex == 1 && tag == 8)  // EMS
            {
                RunModeStatus(gb, "EMS");
            }

            // Log 버튼
            if (tabIndex == 1 && tag == 9)  // log save
            {
                FileIO fi = new FileIO();
                fi.FileIOFuction(LogModule.SAVE, LogModule.RECEIVE, "RECEIVE");
                fi.FileIOFuction(LogModule.SAVE, LogModule.SEND, "SEND");
            }

            if (tabIndex == 1 && tag == 10)  // send log load
            {
                FileIO fi = new FileIO();
                fi.FileIOFuction(LogModule.LOAD, LogModule.RECEIVE, "");
                for (int i = 0; i < fi.LogString.Length; i++)
                {
                    tb_Message.AppendText(fi.LogString[i] + "\r\n");
                }
            }

            if (tabIndex == 1 && tag == 11)  // receive log load
            {
                FileIO fi = new FileIO();
                fi.FileIOFuction(LogModule.LOAD, LogModule.SEND, "");
                for (int i = 0; i < fi.LogString.Length; i++)
                {
                    tb_Message.AppendText(fi.LogString[i] + "\r\n");
                }
            }

            if (tabIndex == 1 && tag == 12) // 메세지 텍스트박스 클리어
            {
                tb_Message.Clear();
            }

            // IECS 연결
            if (tabIndex == 3 && tag == 0)
            {
                string ipAddress = tb_iecsIPAddress.Text;
                int portNumber = int.Parse(tb_iecsPort.Text);
                // TCP/IP 서버연결 추가
                tcpClientNetWork = new NetWork(ipAddress, portNumber);
                tb_Message.Text = tcpClientNetWork.statusMessage;
            }
            else if (tabIndex == 3 && tag == 1)
            {
                // IECS 연결 끊기

            }


            // PLC 연결
            if (tabIndex == 3 && tag == 2)
            {
                module1PLC.IRet = module1PLC.PLCOpen();
                module2PLC.IRet = module2PLC.PLCOpen();

                motionkit.bdInit(); // 보드 연결

                motionkit[(int)Axis.X].ServoOn();
                motionkit[(int)Axis.Z].ServoOn();

                motionkit[(int)Axis.X].GetSvrInfo();
                motionkit[(int)Axis.Z].GetSvrInfo();
            }
            else if (tabIndex == 3 && tag == 3)
            {
                module1PLC.IRet = module1.Close();
                module2PLC.IRet = module2.Close();

                motionkit[(int)Axis.X].ServoOff();
                motionkit[(int)Axis.Z].ServoOff();

                motionkit[(int)Axis.X].GetSvrInfo();
                motionkit[(int)Axis.Z].GetSvrInfo();
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
                InitTimer.Start();
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
                        control.Enabled = true;
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
                    control.Enabled = true;
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
            while (bStatusUpdateThread)
            {
                try
                {
                    if (module1PLC.IRet == 0 && module2PLC.IRet == 0 && motionkit[0].SvrEnable && motionkit[1].SvrEnable)
                    {
                        btn_plc_status.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        btn_plc_status.BackColor = SystemColors.Control;
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

        private void InitTimer_Tick(object sender, EventArgs e)     // 이니셜용 타이머
        {
            rptOrg = motionkit.Origin(cmdOrg);
            if (rptOrg == RptMsg.READY && cmdOrg == CmdMsg.CHECK)
            {
                cmdOrg = CmdMsg.START;
            }
            else if (rptOrg == RptMsg.BUSY)
            {
                cmdOrg = CmdMsg.CHECK;
            }
            else if (rptOrg == RptMsg.COMPLETE)
            {
                cmdOrg = CmdMsg.END;
            }
            else if (rptOrg == RptMsg.READY && cmdOrg == CmdMsg.END)
            {
                cmdOrg = CmdMsg.CHECK;
                tb_Message.Text = "원점복귀 완료";
                InitTimer.Stop();
            }
        }

        private void EQUIPMENT01_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Thread 종료
            bStatusUpdateThread = false;
            statusUpdateThread.Abort();
            module1PLC.bThdReadPLC = false;
            module2PLC.bThdReadPLC = false;
            module1PLC.thdReadPLC.Abort();
            module2PLC.thdReadPLC.Abort();
        }

        private void button7_MouseDown(object sender, MouseEventArgs e) ///////////////////////////////////////////////////
        {

        }

        private void EQUIPMENT01_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Thread 종료
            statusUpdateThread.Join();
        }
        #endregion

    }
}



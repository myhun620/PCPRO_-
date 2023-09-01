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
        Step originStep;

        // 운전 필드
        Step module1_runStep;
        private bool bPAUSE_Motionkit;
        Step module2_runStep;
        Step serverOneCycle;
        Step serverAutoRun;
        RptMsg rptPnp;
        private int iBefor_CartridgePos;
        private RptMsg rptPnp_MD1_Pause;
        private CmdMsg cmdMsg_MD1_Pause;
        RptMsg RunrptPnp;
        RptMsg module1_rptPnp;
        RptMsg module2_rptPnp;
        CmdMsg cmdPnp;
        CmdMsg module1_cmdPnp;      // 모듈1 카트리지 스텝용
        Step oneCycleStep;
        bool bInitialze_Origin;     // 이니셜(오리진) 

        // 자동운전관련 필드
        bool bAutoRunReady;
        private int cartridgePos;
        bool escapeFor;
        private bool bAuto_Module1comp;
        CmdMsg autoRun1 = CmdMsg.START;
        CmdMsg autoRun2 = CmdMsg.START;

        bool bEquipmentAutoRun;     // 자동운전 스위치
        bool bModule2Run;           // 자동운전할때 Module2 시작 스위치
        bool bOneCycle;             // EQP 운전 1회 스위치
        bool md1_OneCycle;          // module1 운전 1회 스위치
        bool md2_OneCycle;          // module2 운전 1회 스위치
        int productOutCount;
        int autoRunCartridgeCountTemp;

        // MMC 필드
        MotionKit motionkit;

        // PLC 필드
        ActUtlType module1, module2;
        PLC module1PLC, module2PLC;

        // Thread 선언
        bool bStatusUpdateThread;
        Thread statusUpdateThread;
        GroupBox[] gb;
        NetWork tcpClientNetWork;

        // IECS 통신 필드
        bool bServerConnect;
        Protocol protocol;
        Netstatus? _netStatus;
        Modulemode? _ModuleMode;
        Operationmode? _operationMode;
        Command? _command;
        Startable? _startAble;
        int[] _product;
        Runtype? _runtype;
        Endable? _endAble;
        string ReceiveMessageSum;

        // Pause, STOP 필드
        private bool bPAUSE;
        private bool bSTOP;
        private bool _bSensorPass_Temp;

        // 임시사용 필드
        bool bMD1_StartSW;
        bool bMD2_StartSW;
        private int iProductINCount;
        private int iBefor_productOutCount;
        private bool bEMS;

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
            protocol = new Protocol();
            tb_iecsIPAddress.Text = "210.181.151.224";
            tb_iecsPort.Text = "20000";
            bServerConnect = false;
            _product = new int[3];


            //운전관련필드 초기화
            bAutoRunReady = false;
            serverOneCycle = Step.STEP00;
            serverAutoRun = Step.STEP00;
            originStep = Step.STEP00;
            bOneCycle = false;
            escapeFor = false;
            oneCycleStep = Step.STEP00;
            bInitialze_Origin = false;
            bEquipmentAutoRun = false;
            bModule2Run = false;
            productOutCount = 0;
            iProductINCount = 0;
            bPAUSE = false;
            iBefor_productOutCount = 0;

            // PLC용 S/W
            bMD1_StartSW = false;
            bMD2_StartSW = false;

            // PLC 연결(MX Component) 초기화
            module1 = new ActUtlType();
            module2 = new ActUtlType();

            module1.ActLogicalStationNumber = 1;
            module2.ActLogicalStationNumber = 2;

            module1PLC = new PLC(module1, "Module1");
            module2PLC = new PLC(module2, "Module2");

            // MMC 연결 초기화
            motionkit = new MotionKit(module1PLC);

            // Thread 초기화
            bStatusUpdateThread = true;
            statusUpdateThread = new Thread(new ThreadStart(MainThread));
            statusUpdateThread.Start();

            // IOUpdate Timer
            IOUpdate.Start();

            _bSensorPass_Temp = false;
        }

        private void EQUIPMENT01_Load(object sender, EventArgs e)
        {
            // 로그인 페이지
            LoginPage();

            tb_name.Text = "Feed";
            tb_netstatus.Text = "OFF";
            tb_mode.Text = "MANUAL";
            tb_optmode.Text = "STOP";
            tb_commd.Text = "ABLE";
            tb_startable.Text = "OFF";
            tb_product.Text = "0";
            tb_runtype.Text = "OneTime";
            tb_endAble.Text = "OFF";
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
                AutoRunCheckMethod();
            }

            if (tabIndex == 1 && tag == 2)  // 정지
            {
                RunModeStatus(gb, "STOP");
                if (bEquipmentAutoRun)
                {
                    if (!bSTOP)
                        bSTOP = true;
                    else
                        bSTOP = false;
                }
            }
            if (tabIndex == 1 && tag == 3)  // 일시정지
            {
                RunModeStatus(gb, "PAUSE");
                if (!bPAUSE)
                    bPAUSE = true;
                else
                    bPAUSE = false;
            }
            if (tabIndex == 1 && tag == 4)  // 메뉴얼
            {
                RunModeStatus(gb, "STOP");
                module1PLC.PLCWrite("Y29", 1);
                Manual manual = new Manual(motionkit, module1PLC, module2PLC);

                if (manual.Visible == true)
                {
                    return;
                }
                manual.Location = new Point(Screen.PrimaryScreen.Bounds.Width - manual.Width, 0);
                manual.Height = this.Height;

                manual.ShowDialog();
            }

            // Cycle 동작
            if (tabIndex == 1 && tag == 5)  // Equipment 1Cycle
            {
                RunModeStatus(gb, "RUN");
                bOneCycle = true;
                escapeFor = false;
                oneCycleStep = Step.STEP00;
            }
            if (tabIndex == 1 && tag == 6)  // Module1 1Cycle
            {
                RunModeStatus(gb_module1, "RUN");
                md1_OneCycle = true;
                escapeFor = false;
                module1_runStep = Step.STEP00;
            }
            if (tabIndex == 1 && tag == 7)  // Module2 1Cycle
            {
                RunModeStatus(gb_module2, "RUN");
                md2_OneCycle = true;
                module2_runStep = Step.STEP06;
            }

            // EMS
            if (tabIndex == 1 && tag == 8)  // EMS
            {
                RunModeStatus(gb, "EMS");
                tb_optmode.Text = "EMS";
                EMS();
            }

            // Log 버튼
            if (tabIndex == 1 && tag == 10)  // send log load
            {
                FileIO fi = new FileIO();
                fi.FileIOFuction(LogModule.LOAD, LogModule.SEND, "");
                for (int i = 0; i < fi.LogString.Length; i++)
                {
                    tb_send_Message.AppendText(fi.LogString[i] + "\r\n");
                }
            }
            if (tabIndex == 1 && tag == 11)  // receive log load
            {
                FileIO fi = new FileIO();
                fi.FileIOFuction(LogModule.LOAD, LogModule.RECEIVE, "");
                for (int i = 0; i < fi.LogString.Length; i++)
                {
                    tb_rcv_Message.AppendText(fi.LogString[i] + "\r\n");
                }
            }
            if (tabIndex == 1 && tag == 12) // 메세지 텍스트박스 클리어
            {
                tb_rcv_Message.Clear();
                tb_send_Message.Clear();
            }

            // IECS 연결
            if (tabIndex == 3 && tag == 0)
            {
                string ipAddress = tb_iecsIPAddress.Text;
                int portNumber = int.Parse(tb_iecsPort.Text);
                // TCP/IP 서버연결 추가
                tcpClientNetWork = new NetWork(ipAddress, portNumber);
                bServerConnect = true;

                // 상태보고
            }
            else if (tabIndex == 3 && tag == 1)
            {
                // IECS 연결 끊기
                bServerConnect = false;
                ControlThreadChanged(tb_netstatus, "OFF");
                tcpClientNetWork.DisConnect();
            }
            // PLC 연결
            if (tabIndex == 3 && tag == 2)
            {
                Thread.Sleep(1000);
                if (module1PLC.IRet != 0 && module2PLC.IRet != 0)
                {
                    module1PLC.IRet = module1PLC.PLCOpen();
                    module2PLC.IRet = module2PLC.PLCOpen();
                }
            }
            // MMC 연결
            if (tabIndex == 3 && tag == 8)
            {
                if (motionkit[0].SvrEnable == false || motionkit[1].SvrEnable == false)
                {
                    motionkit.bdInit(); // 보드 연결
                    motionkit[(int)Axis.X].ServoOn();
                    motionkit[(int)Axis.Z].ServoOn();
                    motionkit[(int)Axis.X].GetSvrInfo();
                    motionkit[(int)Axis.Z].GetSvrInfo();
                }
            }
            else if (tabIndex == 3 && tag == 3)
            {
                if (module1PLC.IRet == 0 && module2PLC.IRet == 0)
                {
                    module1PLC.Timer.Stop();
                    module2PLC.Timer.Stop();
                    module1PLC.IRet = module1.Close();
                    module2PLC.IRet = module2.Close();
                }
                if (motionkit[0].SvrEnable == true || motionkit[1].SvrEnable == true)
                {
                    motionkit[(int)Axis.X].ServoOff();
                    motionkit[(int)Axis.Z].ServoOff();
                    motionkit[(int)Axis.X].GetSvrInfo();
                    motionkit[(int)Axis.Z].GetSvrInfo();
                }
            }
            // DIO Form 열기
            if (tabIndex == 3 && tag == 4)
            {
                IOForm io = new IOForm(module1PLC, module2PLC);
                if (io.Visible == true)
                {
                    return;
                }
                io.Location = new Point(Screen.PrimaryScreen.Bounds.Width - io.Width, 0);
                io.Height = this.Height;
                io.ShowDialog();
            }
            // Cartridge Choose Form 열기
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
                module1PLC.PLCWrite("Y29", 1);
                if (bInitialze_Origin)
                {
                    MessageBox.Show("원점복귀 완료 상태입니다.");
                    bInitialze_Origin = false;
                }
                else
                {
                    bEMS = false;
                    btn_Auto.BackColor = SystemColors.Control;
                    btn_ems.BackColor = SystemColors.Control;
                    bAutoRunReady = false;
                    tb_optmode.Text = "STOP";
                    originStep = Step.STEP01;
                    InitTimer.Start();
                }
            }
            // Log OFF
            if (tabIndex == 3 && tag == 7)
            {
                LoginPage();
            }
        }

        #region 통신영역

        /// <summary>
        /// 서버로 신호보내기
        /// </summary>
        /// <param name="netStatus">OFF, ON</param>
        /// <param name="ModuleMode">MANUAL, ON</param>
        /// <param name="operationMode">RUN, STOP, PAUSE, EMS</param>
        /// <param name="command">ABLE, DO, BUSY, COMP</param>
        /// <param name="startAble">OFF, ON</param>
        /// <param name="product">?,?,?</param>
        /// <param name="runtype"></param>
        private void TextBoxChanged(object sender, EventArgs e)
        {
            // Send필드
            Netstatus netStatus = Netstatus.OFF;
            Modulemode ModuleMode = Modulemode.MANUAL;
            Operationmode operationMode = Operationmode.RUN;
            Command command = Command.ABLE;
            Startable startAble = Startable.OFF;
            Product product = new Product() { Total = 0 };

            if (tb_netstatus.Text == "ON")
                netStatus = Netstatus.ON;
            else if (tb_netstatus.Text == "OFF")
                netStatus = Netstatus.OFF;

            if (tb_mode.Text == "MANUAL")
                ModuleMode = Modulemode.MANUAL;
            else if (tb_mode.Text == "AUTO")
                ModuleMode = Modulemode.AUTO;

            if (tb_optmode.Text == "RUN")
                operationMode = Operationmode.RUN;
            else if (tb_optmode.Text == "PAUSE")
                operationMode = Operationmode.PAUSE;
            else if (tb_optmode.Text == "STOP")
                operationMode = Operationmode.STOP;
            else if (tb_optmode.Text == "EMS")
                operationMode = Operationmode.EMS;

            if (tb_commd.Text == "ABLE")
                command = Command.ABLE;
            else if (tb_commd.Text == "BUSY")
                command = Command.BUSY;
            else if (tb_commd.Text == "COMP")
                command = Command.COMP;
            else if (tb_commd.Text == "DO")
                command = Command.DO;

            if (tb_startable.Text == "ON")
                startAble = Startable.ON;
            else if (tb_startable.Text == "OFF")
                startAble = Startable.OFF;

            product = new Product() { Total = int.Parse(tb_product.Text) };

            if (bServerConnect)
            {
                SendMessageSort(netStatus, ModuleMode, operationMode, command, startAble, product);
                tb_send_Message.AppendText($"\r\n보낸 메시지 : Feed, {netStatus}, {ModuleMode}, {operationMode}, {command}, {startAble}, {product.Total}");
            }
        }

        private void ControlThreadChanged(Control txt, string str)
        {
            if (txt.InvokeRequired)
            {
                txt.Invoke(new MethodInvoker(delegate ()
                {
                    txt.Text = str;
                }));
            }
        }

        private void SendMessageSort(Netstatus netStatus, Modulemode ModuleMode, Operationmode operationMode, Command command, Startable startAble, Product product)
        {
            protocol.Name = Modulename.Feed;
            protocol.NetStatus = netStatus;
            protocol.Mode = ModuleMode;
            protocol.OptMode = operationMode;
            protocol.Commd = command;
            protocol.StartAble = startAble;
            protocol.ProDuct = product;

            FileIO fi = new FileIO();
            string sendLog = "Feed, " + netStatus.ToString() + ", " + ModuleMode.ToString() + ", " + operationMode.ToString() + ", "
                + command.ToString() + ", " + startAble.ToString() + ", " + product.Total.ToString();
            fi.FileIOFuction(LogModule.SAVE, LogModule.SEND, sendLog);

            tcpClientNetWork.SendMessage(protocol);
        }

        private void ReceiveMessageSort()
        {
            Protocol ptc = tcpClientNetWork.ReceiveMessage();

            _netStatus = ptc.NetStatus;
            _ModuleMode = ptc.Mode;
            _operationMode = ptc.OptMode;
            _command = ptc.Commd;
            _startAble = ptc.StartAble;
            _product[0] = ptc.ProDuct.Metal;
            _product[1] = ptc.ProDuct.NonMtl;
            _product[2] = ptc.ProDuct.Total;
            _runtype = ptc.RunType;
            _endAble = ptc.EndAble;

            ReceiveMessageSum = _netStatus.ToString() + ", " + _ModuleMode.ToString() + ", " +
                                _operationMode.ToString() + ", " + _command.ToString() + ", " +
                                _startAble.ToString() + ", " + _product[2].ToString() + ", " +
                                _runtype.ToString() + ", " + _endAble.ToString();

            FileIO fi = new FileIO();
            fi.FileIOFuction(LogModule.SAVE, LogModule.RECEIVE, ReceiveMessageSum);
        }

        private void SendToServer_OnCycleEqupiStatus()
        {
            switch (serverOneCycle)
            {
                case Step.STEP00:
                    break;
                case Step.STEP01:
                    if (serverOneCycle == Step.STEP01)
                    {
                        if (!bEquipmentAutoRun && !bOneCycle && !md1_OneCycle && !md2_OneCycle && bServerConnect)
                        {
                            serverOneCycle = Step.STEP02;
                        }
                    }
                    break;
                case Step.STEP02:
                    if (serverOneCycle == Step.STEP02)
                    {
                        tb_startable.Text = "OFF";
                        tb_commd.Text = "BUSY";
                        bOneCycle = true;
                        serverOneCycle = Step.STEP03;
                    }
                    break;
                case Step.STEP03:
                    if (serverOneCycle == Step.STEP03)
                    {
                        if (bOneCycle == false)
                        {
                            tb_commd.Text = "COMP";
                            serverOneCycle = Step.STEP04;
                        }
                    }
                    break;
                case Step.STEP04:
                    if (serverOneCycle == Step.STEP04)
                    {
                        tb_startable.Text = "ON";
                        tb_commd.Text = "ABLE";
                        serverOneCycle = Step.STEP101;
                    }
                    break;
                default:
                    break;
            }
        }

        private void SendToServer_AutoRunEqupiStatus()
        {
            switch (serverAutoRun)
            {
                case Step.STEP00:
                    if (serverAutoRun == Step.STEP00) { }

                    break;
                case Step.STEP01:
                    if (serverAutoRun == Step.STEP01)
                    {
                        if (!bEquipmentAutoRun && !bOneCycle && !md1_OneCycle && !md2_OneCycle && bServerConnect)
                        {
                            bEquipmentAutoRun = true;
                            iBefor_productOutCount = productOutCount;
                            serverAutoRun = Step.STEP02;
                        }
                    }
                    break;
                case Step.STEP02:
                    if (serverAutoRun == Step.STEP02)
                    {
                        tb_startable.Text = "OFF";
                        tb_commd.Text = "BUSY";

                        if (iBefor_productOutCount < productOutCount)
                        {
                            iBefor_productOutCount = productOutCount;
                            serverAutoRun = Step.STEP03;
                        }
                    }
                    break;
                case Step.STEP03:
                    if (serverAutoRun == Step.STEP03)
                    {
                        tb_startable.Text = "ON";
                        tb_commd.Text = "COMP";
                        if (productOutCount != autoRunCartridgeCountTemp)
                        {
                            serverAutoRun = Step.STEP02;
                        }
                        else if (!bEquipmentAutoRun)
                        {
                            serverAutoRun = Step.STEP00;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion



        #region Thread

        // Main form 모듈별 상태 업데이트 Thread
        private void MainThread()
        {
            while (bStatusUpdateThread)
            {
                try
                {
                    // 서버 송수신 표시
                    if (bServerConnect && tcpClientNetWork.ReceiveMessageList.Count > 0)
                    {
                        ReceiveMessageSort();
                        if (tb_rcv_Message.InvokeRequired)
                        {
                            tb_rcv_Message.Invoke(new MethodInvoker(delegate ()
                            {
                                tb_rcv_Message.AppendText($"\r\n받은 메시지 : {ReceiveMessageSum}");
                            }));
                        }
                    }
                    else
                    {
                        _netStatus = null;
                        _ModuleMode = null;
                        _operationMode = null;
                        _command = null;
                        _startAble = null;
                        _runtype = null;
                    }

                    // EMS
                    if (_operationMode == Operationmode.EMS)
                    {
                        bEMS = true;
                    }

                    if (_operationMode == Operationmode.RUN && _command == Command.DO && _runtype == Runtype.OneTime && (!bOneCycle && !bEquipmentAutoRun))
                        serverOneCycle = Step.STEP01;

                    if (_operationMode == Operationmode.RUN && _command == Command.DO && _runtype == Runtype.Continue && (!bOneCycle && !bEquipmentAutoRun))
                        serverAutoRun = Step.STEP01;
                    
                    // 판넬 스타트 버튼 스위치
                    if (module1PLC._plc1DevicePanel[(int)ModulePanel.start])
                        bMD1_StartSW = true;
                    else
                        bMD1_StartSW = false;
                    if (module2PLC._plc2DevicePanel[(int)ModulePanel.start])
                        bMD2_StartSW = true;
                    else
                        bMD2_StartSW = false;
                    
                    // STOP
                    if (_operationMode == Operationmode.STOP 
                        || module1PLC._plc1DevicePanel[(int)ModulePanel.stop] 
                        || module2PLC._plc2DevicePanel[(int)ModulePanel.stop])
                        bSTOP = true;

                    if ((bEquipmentAutoRun || bOneCycle) && ((module1PLC._plc1DevicePanel[(int)ModulePanel.manual] && module2PLC._plc2DevicePanel[(int)ModulePanel.manual]) && bServerConnect))
                    {
                        bSTOP = true;
                    }

                    // PAUSE
                    if (_operationMode == Operationmode.PAUSE)
                        bPAUSE = true;
                    else if (bPAUSE && _operationMode == Operationmode.RUN)
                        bPAUSE = false;

                    if (bOneCycle)
                    {
                        EQP_OneCycle();
                        btn_oneCycle.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        btn_oneCycle.BackColor = SystemColors.Control;
                    }
                    if (md1_OneCycle)
                    {
                        Module1_AutoRun_use();
                        btn_MD1_One.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        btn_MD1_One.BackColor = SystemColors.Control;
                    }
                    if (md2_OneCycle)
                    {
                        Module2_AutoRun_use();
                        btn_MD2_One.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        btn_MD2_One.BackColor = SystemColors.Control;

                    }
                    if (bEquipmentAutoRun)
                    {
                        EqupimentAutoRun();
                        btn_AutoRun.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        btn_AutoRun.BackColor = SystemColors.Control;
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



        #region 운전

        private void EMS()
        {
            if (module1PLC.IRet != 0 && module2PLC.IRet != 0)
                return;

            if (!module1PLC._plc1DevicePanel[(int)ModulePanel.emo])
            {
                btn_md1_ems.BackColor = Color.Red;
            }
            else
                btn_md1_ems.BackColor = SystemColors.Control;
            if (!module2PLC._plc2DevicePanel[(int)ModulePanel.emo])
            { 
                btn_md2_ems.BackColor = Color.Red;
            }
            else
                btn_md2_ems.BackColor = SystemColors.Control;

            if (!module1PLC._plc1DevicePanel[(int)ModulePanel.emo] || !module2PLC._plc2DevicePanel[(int)ModulePanel.emo] 
                || bEMS || _operationMode == Operationmode.EMS || btn_ems.BackColor == Color.YellowGreen)
            {
                btn_ems.BackColor = Color.Red;
                btn_Auto.BackColor = SystemColors.Control;
                tb_optmode.Text = "EMS";
                
                bStatusUpdateThread = false;    // MainThread 종료
                statusUpdateThread.Abort();
                statusUpdateThread.Join();

                bOneCycle = false;
                bEquipmentAutoRun = false;
                md1_OneCycle = false;
                md2_OneCycle = false;

                bInitialze_Origin = false;      // 원점복귀 False
                for (int i = 0; i < Teach.sCartridge.Length; i++)
                    Teach.sCartridge[i] = false;
                tb_product.Text = "0";
                lb_Total.Text = "0";
                productOutCount = 0;
                iBefor_productOutCount = 0;

                // 각운전모드 정지 추가 필요
                motionkit[(int)Axis.X].Stop();
                motionkit[(int)Axis.Z].Stop();
                motionkit[(int)Axis.X].ServoOff();  // 카트리지 서보OFF, 즉시 정지
                motionkit[(int)Axis.Z].ServoOff();

                module1PLC.PLCWrite("Y24", 0);      // 공급 실린더 후진 오프
                module1PLC.PLCWrite("Y23", 0);      // 공급 실린더 전진 오프
                module1PLC.PLCWrite("Y28", 0);      // Module1 컨베이어 정지
                if (module2PLC._plc2DeviceX[(int)Module2X.supplyCylinderUp])        // 모듈2 공급 실린더 업/다운       
                    module2PLC.PLCWrite("Y2C", 0);
                else if (module2PLC._plc2DeviceX[(int)Module2X.supplyCylinderDown])
                    module2PLC.PLCWrite("Y2C", 1);

                module1PLC.PLCWrite("Y2A", 0);      // 공급실린더 cw,ccw
                module1PLC.PLCWrite("Y2B", 0);

                module2PLC.PLCWrite("Y24", 0);      // 제품밀착실린더 
                module2PLC.PLCWrite("Y23", 0);

                module2PLC.PLCWrite("Y27", 0);      // 이송실린더 업/다운
                module2PLC.PLCWrite("Y28", 0);

                module2PLC.PLCWrite("Y25", 0);      // 이송실린더 Left,Right
                module2PLC.PLCWrite("Y26", 0);

                if (module2PLC._plc2DeviceX[(int)Module2X.transferGrip])        // 모듈2 Grip,Ungrip
                    module2PLC.PLCWrite("Y29", 1);
                else if (module2PLC._plc2DeviceX[(int)Module2X.transferUnGrip])
                    module2PLC.PLCWrite("Y29", 0);

                bStatusUpdateThread = true;     // Thread 다시 시작
                statusUpdateThread = new Thread(new ThreadStart(MainThread));
                statusUpdateThread.Start();
            }
        }

        private void InitTimer_Tick(object sender, EventArgs e)     // 이니셜용 타이머
        {

            switch (originStep)
            {
                case Step.STEP01:
                    if (originStep == Step.STEP01)
                    {
                        motionkit[(int)Axis.X].ServoOn();
                        motionkit[(int)Axis.Z].ServoOn();

                        bOneCycle = false;
                        bEquipmentAutoRun = false;
                        md1_OneCycle = false;
                        md2_OneCycle = false;
                        
                        originStep = Step.STEP02;

                    }
                    break;
                case Step.STEP02:   // 실린더 복귀
                    if (originStep == Step.STEP02)
                    {
                        module1PLC.PLCWrite("Y23", 0);  // 공급 실린더 후진
                        module1PLC.PLCWrite("Y24", 1);

                        module1PLC.PLCWrite("Y28", 0);  // 컨베이어 정지

                        // 모듈2 초기화
                        module2PLC.PLCWrite("Y2C", 0);  // 공급 실린더 업

                        module2PLC.PLCWrite("Y2A", 0);  // 공급 실린더 ccw
                        module2PLC.PLCWrite("Y2B", 1);

                        module2PLC.PLCWrite("Y23", 0);  // 제품 밀착 실린더 후진
                        module2PLC.PLCWrite("Y24", 1);

                        module2PLC.PLCWrite("Y27", 0);  // 이송 실린더 업
                        module2PLC.PLCWrite("Y28", 1);

                        module2PLC.PLCWrite("Y25", 0);  // 이송 실린더 Left
                        module2PLC.PLCWrite("Y26", 1);

                        module2PLC.PLCWrite("Y29", 0);  // 이송 실린더 Ungrip

                        originStep = Step.STEP03;
                    }
                    break;
                case Step.STEP03:   // 엑추에이터 복귀 확인
                    if (originStep == Step.STEP03)
                    {
                        if (module1PLC._plc1DeviceX[(int)Module1X.md1_SupplyCylinderBWD]
                            && !module1PLC._plc1DeviceY[(int)Module1Y.md1_conveyorOnOff]
                            && module2PLC._plc2DeviceX[(int)Module2X.productCylinderBWD] && module2PLC._plc2DeviceX[(int)Module2X.transferCylinderLeft]
                            && module2PLC._plc2DeviceX[(int)Module2X.transferCylinderUp] && module2PLC._plc2DeviceX[(int)Module2X.transferUnGrip]
                            && module2PLC._plc2DeviceX[(int)Module2X.supplyCylinderCCW] && module2PLC._plc2DeviceX[(int)Module2X.supplyCylinderUp])
                        {
                            originStep = Step.STEP04;
                        }
                    }
                    break;
                case Step.STEP04:
                    if (originStep == Step.STEP04)
                    {
                        // 서보
                        tb_rcv_Message.Text = motionkit.str;
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
                            originStep = Step.STEP05;
                        }
                    }
                    break;
                case Step.STEP05:
                    if (originStep == Step.STEP05)
                    {
                        bInitialze_Origin = true;
                        originStep = Step.STEP00;
                        RunSwitchInitial();
                        MessageBox.Show("Initialize Complete!");
                        InitTimer.Stop();
                    }
                    break;
                default:
                    break;
            }
        }

        private void RunSwitchInitial()
        {

            btn_Auto.BackColor = SystemColors.Control;
            for (int i = 0; i < Teach.sCartridge.Length; i++)
                Teach.sCartridge[i] = false;
            
            cmdPnp = CmdMsg.CHECK;
            // rptPnp = RptMsg.Ready            // Module1 Cartridge RptMsg
            module1_cmdPnp = CmdMsg.CHECK;      // Module1 Cartridge CmdPnp
            RunrptPnp = RptMsg.READY;           // Module1 내부 RptMsg, Module2에서도 사용함..?

            module1_runStep = Step.STEP00;      // Module1 Step 
            md1_OneCycle = false;
            module1_rptPnp = RptMsg.READY;      //  Module1 외부 RptMsg
            escapeFor = false;
            rptPnp = RptMsg.READY;              // 새로 추가

            module2_runStep = Step.STEP06;      // Module2 Step
            bModule2Run = false;                // Module2 연속동작 스위치
            module2_rptPnp = RptMsg.READY;      //  Module2 외부 RptMsg
            md2_OneCycle = false;

            oneCycleStep = Step.STEP00;         // 1Cycle Step
            bOneCycle = false;

            autoRun1 = CmdMsg.CHECK;            // cmdPnp로 대체 가능?
            autoRun2 = CmdMsg.CHECK;

            serverOneCycle = Step.STEP00;       // 1Cycle 서버 보고용 함수의 Step
            serverAutoRun = Step.STEP00;        // AutoRun 서버 보고용 함수의 Step
            bEquipmentAutoRun = false;          // 연속운전 스위치
            autoRunCartridgeCountTemp = 0;
            iProductINCount = 0;                // 투입 카운트 추가

            rptPnp_MD1_Pause = RptMsg.READY;
            cmdMsg_MD1_Pause = CmdMsg.CHECK;

            motionkit.rptPnp = RptMsg.READY;
            motionkit.stepPnp = Step.STEP00;

            // Pause, Stop, EMS
            bPAUSE = false;
            bSTOP = false;

            bMD1_StartSW = false;
            bMD2_StartSW = false;
        }

        private void EqupimentAutoRun()
        {
            module1_rptPnp = Module1_AutoRun(autoRun1);

            if (module1_rptPnp == RptMsg.READY && autoRun1 == CmdMsg.CHECK 
                && (!module2PLC._plc2DeviceX[(int)Module2X.productSensor]  || _bSensorPass_Temp)) // Sensor Pass 추가
            {
                autoRun1 = CmdMsg.START;
            }
            else if (module1_rptPnp == RptMsg.BUSY)
            {
                autoRun1 = CmdMsg.CHECK;
            }
            else if (module1_rptPnp == RptMsg.COMPLETE)
            {
                autoRun1 = CmdMsg.END;
            }
            else if (module1_rptPnp == RptMsg.READY && autoRun1 == CmdMsg.END)
            {
                autoRun1 = CmdMsg.CHECK;
                escapeFor = false;
                bAuto_Module1comp = true;
            }

            if (bAuto_Module1comp || bModule2Run)
            {
                module2_rptPnp = Module2_AutoRun(autoRun2);
                if (module2_rptPnp == RptMsg.READY && autoRun2 == CmdMsg.CHECK)
                {
                    autoRun2 = CmdMsg.START;

                }
                else if (module2_rptPnp == RptMsg.BUSY)
                {
                    autoRun2 = CmdMsg.CHECK;
                }
                else if (module2_rptPnp == RptMsg.COMPLETE)
                {
                    autoRun2 = CmdMsg.END;
                }
                else if (module2_rptPnp == RptMsg.READY && autoRun2 == CmdMsg.END)
                {
                    autoRun2 = CmdMsg.CHECK;
                    if (productOutCount >= autoRunCartridgeCountTemp)      // 카트리지 현재 남은 수량과 생산완료된 수량이 같으면 종료
                    {
                        bModule2Run = false;
                        bEquipmentAutoRun = false;
                    }
                }
            }
        }


        private void EQP_OneCycle()
        {
            switch (oneCycleStep)
            {
                case Step.STEP00:
                    if (module1_rptPnp == RptMsg.READY && module2_rptPnp == RptMsg.READY)
                    {
                        oneCycleStep = Step.STEP01;
                    }
                    break;
                case Step.STEP01:

                    module1_rptPnp = Module1_AutoRun(cmdPnp);

                    if (module1_rptPnp == RptMsg.READY && cmdPnp == CmdMsg.CHECK)
                    {
                        cmdPnp = CmdMsg.START;
                    }
                    else if (module1_rptPnp == RptMsg.BUSY)
                    {
                        cmdPnp = CmdMsg.CHECK;
                    }
                    else if (module1_rptPnp == RptMsg.COMPLETE)
                    {
                        cmdPnp = CmdMsg.END;
                    }
                    else if (module1_rptPnp == RptMsg.READY && cmdPnp == CmdMsg.END)
                    {
                        cmdPnp = CmdMsg.CHECK;
                        oneCycleStep = Step.STEP02;
                        module2_runStep = Step.STEP06;
                    }
                    break;
                case Step.STEP02:
                    if (oneCycleStep == Step.STEP02)
                    {
                        module2_rptPnp = Module2_AutoRun(cmdPnp);
                        if (module2_rptPnp == RptMsg.READY && cmdPnp == CmdMsg.CHECK)
                        {
                            cmdPnp = CmdMsg.START;
                        }
                        else if (module2_rptPnp == RptMsg.BUSY)
                        {
                            cmdPnp = CmdMsg.CHECK;
                        }
                        else if (module2_rptPnp == RptMsg.COMPLETE)
                        {
                            cmdPnp = CmdMsg.END;
                        }
                        else if (module2_rptPnp == RptMsg.READY && cmdPnp == CmdMsg.END)
                        {
                            cmdPnp = CmdMsg.CHECK;
                            bOneCycle = false;
                            escapeFor = false;
                            oneCycleStep = Step.STEP00;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        


        private void Module1_AutoRun_use()
        {
            module1_rptPnp = Module1_AutoRun(cmdPnp);

            if (module1_rptPnp == RptMsg.READY && cmdPnp == CmdMsg.CHECK)
            {
                cmdPnp = CmdMsg.START;
            }
            else if (module1_rptPnp == RptMsg.BUSY)
            {
                cmdPnp = CmdMsg.CHECK;
            }
            else if (module1_rptPnp == RptMsg.COMPLETE)
            {
                cmdPnp = CmdMsg.END;
            }
            else if (module1_rptPnp == RptMsg.READY && cmdPnp == CmdMsg.END)
            {
                cmdPnp = CmdMsg.CHECK;
                md1_OneCycle = false;
            }
        }

        private void Module2_AutoRun_use()
        {
            module2_rptPnp = Module2_AutoRun(cmdPnp);
            if (module2_rptPnp == RptMsg.READY && cmdPnp == CmdMsg.CHECK)
            {
                cmdPnp = CmdMsg.START;
            }
            else if (module2_rptPnp == RptMsg.BUSY)
            {
                cmdPnp = CmdMsg.CHECK;
            }
            else if (module2_rptPnp == RptMsg.COMPLETE)
            {
                cmdPnp = CmdMsg.END;
            }
            else if (module2_rptPnp == RptMsg.READY && cmdPnp == CmdMsg.END)
            {
                cmdPnp = CmdMsg.CHECK;
                md2_OneCycle = false;
            }
        }

        private RptMsg Module1_AutoRun(CmdMsg cmd)
        {
            bInitialze_Origin = false;

            if (bPAUSE)
            {
                if (module1_runStep == Step.STEP01)
                {
                    motionkit[(int)Axis.X].Stop();
                    motionkit[(int)Axis.Z].Stop();
                    rptPnp_MD1_Pause = RptMsg.READY;
                    cmdMsg_MD1_Pause = CmdMsg.START;
                    motionkit.stepPnp = Step.STEP00;
                    bPAUSE_Motionkit = true;
                }
                if (module1PLC._plc1DeviceY[(int)Module1Y.md1_conveyorOnOff] && (module1_runStep == Step.STEP04 || module1_runStep == Step.STEP05))
                {
                    module1PLC.PLCWrite("Y28", 0);
                }
                return RunrptPnp;
            }
            else if (!bPAUSE)
            {
                if (!module1PLC._plc1DeviceY[(int)Module1Y.md1_conveyorOnOff] && (module1_runStep == Step.STEP04 || module1_runStep == Step.STEP05))
                {
                    module1PLC.PLCWrite("Y28", 1);
                }

                if (bPAUSE_Motionkit && module1_runStep == Step.STEP01 && module1PLC._plc1DeviceX[(int)Module1X.md1_SupplyCylinderBWD])
                {
                    rptPnp_MD1_Pause = motionkit.CartridgeRun(iBefor_CartridgePos, cmdMsg_MD1_Pause);

                    if (rptPnp_MD1_Pause == RptMsg.READY && cmdMsg_MD1_Pause == CmdMsg.CHECK)
                    {
                        cmdMsg_MD1_Pause = CmdMsg.START;
                    }
                    else if (rptPnp_MD1_Pause == RptMsg.BUSY)
                    {
                        cmdMsg_MD1_Pause = CmdMsg.CHECK;
                    }
                    else if (rptPnp_MD1_Pause == RptMsg.COMPLETE)
                    {
                        cmdMsg_MD1_Pause = CmdMsg.END;
                    }
                    else if (rptPnp_MD1_Pause == RptMsg.READY && cmdMsg_MD1_Pause == CmdMsg.END)
                    {
                        cmdMsg_MD1_Pause = CmdMsg.CHECK;
                        if (!bSTOP) // Stop 확인 후 투입
                        {
                            bPAUSE_Motionkit = false;
                            motionkit.stepPnp = Step.STEP00;
                            module1_runStep = Step.STEP02;
                            rptPnp = RptMsg.READY;
                            module1_cmdPnp = CmdMsg.CHECK;
                        }
                    }
                    else if (bPAUSE_Motionkit)
                    {
                        return RunrptPnp;
                    }
                }
            }

            switch (module1_runStep)
            {
                case Step.STEP00:
                    if (cmd == CmdMsg.START && module1_runStep == Step.STEP00)
                    {
                        int count = Teach.sCartridge.Count(b => b == true);
                        if (count > 0)
                        {
                            RunrptPnp = RptMsg.BUSY;
                            module1_runStep = Step.STEP01;

                        }
                        else
                        {
                            module1_runStep = Step.STEP100;
                        }
                    }
                    break;
                case Step.STEP01:
                    if (module1_runStep == Step.STEP01)      // 카트리지 위치 이동
                    {
                        if (module1PLC._plc1DeviceX[(int)Module1X.md1_SupplyCylinderBWD])
                        {
                            for (int i = 0; i < Teach.sCartridge.Length; i++)
                            {
                                if (Teach.sCartridge[i] && !escapeFor)
                                {
                                    cartridgePos = i;
                                    Teach.sCartridge[i] = false;
                                    escapeFor = true;
                                }
                            }

                            rptPnp = motionkit.CartridgeRun(cartridgePos, module1_cmdPnp);
                            iBefor_CartridgePos = cartridgePos;

                            if (rptPnp == RptMsg.READY && module1_cmdPnp == CmdMsg.CHECK)
                            {
                                module1_cmdPnp = CmdMsg.START;
                            }
                            else if (rptPnp == RptMsg.BUSY)
                            {
                                module1_cmdPnp = CmdMsg.CHECK;
                            }
                            else if (rptPnp == RptMsg.COMPLETE)
                            {
                                module1_cmdPnp = CmdMsg.END;
                            }
                            else if (rptPnp == RptMsg.READY && module1_cmdPnp == CmdMsg.END)
                            {
                                module1_cmdPnp = CmdMsg.CHECK;
                                if (!bSTOP) // Stop 확인 후 투입
                                {
                                    module1_runStep = Step.STEP02;
                                }
                            }
                        }
                    }
                    break;
                case Step.STEP02:
                    if (module1_runStep == Step.STEP02)  // 공급 실린더 전진
                    {
                        if (cmdPnp == CmdMsg.CHECK && module1PLC._plc1DeviceX[(int)Module1X.md1_SupplyCylinderBWD])
                        {
                            module1PLC.PLCWrite("Y24", 0);
                            module1PLC.PLCWrite("Y23", 1);
                            module1_runStep = Step.STEP03;
                        }
                    }
                    break;
                case Step.STEP03:
                    if (module1_runStep == Step.STEP03) // 공급 실린더 후진
                    {
                        if (module1PLC._plc1DeviceX[(int)Module1X.md1_SupplyCylinderFWD])
                        {
                            module1PLC.PLCWrite("Y23", 0);
                            module1PLC.PLCWrite("Y24", 1);
                            iProductINCount++;
                            module1_runStep = Step.STEP04;
                        }
                    }
                    break;
                case Step.STEP04:
                    if (module1_runStep == Step.STEP04) // 컨베이어 동작
                    {
                        if (module1PLC._plc1DeviceX[(int)Module1X.md1_SupplyCylinderBWD])
                        {
                            module1PLC.PLCWrite("Y28", 1);
                            module1_runStep = Step.STEP05;
                        }
                    }
                    break;
                case Step.STEP05:
                    if (module1_runStep == Step.STEP05) // 컨베이어 정지, 제품 감지되자 마자 정지??
                    {
                        if (module1PLC._plc1DeviceY[(int)Module1Y.md1_conveyorOnOff] && (module2PLC._plc2DeviceX[(int)Module2X.productSensor] || _bSensorPass_Temp))
                        {
                            Thread.Sleep(1000);
                            module1PLC.PLCWrite("Y28", 0);
                            module1_runStep = Step.STEP100;
                        }
                    }
                    break;
                case Step.STEP100:
                    RunrptPnp = RptMsg.COMPLETE;
                    module1_runStep = Step.STEP101;
                    break;
                case Step.STEP101:
                    if (cmd == CmdMsg.END)
                    {
                        RunrptPnp = RptMsg.READY;
                        module1_runStep = Step.STEP00;
                    }
                    break;
                default:
                    break;
            }

            return RunrptPnp;
        }

        private RptMsg Module2_AutoRun(CmdMsg cmd)
        {
            bInitialze_Origin = false;

            if (bPAUSE)
            {
                return RunrptPnp;
            }

            switch (module2_runStep)
            {
                case Step.STEP06:
                    if (cmd == CmdMsg.START && module2_runStep == Step.STEP06) // 모듈2 공급실린더 하강
                    {
                        if (module2PLC._plc2DeviceX[(int)Module2X.productSensor] || _bSensorPass_Temp)
                        {
                            module2PLC.PLCWrite("Y2C", 1);
                            module2_runStep = Step.STEP07;
                            bModule2Run = true;     // 연속운전을 위한 스위치
                            bAuto_Module1comp = false;  // Module1 완료 신호 초기화
                        }
                    }
                    break;
                case Step.STEP07:
                    if (module2_runStep == Step.STEP07) // 모듈2 공급실린더 cw
                    {
                        if (module2PLC._plc2DeviceX[(int)Module2X.supplyCylinderDown] && module2PLC._plc2DeviceX[(int)Module2X.supplyCylinderCCW])
                        {
                            module2PLC.PLCWrite("Y2B", 0);
                            module2PLC.PLCWrite("Y2A", 1);
                            module2_runStep = Step.STEP08;
                        }
                    }
                    break;
                case Step.STEP08:
                    if (module2_runStep == Step.STEP08) // 모듈2 공급실린더 ccw
                    {
                        if (module2PLC._plc2DeviceX[(int)Module2X.supplyCylinderCW])
                        {
                            Thread.Sleep(1000);
                            module2PLC.PLCWrite("Y2A", 0);
                            module2PLC.PLCWrite("Y2B", 1);
                            module2_runStep = Step.STEP09;
                        }
                    }
                    break;
                case Step.STEP09:
                    if (module2_runStep == Step.STEP09) // 모듈2 공급실린더 상승
                    {
                        if (!module2PLC._plc2DeviceX[(int)Module2X.supplyCylinderCW] && module2PLC._plc2DeviceX[(int)Module2X.supplyCylinderCCW])
                        {
                            module2PLC.PLCWrite("Y2C", 0);
                            module2_runStep = Step.STEP10;
                        }
                    }
                    break;
                case Step.STEP10:
                    if (module2_runStep == Step.STEP10) // 모듈2 제품밀착 실린더 전진
                    {
                        if (module2PLC._plc2DeviceX[(int)Module2X.supplyCylinderUp] && module2PLC._plc2DeviceX[(int)Module2X.productCylinderBWD])
                        {
                            module2PLC.PLCWrite("Y24", 0);
                            module2PLC.PLCWrite("Y23", 1);
                            module2_runStep = Step.STEP11;
                        }
                    }
                    break;
                case Step.STEP11:
                    if (module2_runStep == Step.STEP11) // 모듈2 제품밀착 실린더 후진
                    {
                        if (module2PLC._plc2DeviceX[(int)Module2X.productCylinderFWD])
                        {
                            module2PLC.PLCWrite("Y23", 0);
                            module2PLC.PLCWrite("Y24", 1);
                            module2_runStep = Step.STEP12;
                        }
                    }
                    break;
                case Step.STEP12:
                    if (module2_runStep == Step.STEP12) // 모듈2 이송실린더 하강, 이송 실린더가 왼쪽으로 이동하는거 추가해야할까?
                    {
                        if (module2PLC._plc2DeviceX[(int)Module2X.productCylinderBWD]
                            && module2PLC._plc2DeviceX[(int)Module2X.supplyCylinderUp]
                            && module2PLC._plc2DeviceX[(int)Module2X.transferCylinderLeft]
                            && module2PLC._plc2DeviceX[(int)Module2X.transferUnGrip])
                        {
                            module2PLC.PLCWrite("Y28", 0);
                            module2PLC.PLCWrite("Y27", 1);
                            module2_runStep = Step.STEP13;
                        }
                    }
                    break;
                case Step.STEP13:
                    if (module2_runStep == Step.STEP13) // 모듈2 이송실린더 그립
                    {
                        if (module2PLC._plc2DeviceX[(int)Module2X.transferCylinderDown] && module2PLC._plc2DeviceX[(int)Module2X.transferUnGrip])
                        {
                            module2PLC.PLCWrite("Y29", 1);
                            module2_runStep = Step.STEP14;
                        }
                    }
                    break;
                case Step.STEP14:
                    if (module2_runStep == Step.STEP14) // 모듈2 이송실린더 상승
                    {
                        if (module2PLC._plc2DeviceX[(int)Module2X.transferGrip]
                            && module2PLC._plc2DeviceX[(int)Module2X.transferCylinderLeft]
                            && module2PLC._plc2DeviceX[(int)Module2X.transferCylinderDown])
                        {
                            module2PLC.PLCWrite("Y27", 0);
                            module2PLC.PLCWrite("Y28", 1);
                            module2_runStep = Step.STEP15;
                        }
                    }
                    break;
                case Step.STEP15:
                    if (module2_runStep == Step.STEP15) // 모듈2 이송실린더 Right 이동
                    {
                        if (module2PLC._plc2DeviceX[(int)Module2X.transferCylinderUp]
                            && module2PLC._plc2DeviceX[(int)Module2X.transferCylinderLeft])
                        {
                            module2PLC.PLCWrite("Y26", 0);
                            module2PLC.PLCWrite("Y25", 1);
                            module2_runStep = Step.STEP16;
                        }
                    }
                    break;
                case Step.STEP16:
                    if (module2_runStep == Step.STEP16) // 모듈2 이송실린더 Down
                    {
                        if (module2PLC._plc2DeviceX[(int)Module2X.transferCylinderRight] && module2PLC._plc2DeviceX[(int)Module2X.transferCylinderUp]
                            && _endAble == Endable.ON && !bSTOP)  // 후단 EndAble 신호 추가
                        {
                            module2PLC.PLCWrite("Y28", 0);
                            module2PLC.PLCWrite("Y27", 1);
                            module2_runStep = Step.STEP17;
                        }
                        else if (module2PLC._plc2DeviceX[(int)Module2X.transferCylinderRight] && module2PLC._plc2DeviceX[(int)Module2X.transferCylinderUp]
                                 && module2PLC._plc2DevicePanel[(int)ModulePanel.manual])  // 후단 EndAble 신호 추가
                        {
                            module2PLC.PLCWrite("Y28", 0);
                            module2PLC.PLCWrite("Y27", 1);
                            module2_runStep = Step.STEP17;
                        }
                    }
                    break;
                case Step.STEP17:
                    if (module2_runStep == Step.STEP17) // 모듈2 이송실린더 언그립
                    {
                        if (module2PLC._plc2DeviceX[(int)Module2X.transferCylinderDown] && module2PLC._plc2DeviceX[(int)Module2X.transferGrip])
                        {
                            module2PLC.PLCWrite("Y29", 0);
                            module2_runStep = Step.STEP18;
                        }
                    }
                    break;
                case Step.STEP18:   // 모듈2 이송실린더 상승
                    if (module2_runStep == Step.STEP18)
                    {
                        if (module2PLC._plc2DeviceX[(int)Module2X.transferCylinderDown] && module2PLC._plc2DeviceX[(int)Module2X.transferUnGrip])
                        {
                            module2PLC.PLCWrite("Y27", 0);
                            module2PLC.PLCWrite("Y28", 1);
                            module2_runStep = Step.STEP19;
                        }
                    }
                    break;
                case Step.STEP19:   // 모듈2 이송실린더 Left 이동
                    if (module2_runStep == Step.STEP19)
                    {
                        if (module2PLC._plc2DeviceX[(int)Module2X.transferCylinderRight] && module2PLC._plc2DeviceX[(int)Module2X.transferCylinderUp])
                        {
                            module2PLC.PLCWrite("Y25", 0);
                            module2PLC.PLCWrite("Y26", 1);
                            module2_runStep = Step.STEP20;
                        }
                    }
                    break;
                case Step.STEP20:
                    if (module2_runStep == Step.STEP20)
                    {
                        if (module2PLC._plc2DeviceX[(int)Module2X.transferCylinderLeft])
                        {
                            productOutCount++;
                            module2_runStep = Step.STEP100;
                        }
                    }
                    break;
                case Step.STEP100:
                    RunrptPnp = RptMsg.COMPLETE;
                    module2_runStep = Step.STEP101;
                    break;
                case Step.STEP101:
                    if (cmd == CmdMsg.END)
                    {
                        RunrptPnp = RptMsg.READY;
                        module2_runStep = Step.STEP06;
                    }
                    break;
                default:
                    break;
            }
            return RunrptPnp;
        }

        #endregion



        #region Form

        private void IOUpdate_Tick(object sender, EventArgs e)
        {

            if (module1PLC._plc1DevicePanel[(int)ModulePanel.start] || (bMD1_StartSW && bMD2_StartSW))
            {
                AutoRunCheckMethod();
            }

            // 자동운전과 수동운전 전환, Panel Auto 전환
            if (module1PLC._plc1DevicePanel[(int)ModulePanel.auto] && module2PLC._plc2DevicePanel[(int)ModulePanel.auto])   
            {
                btn_Auto.Enabled = true;
                btn_Auto.Text = "READY";
                btn_eqp_1cycle.Enabled = false;
                btn_module1_1cycle.Enabled = false;
                btn_module2_1cycle.Enabled = false;
                tb_mode.Text = "AUTO";
            }
            else
            {
                btn_Auto.Enabled = false;
                btn_Auto.Text = "자동운전";
            }

            // PAUSE
            if (bPAUSE)
            {
                btn_pause.BackColor = Color.Brown;
                tb_optmode.Text = "PAUSE";
            }
            else
            {
                btn_pause.BackColor = SystemColors.Control;
                if (_operationMode == Operationmode.RUN)
                {
                    tb_optmode.Text = "RUN";
                }
            }

            // STOP
            if (bSTOP)
            {
                btn_stop.BackColor = Color.Brown;
                tb_optmode.Text = "STOP";
            }
            else
            {
                btn_stop.BackColor = SystemColors.Control;
            }

            if (module1PLC._plc1DevicePanel[(int)ModulePanel.manual] && bMD1_StartSW)
            {
                md1_OneCycle = true;
            }

            if (module2PLC._plc2DevicePanel[(int)ModulePanel.manual] && bMD2_StartSW)
            {
                md2_OneCycle = true;
            }

            // Panel Manual 전환
            if (module1PLC._plc1DevicePanel[(int)ModulePanel.manual] && module2PLC._plc2DevicePanel[(int)ModulePanel.manual])   
            {
                btn_manual.Enabled = true;
                btn_manual.Text = "JOG 동작";
                btn_eqp_1cycle.Enabled = true;
                btn_module1_1cycle.Enabled = true;
                btn_module2_1cycle.Enabled = true;
                tb_mode.Text = "MANUAL";
            }
            else
            {
                btn_manual.Enabled = false;
                btn_manual.Text = "수동운전";
            }
            // 생산완료 카운트
            lb_Total.Text = productOutCount.ToString();
            tb_product.Text = productOutCount.ToString();

            // AUTO 상태
            if (bAutoRunReady && btn_Auto.Enabled == true)
            {
                btn_Auto.BackColor = Color.YellowGreen;
            }
            else
            {
                btn_Auto.BackColor = SystemColors.Control;
            }

            // 운전별 서버 보고용 함수
            SendToServer_OnCycleEqupiStatus();
            SendToServer_AutoRunEqupiStatus();
            
            if (module1PLC.IRet == 0 && module2PLC.IRet == 0)
            {
                if (!module1PLC._plc1DevicePanel[(int)ModulePanel.emo] || !module2PLC._plc2DevicePanel[(int)ModulePanel.emo])
                {
                    bEMS = true;
                }
            }

            // EMS 추가 필요
            if (bEMS)
            {
                EMS();
            }

            if (tcpClientNetWork != null)
            {
                if (tcpClientNetWork.connected)
                    ControlThreadChanged(tb_netstatus, "ON");
                else
                    ControlThreadChanged(tb_netstatus, "OFF");
            }

            // PLC, MMC 연결
            if (module1PLC.IRet == 0 && module2PLC.IRet == 0 && motionkit[0].SvrEnable && motionkit[1].SvrEnable)
            {
                btn_plc_status.BackColor = Color.YellowGreen;
                btn_plc_status.Text = "CONNECT";
            }
            else
            {
                btn_plc_status.BackColor = SystemColors.Control;
                btn_plc_status.Text = "DISCONNECT";
            }

            // 서버 연결상태 표시
            if (bServerConnect)
            {
                if (tcpClientNetWork.tcpClient.Client.Poll(0, SelectMode.SelectRead) && tcpClientNetWork.tcpClient.Client.Available == 0)
                {
                    tcpClientNetWork.bSendMessage = false;
                    tcpClientNetWork.thd_Network.Join();
                    tcpClientNetWork.thd_Receive.Join();
                    btn_iecs_status.BackColor = SystemColors.Control;
                    btn_iecs_status.Text = "OFFLINE";
                    tb_netstatus.Text = "OFF";
                    bServerConnect = false;
                }
                else
                {
                    btn_iecs_status.BackColor = Color.YellowGreen;
                    btn_iecs_status.Text = "IN-LINE";
                    tb_netstatus.Text = "ON";
                }
            }
            else
            {
                btn_iecs_status.BackColor = SystemColors.Control;
                btn_iecs_status.Text = "OFFLINE";
                tb_netstatus.Text = "OFF";
            }
            
            // Module1 Panel 상태표시
            if (module1PLC.IRet == 0)   
            {
                if (module1PLC._plc1DevicePanel[(int)ModulePanel.auto])   // 오토
                    btn_md1_auto.BackColor = Color.YellowGreen;
                else
                    btn_md1_auto.BackColor = SystemColors.Control;
                if (module1PLC._plc1DevicePanel[(int)ModulePanel.manual]) // 메뉴얼
                {
                    btn_md1_manual.BackColor = Color.YellowGreen;
                    tb_optmode.Text = "STOP";
                    tb_mode.Text = "MANUAL";
                }
                else
                    btn_md1_manual.BackColor = SystemColors.Control;
                if (module1PLC._plc1DevicePanel[(int)ModulePanel.emo])    // EMO
                    btn_md1_ems.BackColor = SystemColors.Control;
                else
                    btn_md1_ems.BackColor = Color.Red;
            }
            
            // Module2 Panel
            if (module2PLC.IRet == 0)   
            {
                if (module2PLC._plc2DevicePanel[(int)ModulePanel.auto] && module2PLC.IRet == 0)
                    btn_md2_auto.BackColor = Color.YellowGreen;
                else
                    btn_md2_auto.BackColor = SystemColors.Control;
                if (module2PLC._plc2DevicePanel[(int)ModulePanel.manual])
                { 
                    btn_md2_manual.BackColor = Color.YellowGreen;
                    tb_optmode.Text = "STOP";
                    tb_mode.Text = "MANUAL";
                }
                else
                    btn_md2_manual.BackColor = SystemColors.Control;
                if (module2PLC._plc2DevicePanel[(int)ModulePanel.emo])
                    btn_md2_ems.BackColor = SystemColors.Control;
                else
                    btn_md2_ems.BackColor = Color.Red;
            }
        }

        private void AutoRunCheckMethod()
        {
            if (bInitialze_Origin && Teach.sCartridge.Count(b => b == true) > 0 && bServerConnect)
            {
                bAutoRunReady = true;
                RunModeStatus(gb, "RUN");

                tb_commd.Text = "ABLE";         // 서버에 Ready 보고
                tb_startable.Text = "ON";
                tb_optmode.Text = "RUN";
                autoRunCartridgeCountTemp = Teach.sCartridge.Count(b => b == true) + productOutCount;
            }
            else if(!module1PLC._plc1DevicePanel[(int)ModulePanel.manual] || !module2PLC._plc2DevicePanel[(int)ModulePanel.manual])
            {
                MessageBox.Show($"Initialize : {bInitialze_Origin}, Product : {Teach.sCartridge.Count(b => b == true)}EA, Server연결 : {bServerConnect}");
            }
        }

        private void FormClosingMethod()
        {
            // Thread 종료
            try
            {
                bStatusUpdateThread = false;
                statusUpdateThread.Abort();
                module1PLC.bThdReadPLC = false;
                module2PLC.bThdReadPLC = false;
                module1PLC.Timer.Stop();
                module2PLC.Timer.Stop();
                motionkit[(int)Axis.X].ServoOff();
                motionkit[(int)Axis.Z].ServoOff();
                if (tcpClientNetWork != null && bServerConnect)
                {
                    tcpClientNetWork.bSendMessage = false;
                    tcpClientNetWork.thd_Network.Abort();
                    tcpClientNetWork.thd_Receive.Abort();
                }
            }
            catch (ThreadInterruptedException ex)
            {
                tcpClientNetWork.bSendMessage = false;
            }
            catch (ThreadAbortException ex)
            {
                tcpClientNetWork.bSendMessage = false;
            }
            catch (SocketException ex)
            {

            }
            catch (NullReferenceException ex)
            {

            }
        }

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
                        if (control.Tag.ToString() == num && control.Tag.ToString() == "RUN")
                        {
                            control.BackColor = Color.YellowGreen;
                        }
                        if (control.Tag.ToString() == num && control.Tag.ToString() == "STOP")
                        {
                            control.BackColor = Color.Brown;
                        }
                        if (control.Tag.ToString() == num && control.Tag.ToString() == "PAUSE")
                        {
                            control.BackColor = Color.Violet;
                        }
                        if (control.Tag.ToString() == num && control.Tag.ToString() == "EMS")
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
                    if (control.Tag.ToString() == num && control.Tag.ToString() == "EMS")
                    {
                        control.BackColor = Color.Red;
                    }
                    if (control.Tag.ToString() == num && control.Tag.ToString() == "PAUSE")
                    {
                        control.BackColor = Color.YellowGreen;
                    }
                    if (control.Tag.ToString() == num && control.Tag.ToString() == "STOP")
                    {
                        control.BackColor = Color.YellowGreen;
                    }
                    if (control.Tag.ToString() == num && control.Tag.ToString() == "RUN")
                    {
                        control.BackColor = Color.YellowGreen;
                    }
                }
            }
        }

        private void ButtonColor_Down(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.YellowGreen;
        }

        private void ButtonColor_Up(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = SystemColors.Control;
        }

        private void EQUIPMENT01_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormClosingMethod();
        }

        private void btn_SensorPass_MouseDown(object sender, MouseEventArgs e)
        {
            _bSensorPass_Temp = true;
        }

        private void btn_SensorPass_MouseUp(object sender, MouseEventArgs e)
        {
            _bSensorPass_Temp = false;
        }

        private void EQUIPMENT01_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Thread 종료
            statusUpdateThread.Join();
        }
        
        private void LoginPage()
        {
            // 로그인 페이지
            Login_Page login_Page = new Login_Page();
            login_Page.Location = new Point(((this.Width / 2) - (login_Page.Width / 2)), ((this.Height / 2) - (login_Page.Height / 2)));
            login_Page.ShowDialog();
            if (!login_Page.login_OkNG)
            {
                FormClosingMethod();
                statusUpdateThread.Join();
                Application.Exit();
            }
        }
        #endregion



    }
}



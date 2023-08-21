namespace PCPRO_실기
{
    partial class EQUIPMENT01
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_iecsPort = new System.Windows.Forms.TextBox();
            this.tb_iecsIPAddress = new System.Windows.Forms.TextBox();
            this.btn_iecs_disconnect = new System.Windows.Forms.Button();
            this.btn_iece_connect = new System.Windows.Forms.Button();
            this.btn_iecs_status = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gb_module1 = new System.Windows.Forms.GroupBox();
            this.btn_md1_ems = new System.Windows.Forms.Button();
            this.btn_md1_pause = new System.Windows.Forms.Button();
            this.btn_md1_stop = new System.Windows.Forms.Button();
            this.btn_md1_run = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gb_module2 = new System.Windows.Forms.GroupBox();
            this.btn_md2_ems = new System.Windows.Forms.Button();
            this.btn_md2_pause = new System.Windows.Forms.Button();
            this.btn_md2_stop = new System.Windows.Forms.Button();
            this.btn_md2_run = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btn_plc_disconnect = new System.Windows.Forms.Button();
            this.btn_plc_connect = new System.Windows.Forms.Button();
            this.btn_plc_status = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.lb_unstill = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.lb_still = new System.Windows.Forms.Label();
            this.btn_initialize = new System.Windows.Forms.Button();
            this.btn_dio = new System.Windows.Forms.Button();
            this.btn_logoff = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.btn_load_receive = new System.Windows.Forms.Button();
            this.btn_load_Send = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.tb_Message = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btn_ems = new System.Windows.Forms.Button();
            this.btn_module2_1cycle = new System.Windows.Forms.Button();
            this.btn_module1_1cycle = new System.Windows.Forms.Button();
            this.btn_md1_1cycle = new System.Windows.Forms.Button();
            this.btn_md1_manual = new System.Windows.Forms.Button();
            this.btn_md1_Auto = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.gb_equipmentStatus = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btn_servoTeach = new System.Windows.Forms.Button();
            this.InitTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gb_module1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gb_module2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.gb_equipmentStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.tb_iecsPort);
            this.groupBox3.Controls.Add(this.tb_iecsIPAddress);
            this.groupBox3.Controls.Add(this.btn_iecs_disconnect);
            this.groupBox3.Controls.Add(this.btn_iece_connect);
            this.groupBox3.Controls.Add(this.btn_iecs_status);
            this.groupBox3.Location = new System.Drawing.Point(837, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(270, 193);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "IECS 연결";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "SERVER PORT : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "SERVER IP : ";
            // 
            // tb_iecsPort
            // 
            this.tb_iecsPort.Location = new System.Drawing.Point(114, 161);
            this.tb_iecsPort.Name = "tb_iecsPort";
            this.tb_iecsPort.Size = new System.Drawing.Size(150, 21);
            this.tb_iecsPort.TabIndex = 3;
            // 
            // tb_iecsIPAddress
            // 
            this.tb_iecsIPAddress.Location = new System.Drawing.Point(114, 132);
            this.tb_iecsIPAddress.Name = "tb_iecsIPAddress";
            this.tb_iecsIPAddress.Size = new System.Drawing.Size(150, 21);
            this.tb_iecsIPAddress.TabIndex = 3;
            // 
            // btn_iecs_disconnect
            // 
            this.btn_iecs_disconnect.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_iecs_disconnect.Location = new System.Drawing.Point(147, 75);
            this.btn_iecs_disconnect.Name = "btn_iecs_disconnect";
            this.btn_iecs_disconnect.Size = new System.Drawing.Size(117, 44);
            this.btn_iecs_disconnect.TabIndex = 3;
            this.btn_iecs_disconnect.Tag = "1";
            this.btn_iecs_disconnect.Text = "연결 끊기";
            this.btn_iecs_disconnect.UseVisualStyleBackColor = true;
            this.btn_iecs_disconnect.Click += new System.EventHandler(this.BtnAction);
            this.btn_iecs_disconnect.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_iecs_disconnect.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_iece_connect
            // 
            this.btn_iece_connect.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_iece_connect.Location = new System.Drawing.Point(7, 76);
            this.btn_iece_connect.Name = "btn_iece_connect";
            this.btn_iece_connect.Size = new System.Drawing.Size(117, 44);
            this.btn_iece_connect.TabIndex = 3;
            this.btn_iece_connect.Tag = "0";
            this.btn_iece_connect.Text = "TCP/IP 연결";
            this.btn_iece_connect.UseVisualStyleBackColor = true;
            this.btn_iece_connect.Click += new System.EventHandler(this.BtnAction);
            this.btn_iece_connect.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_iece_connect.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_iecs_status
            // 
            this.btn_iecs_status.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_iecs_status.Location = new System.Drawing.Point(6, 20);
            this.btn_iecs_status.Name = "btn_iecs_status";
            this.btn_iecs_status.Size = new System.Drawing.Size(258, 49);
            this.btn_iecs_status.TabIndex = 0;
            this.btn_iecs_status.Text = "OFFLINE";
            this.btn_iecs_status.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gb_module1);
            this.groupBox1.Location = new System.Drawing.Point(282, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 203);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Module1 : Work Feeding";
            // 
            // gb_module1
            // 
            this.gb_module1.Controls.Add(this.btn_md1_ems);
            this.gb_module1.Controls.Add(this.btn_md1_pause);
            this.gb_module1.Controls.Add(this.btn_md1_stop);
            this.gb_module1.Controls.Add(this.btn_md1_run);
            this.gb_module1.Location = new System.Drawing.Point(7, 21);
            this.gb_module1.Name = "gb_module1";
            this.gb_module1.Size = new System.Drawing.Size(246, 172);
            this.gb_module1.TabIndex = 0;
            this.gb_module1.TabStop = false;
            this.gb_module1.Text = "운영 상태";
            // 
            // btn_md1_ems
            // 
            this.btn_md1_ems.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_md1_ems.Location = new System.Drawing.Point(124, 93);
            this.btn_md1_ems.Name = "btn_md1_ems";
            this.btn_md1_ems.Size = new System.Drawing.Size(112, 67);
            this.btn_md1_ems.TabIndex = 1;
            this.btn_md1_ems.TabStop = false;
            this.btn_md1_ems.Tag = "EMS";
            this.btn_md1_ems.Text = "EMS";
            this.btn_md1_ems.UseVisualStyleBackColor = true;
            this.btn_md1_ems.Click += new System.EventHandler(this.BtnAction);
            // 
            // btn_md1_pause
            // 
            this.btn_md1_pause.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_md1_pause.Location = new System.Drawing.Point(6, 93);
            this.btn_md1_pause.Name = "btn_md1_pause";
            this.btn_md1_pause.Size = new System.Drawing.Size(112, 67);
            this.btn_md1_pause.TabIndex = 1;
            this.btn_md1_pause.TabStop = false;
            this.btn_md1_pause.Tag = "PAUSE";
            this.btn_md1_pause.Text = "PAUSE";
            this.btn_md1_pause.UseVisualStyleBackColor = true;
            this.btn_md1_pause.Click += new System.EventHandler(this.BtnAction);
            // 
            // btn_md1_stop
            // 
            this.btn_md1_stop.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_md1_stop.Location = new System.Drawing.Point(124, 20);
            this.btn_md1_stop.Name = "btn_md1_stop";
            this.btn_md1_stop.Size = new System.Drawing.Size(112, 67);
            this.btn_md1_stop.TabIndex = 1;
            this.btn_md1_stop.TabStop = false;
            this.btn_md1_stop.Tag = "STOP";
            this.btn_md1_stop.Text = "STOP";
            this.btn_md1_stop.UseVisualStyleBackColor = true;
            this.btn_md1_stop.Click += new System.EventHandler(this.BtnAction);
            // 
            // btn_md1_run
            // 
            this.btn_md1_run.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_md1_run.Location = new System.Drawing.Point(6, 20);
            this.btn_md1_run.Name = "btn_md1_run";
            this.btn_md1_run.Size = new System.Drawing.Size(112, 67);
            this.btn_md1_run.TabIndex = 1;
            this.btn_md1_run.TabStop = false;
            this.btn_md1_run.Tag = "RUN";
            this.btn_md1_run.Text = "RUN";
            this.btn_md1_run.UseVisualStyleBackColor = true;
            this.btn_md1_run.Click += new System.EventHandler(this.BtnAction);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gb_module2);
            this.groupBox2.Location = new System.Drawing.Point(552, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(267, 203);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Module2 : Pick and Place Feeding Station";
            // 
            // gb_module2
            // 
            this.gb_module2.Controls.Add(this.btn_md2_ems);
            this.gb_module2.Controls.Add(this.btn_md2_pause);
            this.gb_module2.Controls.Add(this.btn_md2_stop);
            this.gb_module2.Controls.Add(this.btn_md2_run);
            this.gb_module2.Location = new System.Drawing.Point(10, 21);
            this.gb_module2.Name = "gb_module2";
            this.gb_module2.Size = new System.Drawing.Size(247, 172);
            this.gb_module2.TabIndex = 2;
            this.gb_module2.TabStop = false;
            this.gb_module2.Text = "운영 상태";
            // 
            // btn_md2_ems
            // 
            this.btn_md2_ems.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_md2_ems.Location = new System.Drawing.Point(124, 93);
            this.btn_md2_ems.Name = "btn_md2_ems";
            this.btn_md2_ems.Size = new System.Drawing.Size(112, 67);
            this.btn_md2_ems.TabIndex = 2;
            this.btn_md2_ems.TabStop = false;
            this.btn_md2_ems.Tag = "EMS";
            this.btn_md2_ems.Text = "EMS";
            this.btn_md2_ems.UseVisualStyleBackColor = true;
            // 
            // btn_md2_pause
            // 
            this.btn_md2_pause.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_md2_pause.Location = new System.Drawing.Point(6, 93);
            this.btn_md2_pause.Name = "btn_md2_pause";
            this.btn_md2_pause.Size = new System.Drawing.Size(112, 67);
            this.btn_md2_pause.TabIndex = 2;
            this.btn_md2_pause.TabStop = false;
            this.btn_md2_pause.Tag = "PAUSE";
            this.btn_md2_pause.Text = "PAUSE";
            this.btn_md2_pause.UseVisualStyleBackColor = true;
            // 
            // btn_md2_stop
            // 
            this.btn_md2_stop.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_md2_stop.Location = new System.Drawing.Point(124, 20);
            this.btn_md2_stop.Name = "btn_md2_stop";
            this.btn_md2_stop.Size = new System.Drawing.Size(112, 67);
            this.btn_md2_stop.TabIndex = 2;
            this.btn_md2_stop.TabStop = false;
            this.btn_md2_stop.Tag = "STOP";
            this.btn_md2_stop.Text = "STOP";
            this.btn_md2_stop.UseVisualStyleBackColor = true;
            // 
            // btn_md2_run
            // 
            this.btn_md2_run.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_md2_run.Location = new System.Drawing.Point(6, 20);
            this.btn_md2_run.Name = "btn_md2_run";
            this.btn_md2_run.Size = new System.Drawing.Size(112, 67);
            this.btn_md2_run.TabIndex = 2;
            this.btn_md2_run.TabStop = false;
            this.btn_md2_run.Tag = "RUN";
            this.btn_md2_run.Text = "RUN";
            this.btn_md2_run.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btn_plc_disconnect);
            this.groupBox5.Controls.Add(this.btn_plc_connect);
            this.groupBox5.Controls.Add(this.btn_plc_status);
            this.groupBox5.Location = new System.Drawing.Point(837, 212);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(270, 130);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "PLC/MMC 연결";
            // 
            // btn_plc_disconnect
            // 
            this.btn_plc_disconnect.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_plc_disconnect.Location = new System.Drawing.Point(147, 75);
            this.btn_plc_disconnect.Name = "btn_plc_disconnect";
            this.btn_plc_disconnect.Size = new System.Drawing.Size(117, 44);
            this.btn_plc_disconnect.TabIndex = 3;
            this.btn_plc_disconnect.Tag = "3";
            this.btn_plc_disconnect.Text = "연결 끊기";
            this.btn_plc_disconnect.UseVisualStyleBackColor = true;
            this.btn_plc_disconnect.Click += new System.EventHandler(this.BtnAction);
            this.btn_plc_disconnect.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_plc_disconnect.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_plc_connect
            // 
            this.btn_plc_connect.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_plc_connect.Location = new System.Drawing.Point(7, 76);
            this.btn_plc_connect.Name = "btn_plc_connect";
            this.btn_plc_connect.Size = new System.Drawing.Size(117, 44);
            this.btn_plc_connect.TabIndex = 3;
            this.btn_plc_connect.Tag = "2";
            this.btn_plc_connect.Text = "PLC/MMC  연결";
            this.btn_plc_connect.UseVisualStyleBackColor = true;
            this.btn_plc_connect.Click += new System.EventHandler(this.BtnAction);
            this.btn_plc_connect.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_plc_connect.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_plc_status
            // 
            this.btn_plc_status.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_plc_status.Location = new System.Drawing.Point(6, 20);
            this.btn_plc_status.Name = "btn_plc_status";
            this.btn_plc_status.Size = new System.Drawing.Size(258, 49);
            this.btn_plc_status.TabIndex = 0;
            this.btn_plc_status.Text = "OFFLINE";
            this.btn_plc_status.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox12);
            this.groupBox6.Controls.Add(this.groupBox11);
            this.groupBox6.Location = new System.Drawing.Point(837, 348);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(270, 112);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "생산 수량";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.lb_unstill);
            this.groupBox12.Location = new System.Drawing.Point(118, 20);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(103, 85);
            this.groupBox12.TabIndex = 0;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "비금속";
            // 
            // lb_unstill
            // 
            this.lb_unstill.AutoSize = true;
            this.lb_unstill.Font = new System.Drawing.Font("굴림", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_unstill.Location = new System.Drawing.Point(38, 32);
            this.lb_unstill.Name = "lb_unstill";
            this.lb_unstill.Size = new System.Drawing.Size(31, 29);
            this.lb_unstill.TabIndex = 0;
            this.lb_unstill.Text = "-";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.lb_still);
            this.groupBox11.Location = new System.Drawing.Point(9, 20);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(103, 85);
            this.groupBox11.TabIndex = 0;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "금속";
            // 
            // lb_still
            // 
            this.lb_still.AutoSize = true;
            this.lb_still.Font = new System.Drawing.Font("굴림", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_still.Location = new System.Drawing.Point(38, 32);
            this.lb_still.Name = "lb_still";
            this.lb_still.Size = new System.Drawing.Size(31, 29);
            this.lb_still.TabIndex = 0;
            this.lb_still.Text = "-";
            // 
            // btn_initialize
            // 
            this.btn_initialize.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_initialize.Location = new System.Drawing.Point(837, 614);
            this.btn_initialize.Name = "btn_initialize";
            this.btn_initialize.Size = new System.Drawing.Size(270, 82);
            this.btn_initialize.TabIndex = 3;
            this.btn_initialize.Tag = "6";
            this.btn_initialize.Text = "Initialize";
            this.btn_initialize.UseVisualStyleBackColor = true;
            this.btn_initialize.Click += new System.EventHandler(this.BtnAction);
            this.btn_initialize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_initialize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_dio
            // 
            this.btn_dio.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_dio.Location = new System.Drawing.Point(837, 466);
            this.btn_dio.Name = "btn_dio";
            this.btn_dio.Size = new System.Drawing.Size(132, 142);
            this.btn_dio.TabIndex = 3;
            this.btn_dio.Tag = "4";
            this.btn_dio.Text = "DIO";
            this.btn_dio.UseVisualStyleBackColor = true;
            this.btn_dio.Click += new System.EventHandler(this.BtnAction);
            this.btn_dio.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_dio.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_logoff
            // 
            this.btn_logoff.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_logoff.Location = new System.Drawing.Point(837, 702);
            this.btn_logoff.Name = "btn_logoff";
            this.btn_logoff.Size = new System.Drawing.Size(270, 82);
            this.btn_logoff.TabIndex = 3;
            this.btn_logoff.Tag = "7";
            this.btn_logoff.Text = "LOG OFF";
            this.btn_logoff.UseVisualStyleBackColor = true;
            this.btn_logoff.Click += new System.EventHandler(this.BtnAction);
            this.btn_logoff.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_logoff.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.button7);
            this.groupBox8.Controls.Add(this.btn_load_receive);
            this.groupBox8.Controls.Add(this.btn_load_Send);
            this.groupBox8.Controls.Add(this.btn_clear);
            this.groupBox8.Controls.Add(this.btn_save);
            this.groupBox8.Controls.Add(this.tb_Message);
            this.groupBox8.Location = new System.Drawing.Point(13, 364);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(806, 420);
            this.groupBox8.TabIndex = 4;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Message";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(82, 385);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(112, 23);
            this.button7.TabIndex = 2;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button7_MouseDown);
            // 
            // btn_load_receive
            // 
            this.btn_load_receive.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_load_receive.Location = new System.Drawing.Point(602, 372);
            this.btn_load_receive.Name = "btn_load_receive";
            this.btn_load_receive.Size = new System.Drawing.Size(96, 42);
            this.btn_load_receive.TabIndex = 1;
            this.btn_load_receive.TabStop = false;
            this.btn_load_receive.Tag = "11";
            this.btn_load_receive.Text = "Receive Log Load";
            this.btn_load_receive.UseVisualStyleBackColor = true;
            this.btn_load_receive.Click += new System.EventHandler(this.BtnAction);
            this.btn_load_receive.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_load_receive.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_load_Send
            // 
            this.btn_load_Send.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_load_Send.Location = new System.Drawing.Point(500, 372);
            this.btn_load_Send.Name = "btn_load_Send";
            this.btn_load_Send.Size = new System.Drawing.Size(96, 42);
            this.btn_load_Send.TabIndex = 1;
            this.btn_load_Send.TabStop = false;
            this.btn_load_Send.Tag = "10";
            this.btn_load_Send.Text = "Send Log Load";
            this.btn_load_Send.UseVisualStyleBackColor = true;
            this.btn_load_Send.Click += new System.EventHandler(this.BtnAction);
            this.btn_load_Send.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_load_Send.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_clear
            // 
            this.btn_clear.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_clear.Location = new System.Drawing.Point(704, 372);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(96, 42);
            this.btn_clear.TabIndex = 1;
            this.btn_clear.TabStop = false;
            this.btn_clear.Tag = "12";
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.BtnAction);
            this.btn_clear.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_clear.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_save.Location = new System.Drawing.Point(398, 372);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(96, 42);
            this.btn_save.TabIndex = 1;
            this.btn_save.TabStop = false;
            this.btn_save.Tag = "9";
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.BtnAction);
            this.btn_save.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_save.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // tb_Message
            // 
            this.tb_Message.Location = new System.Drawing.Point(7, 21);
            this.tb_Message.Multiline = true;
            this.tb_Message.Name = "tb_Message";
            this.tb_Message.Size = new System.Drawing.Size(793, 345);
            this.tb_Message.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.button6);
            this.groupBox7.Controls.Add(this.button5);
            this.groupBox7.Controls.Add(this.btn_ems);
            this.groupBox7.Controls.Add(this.btn_module2_1cycle);
            this.groupBox7.Controls.Add(this.btn_module1_1cycle);
            this.groupBox7.Controls.Add(this.btn_md1_1cycle);
            this.groupBox7.Controls.Add(this.btn_md1_manual);
            this.groupBox7.Controls.Add(this.btn_md1_Auto);
            this.groupBox7.Location = new System.Drawing.Point(13, 225);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(806, 133);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "운전 모드";
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button6.Location = new System.Drawing.Point(127, 20);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(115, 102);
            this.button6.TabIndex = 1;
            this.button6.TabStop = false;
            this.button6.Tag = "2";
            this.button6.Text = "STOP";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.BtnAction);
            this.button6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.button6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button5.Location = new System.Drawing.Point(248, 20);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(115, 102);
            this.button5.TabIndex = 1;
            this.button5.TabStop = false;
            this.button5.Tag = "3";
            this.button5.Text = "PAUSE";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.BtnAction);
            this.button5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.button5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_ems
            // 
            this.btn_ems.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_ems.Location = new System.Drawing.Point(681, 20);
            this.btn_ems.Name = "btn_ems";
            this.btn_ems.Size = new System.Drawing.Size(115, 102);
            this.btn_ems.TabIndex = 1;
            this.btn_ems.TabStop = false;
            this.btn_ems.Tag = "8";
            this.btn_ems.Text = "EMS";
            this.btn_ems.UseVisualStyleBackColor = true;
            this.btn_ems.Click += new System.EventHandler(this.BtnAction);
            this.btn_ems.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_ems.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_module2_1cycle
            // 
            this.btn_module2_1cycle.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_module2_1cycle.Location = new System.Drawing.Point(584, 73);
            this.btn_module2_1cycle.Name = "btn_module2_1cycle";
            this.btn_module2_1cycle.Size = new System.Drawing.Size(91, 49);
            this.btn_module2_1cycle.TabIndex = 1;
            this.btn_module2_1cycle.TabStop = false;
            this.btn_module2_1cycle.Tag = "7";
            this.btn_module2_1cycle.Text = "Module2 1CYCLE";
            this.btn_module2_1cycle.UseVisualStyleBackColor = true;
            this.btn_module2_1cycle.Click += new System.EventHandler(this.BtnAction);
            this.btn_module2_1cycle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_module2_1cycle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_module1_1cycle
            // 
            this.btn_module1_1cycle.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_module1_1cycle.Location = new System.Drawing.Point(490, 73);
            this.btn_module1_1cycle.Name = "btn_module1_1cycle";
            this.btn_module1_1cycle.Size = new System.Drawing.Size(91, 49);
            this.btn_module1_1cycle.TabIndex = 1;
            this.btn_module1_1cycle.TabStop = false;
            this.btn_module1_1cycle.Tag = "6";
            this.btn_module1_1cycle.Text = "Module1 1CYCLE";
            this.btn_module1_1cycle.UseVisualStyleBackColor = true;
            this.btn_module1_1cycle.Click += new System.EventHandler(this.BtnAction);
            this.btn_module1_1cycle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_module1_1cycle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_md1_1cycle
            // 
            this.btn_md1_1cycle.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_md1_1cycle.Location = new System.Drawing.Point(490, 20);
            this.btn_md1_1cycle.Name = "btn_md1_1cycle";
            this.btn_md1_1cycle.Size = new System.Drawing.Size(185, 49);
            this.btn_md1_1cycle.TabIndex = 1;
            this.btn_md1_1cycle.TabStop = false;
            this.btn_md1_1cycle.Tag = "5";
            this.btn_md1_1cycle.Text = "1회 운전";
            this.btn_md1_1cycle.UseVisualStyleBackColor = true;
            this.btn_md1_1cycle.Click += new System.EventHandler(this.BtnAction);
            this.btn_md1_1cycle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_md1_1cycle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_md1_manual
            // 
            this.btn_md1_manual.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_md1_manual.Location = new System.Drawing.Point(369, 20);
            this.btn_md1_manual.Name = "btn_md1_manual";
            this.btn_md1_manual.Size = new System.Drawing.Size(115, 102);
            this.btn_md1_manual.TabIndex = 1;
            this.btn_md1_manual.TabStop = false;
            this.btn_md1_manual.Tag = "4";
            this.btn_md1_manual.Text = "수동운전";
            this.btn_md1_manual.UseVisualStyleBackColor = true;
            this.btn_md1_manual.Click += new System.EventHandler(this.BtnAction);
            this.btn_md1_manual.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_md1_manual.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_md1_Auto
            // 
            this.btn_md1_Auto.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_md1_Auto.Location = new System.Drawing.Point(6, 20);
            this.btn_md1_Auto.Name = "btn_md1_Auto";
            this.btn_md1_Auto.Size = new System.Drawing.Size(115, 102);
            this.btn_md1_Auto.TabIndex = 1;
            this.btn_md1_Auto.TabStop = false;
            this.btn_md1_Auto.Tag = "1";
            this.btn_md1_Auto.Text = "자동운전";
            this.btn_md1_Auto.UseVisualStyleBackColor = true;
            this.btn_md1_Auto.Click += new System.EventHandler(this.BtnAction);
            this.btn_md1_Auto.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_md1_Auto.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.gb_equipmentStatus);
            this.groupBox9.Location = new System.Drawing.Point(13, 16);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(264, 203);
            this.groupBox9.TabIndex = 2;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "MAIN(EQUIPMENT)";
            // 
            // gb_equipmentStatus
            // 
            this.gb_equipmentStatus.Controls.Add(this.button1);
            this.gb_equipmentStatus.Controls.Add(this.button2);
            this.gb_equipmentStatus.Controls.Add(this.button3);
            this.gb_equipmentStatus.Controls.Add(this.button4);
            this.gb_equipmentStatus.Location = new System.Drawing.Point(7, 21);
            this.gb_equipmentStatus.Name = "gb_equipmentStatus";
            this.gb_equipmentStatus.Size = new System.Drawing.Size(246, 172);
            this.gb_equipmentStatus.TabIndex = 0;
            this.gb_equipmentStatus.TabStop = false;
            this.gb_equipmentStatus.Text = "운영 상태";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(124, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 67);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Tag = "EMS";
            this.button1.Text = "EMS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BtnAction);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.Location = new System.Drawing.Point(6, 93);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 67);
            this.button2.TabIndex = 0;
            this.button2.TabStop = false;
            this.button2.Tag = "PAUSE";
            this.button2.Text = "PAUSE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.BtnAction);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.Location = new System.Drawing.Point(124, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 67);
            this.button3.TabIndex = 0;
            this.button3.TabStop = false;
            this.button3.Tag = "STOP";
            this.button3.Text = "STOP";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.BtnAction);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button4.Location = new System.Drawing.Point(6, 20);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 67);
            this.button4.TabIndex = 0;
            this.button4.TabStop = false;
            this.button4.Tag = "RUN";
            this.button4.Text = "RUN";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.BtnAction);
            // 
            // btn_servoTeach
            // 
            this.btn_servoTeach.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_servoTeach.Location = new System.Drawing.Point(975, 466);
            this.btn_servoTeach.Name = "btn_servoTeach";
            this.btn_servoTeach.Size = new System.Drawing.Size(132, 142);
            this.btn_servoTeach.TabIndex = 3;
            this.btn_servoTeach.Tag = "5";
            this.btn_servoTeach.Text = "SERVO TEACH";
            this.btn_servoTeach.UseVisualStyleBackColor = true;
            this.btn_servoTeach.Click += new System.EventHandler(this.BtnAction);
            this.btn_servoTeach.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_servoTeach.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // InitTimer
            // 
            this.InitTimer.Tick += new System.EventHandler(this.InitTimer_Tick);
            // 
            // EQUIPMENT01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 824);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.btn_logoff);
            this.Controls.Add(this.btn_servoTeach);
            this.Controls.Add(this.btn_dio);
            this.Controls.Add(this.btn_initialize);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EQUIPMENT01";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "EQUIPMENT01";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EQUIPMENT01_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EQUIPMENT01_FormClosed);
            this.Load += new System.EventHandler(this.EQUIPMENT01_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.gb_module1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.gb_module2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.gb_equipmentStatus.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_iecs_status;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_iecs_disconnect;
        private System.Windows.Forms.Button btn_iece_connect;
        private System.Windows.Forms.GroupBox gb_module1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_md1_ems;
        private System.Windows.Forms.Button btn_md1_pause;
        private System.Windows.Forms.Button btn_md1_stop;
        private System.Windows.Forms.Button btn_md1_run;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btn_plc_disconnect;
        private System.Windows.Forms.Button btn_plc_connect;
        private System.Windows.Forms.Button btn_plc_status;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btn_initialize;
        private System.Windows.Forms.Button btn_dio;
        private System.Windows.Forms.Button btn_logoff;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox tb_Message;
        private System.Windows.Forms.Button btn_load_Send;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_load_receive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_iecsIPAddress;
        private System.Windows.Forms.GroupBox gb_module2;
        private System.Windows.Forms.Button btn_md2_ems;
        private System.Windows.Forms.Button btn_md2_pause;
        private System.Windows.Forms.Button btn_md2_stop;
        private System.Windows.Forms.Button btn_md2_run;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Label lb_unstill;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label lb_still;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_iecsPort;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btn_md1_1cycle;
        private System.Windows.Forms.Button btn_md1_manual;
        private System.Windows.Forms.Button btn_md1_Auto;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox gb_equipmentStatus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btn_module2_1cycle;
        private System.Windows.Forms.Button btn_module1_1cycle;
        private System.Windows.Forms.Button btn_servoTeach;
        private System.Windows.Forms.Button btn_ems;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Timer InitTimer;
    }
}


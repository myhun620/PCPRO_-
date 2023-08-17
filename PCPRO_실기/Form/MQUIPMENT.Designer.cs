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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_iecsIPAddress = new System.Windows.Forms.TextBox();
            this.btn_iecs_disconnect = new System.Windows.Forms.Button();
            this.btn_iece_connect = new System.Windows.Forms.Button();
            this.btn_iecs_status = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btn_md1_1cycle = new System.Windows.Forms.Button();
            this.btn_md1_manual = new System.Windows.Forms.Button();
            this.btn_md1_Auto = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_md1_ems = new System.Windows.Forms.Button();
            this.btn_md1_pause = new System.Windows.Forms.Button();
            this.btn_md1_stop = new System.Windows.Forms.Button();
            this.btn_md1_run = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btn_md2_1cycle = new System.Windows.Forms.Button();
            this.btn_md2_manual = new System.Windows.Forms.Button();
            this.btn_md2_Auto = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
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
            this.btn_load_receive = new System.Windows.Forms.Button();
            this.btn_load_Send = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.tb_Message = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.tb_iecsIPAddress);
            this.groupBox3.Controls.Add(this.btn_iecs_disconnect);
            this.groupBox3.Controls.Add(this.btn_iece_connect);
            this.groupBox3.Controls.Add(this.btn_iecs_status);
            this.groupBox3.Location = new System.Drawing.Point(837, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(270, 154);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "IECS 연결";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP ADDRESS : ";
            // 
            // tb_iecsIPAddress
            // 
            this.tb_iecsIPAddress.Location = new System.Drawing.Point(101, 125);
            this.tb_iecsIPAddress.Name = "tb_iecsIPAddress";
            this.tb_iecsIPAddress.Size = new System.Drawing.Size(163, 21);
            this.tb_iecsIPAddress.TabIndex = 3;
            // 
            // btn_iecs_disconnect
            // 
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
            this.btn_iecs_status.Location = new System.Drawing.Point(6, 20);
            this.btn_iecs_status.Name = "btn_iecs_status";
            this.btn_iecs_status.Size = new System.Drawing.Size(258, 49);
            this.btn_iecs_status.TabIndex = 0;
            this.btn_iecs_status.Text = "OFFLINE";
            this.btn_iecs_status.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 344);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Module1 : Work Feeding";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btn_md1_1cycle);
            this.groupBox7.Controls.Add(this.btn_md1_manual);
            this.groupBox7.Controls.Add(this.btn_md1_Auto);
            this.groupBox7.Location = new System.Drawing.Point(7, 199);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(387, 133);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "운전 모드";
            // 
            // btn_md1_1cycle
            // 
            this.btn_md1_1cycle.Location = new System.Drawing.Point(266, 20);
            this.btn_md1_1cycle.Name = "btn_md1_1cycle";
            this.btn_md1_1cycle.Size = new System.Drawing.Size(115, 102);
            this.btn_md1_1cycle.TabIndex = 1;
            this.btn_md1_1cycle.TabStop = false;
            this.btn_md1_1cycle.Tag = "7";
            this.btn_md1_1cycle.Text = "1회 운전";
            this.btn_md1_1cycle.UseVisualStyleBackColor = true;
            this.btn_md1_1cycle.Click += new System.EventHandler(this.BtnAction);
            this.btn_md1_1cycle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_md1_1cycle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_md1_manual
            // 
            this.btn_md1_manual.Location = new System.Drawing.Point(136, 20);
            this.btn_md1_manual.Name = "btn_md1_manual";
            this.btn_md1_manual.Size = new System.Drawing.Size(115, 102);
            this.btn_md1_manual.TabIndex = 1;
            this.btn_md1_manual.TabStop = false;
            this.btn_md1_manual.Tag = "6";
            this.btn_md1_manual.Text = "수동운전";
            this.btn_md1_manual.UseVisualStyleBackColor = true;
            this.btn_md1_manual.Click += new System.EventHandler(this.BtnAction);
            this.btn_md1_manual.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_md1_manual.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_md1_Auto
            // 
            this.btn_md1_Auto.Location = new System.Drawing.Point(6, 20);
            this.btn_md1_Auto.Name = "btn_md1_Auto";
            this.btn_md1_Auto.Size = new System.Drawing.Size(115, 102);
            this.btn_md1_Auto.TabIndex = 1;
            this.btn_md1_Auto.TabStop = false;
            this.btn_md1_Auto.Tag = "5";
            this.btn_md1_Auto.Text = "자동운전";
            this.btn_md1_Auto.UseVisualStyleBackColor = true;
            this.btn_md1_Auto.Click += new System.EventHandler(this.BtnAction);
            this.btn_md1_Auto.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_md1_Auto.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_md1_ems);
            this.groupBox4.Controls.Add(this.btn_md1_pause);
            this.groupBox4.Controls.Add(this.btn_md1_stop);
            this.groupBox4.Controls.Add(this.btn_md1_run);
            this.groupBox4.Location = new System.Drawing.Point(7, 21);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(387, 172);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "운영 상태";
            // 
            // btn_md1_ems
            // 
            this.btn_md1_ems.Location = new System.Drawing.Point(196, 93);
            this.btn_md1_ems.Name = "btn_md1_ems";
            this.btn_md1_ems.Size = new System.Drawing.Size(185, 67);
            this.btn_md1_ems.TabIndex = 1;
            this.btn_md1_ems.TabStop = false;
            this.btn_md1_ems.Tag = "4";
            this.btn_md1_ems.Text = "EMS";
            this.btn_md1_ems.UseVisualStyleBackColor = true;
            this.btn_md1_ems.Click += new System.EventHandler(this.BtnAction);
            // 
            // btn_md1_pause
            // 
            this.btn_md1_pause.Location = new System.Drawing.Point(6, 93);
            this.btn_md1_pause.Name = "btn_md1_pause";
            this.btn_md1_pause.Size = new System.Drawing.Size(185, 67);
            this.btn_md1_pause.TabIndex = 1;
            this.btn_md1_pause.TabStop = false;
            this.btn_md1_pause.Tag = "3";
            this.btn_md1_pause.Text = "PAUSE";
            this.btn_md1_pause.UseVisualStyleBackColor = true;
            this.btn_md1_pause.Click += new System.EventHandler(this.BtnAction);
            // 
            // btn_md1_stop
            // 
            this.btn_md1_stop.Location = new System.Drawing.Point(196, 20);
            this.btn_md1_stop.Name = "btn_md1_stop";
            this.btn_md1_stop.Size = new System.Drawing.Size(185, 67);
            this.btn_md1_stop.TabIndex = 1;
            this.btn_md1_stop.TabStop = false;
            this.btn_md1_stop.Tag = "2";
            this.btn_md1_stop.Text = "STOP";
            this.btn_md1_stop.UseVisualStyleBackColor = true;
            this.btn_md1_stop.Click += new System.EventHandler(this.BtnAction);
            // 
            // btn_md1_run
            // 
            this.btn_md1_run.Location = new System.Drawing.Point(6, 20);
            this.btn_md1_run.Name = "btn_md1_run";
            this.btn_md1_run.Size = new System.Drawing.Size(185, 67);
            this.btn_md1_run.TabIndex = 1;
            this.btn_md1_run.TabStop = false;
            this.btn_md1_run.Tag = "1";
            this.btn_md1_run.Text = "RUN";
            this.btn_md1_run.UseVisualStyleBackColor = true;
            this.btn_md1_run.Click += new System.EventHandler(this.BtnAction);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox9);
            this.groupBox2.Controls.Add(this.groupBox10);
            this.groupBox2.Location = new System.Drawing.Point(419, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 344);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Module2 : Pick and Place Feeding Station";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btn_md2_1cycle);
            this.groupBox9.Controls.Add(this.btn_md2_manual);
            this.groupBox9.Controls.Add(this.btn_md2_Auto);
            this.groupBox9.Location = new System.Drawing.Point(7, 199);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(387, 133);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "운전 모드";
            // 
            // btn_md2_1cycle
            // 
            this.btn_md2_1cycle.Location = new System.Drawing.Point(266, 20);
            this.btn_md2_1cycle.Name = "btn_md2_1cycle";
            this.btn_md2_1cycle.Size = new System.Drawing.Size(115, 102);
            this.btn_md2_1cycle.TabIndex = 2;
            this.btn_md2_1cycle.TabStop = false;
            this.btn_md2_1cycle.Tag = "7";
            this.btn_md2_1cycle.Text = "1회 운전";
            this.btn_md2_1cycle.UseVisualStyleBackColor = true;
            this.btn_md2_1cycle.Click += new System.EventHandler(this.BtnAction);
            this.btn_md2_1cycle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_md2_1cycle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_md2_manual
            // 
            this.btn_md2_manual.Location = new System.Drawing.Point(136, 20);
            this.btn_md2_manual.Name = "btn_md2_manual";
            this.btn_md2_manual.Size = new System.Drawing.Size(115, 102);
            this.btn_md2_manual.TabIndex = 2;
            this.btn_md2_manual.TabStop = false;
            this.btn_md2_manual.Tag = "6";
            this.btn_md2_manual.Text = "수동운전";
            this.btn_md2_manual.UseVisualStyleBackColor = true;
            this.btn_md2_manual.Click += new System.EventHandler(this.BtnAction);
            this.btn_md2_manual.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_md2_manual.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_md2_Auto
            // 
            this.btn_md2_Auto.Location = new System.Drawing.Point(6, 20);
            this.btn_md2_Auto.Name = "btn_md2_Auto";
            this.btn_md2_Auto.Size = new System.Drawing.Size(115, 102);
            this.btn_md2_Auto.TabIndex = 2;
            this.btn_md2_Auto.TabStop = false;
            this.btn_md2_Auto.Tag = "5";
            this.btn_md2_Auto.Text = "자동운전";
            this.btn_md2_Auto.UseVisualStyleBackColor = true;
            this.btn_md2_Auto.Click += new System.EventHandler(this.BtnAction);
            this.btn_md2_Auto.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_md2_Auto.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.btn_md2_ems);
            this.groupBox10.Controls.Add(this.btn_md2_pause);
            this.groupBox10.Controls.Add(this.btn_md2_stop);
            this.groupBox10.Controls.Add(this.btn_md2_run);
            this.groupBox10.Location = new System.Drawing.Point(7, 17);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(387, 172);
            this.groupBox10.TabIndex = 2;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "운영 상태";
            // 
            // btn_md2_ems
            // 
            this.btn_md2_ems.Location = new System.Drawing.Point(196, 93);
            this.btn_md2_ems.Name = "btn_md2_ems";
            this.btn_md2_ems.Size = new System.Drawing.Size(185, 67);
            this.btn_md2_ems.TabIndex = 2;
            this.btn_md2_ems.TabStop = false;
            this.btn_md2_ems.Tag = "4";
            this.btn_md2_ems.Text = "EMS";
            this.btn_md2_ems.UseVisualStyleBackColor = true;
            // 
            // btn_md2_pause
            // 
            this.btn_md2_pause.Location = new System.Drawing.Point(6, 93);
            this.btn_md2_pause.Name = "btn_md2_pause";
            this.btn_md2_pause.Size = new System.Drawing.Size(185, 67);
            this.btn_md2_pause.TabIndex = 2;
            this.btn_md2_pause.TabStop = false;
            this.btn_md2_pause.Tag = "3";
            this.btn_md2_pause.Text = "PAUSE";
            this.btn_md2_pause.UseVisualStyleBackColor = true;
            // 
            // btn_md2_stop
            // 
            this.btn_md2_stop.Location = new System.Drawing.Point(196, 20);
            this.btn_md2_stop.Name = "btn_md2_stop";
            this.btn_md2_stop.Size = new System.Drawing.Size(185, 67);
            this.btn_md2_stop.TabIndex = 2;
            this.btn_md2_stop.TabStop = false;
            this.btn_md2_stop.Tag = "2";
            this.btn_md2_stop.Text = "STOP";
            this.btn_md2_stop.UseVisualStyleBackColor = true;
            // 
            // btn_md2_run
            // 
            this.btn_md2_run.Location = new System.Drawing.Point(6, 20);
            this.btn_md2_run.Name = "btn_md2_run";
            this.btn_md2_run.Size = new System.Drawing.Size(185, 67);
            this.btn_md2_run.TabIndex = 2;
            this.btn_md2_run.TabStop = false;
            this.btn_md2_run.Tag = "1";
            this.btn_md2_run.Text = "RUN";
            this.btn_md2_run.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btn_plc_disconnect);
            this.groupBox5.Controls.Add(this.btn_plc_connect);
            this.groupBox5.Controls.Add(this.btn_plc_status);
            this.groupBox5.Location = new System.Drawing.Point(837, 173);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(270, 130);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "PLC/MMC 연결";
            // 
            // btn_plc_disconnect
            // 
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
            this.btn_plc_connect.Location = new System.Drawing.Point(7, 76);
            this.btn_plc_connect.Name = "btn_plc_connect";
            this.btn_plc_connect.Size = new System.Drawing.Size(117, 44);
            this.btn_plc_connect.TabIndex = 3;
            this.btn_plc_connect.Tag = "2";
            this.btn_plc_connect.Text = "PLC/MMC 연결";
            this.btn_plc_connect.UseVisualStyleBackColor = true;
            this.btn_plc_connect.Click += new System.EventHandler(this.BtnAction);
            this.btn_plc_connect.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_plc_connect.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_plc_status
            // 
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
            this.groupBox6.Location = new System.Drawing.Point(837, 309);
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
            this.btn_initialize.Location = new System.Drawing.Point(837, 427);
            this.btn_initialize.Name = "btn_initialize";
            this.btn_initialize.Size = new System.Drawing.Size(270, 115);
            this.btn_initialize.TabIndex = 3;
            this.btn_initialize.Tag = "4";
            this.btn_initialize.Text = "Initialize";
            this.btn_initialize.UseVisualStyleBackColor = true;
            this.btn_initialize.Click += new System.EventHandler(this.BtnAction);
            this.btn_initialize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_initialize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_dio
            // 
            this.btn_dio.Location = new System.Drawing.Point(837, 548);
            this.btn_dio.Name = "btn_dio";
            this.btn_dio.Size = new System.Drawing.Size(270, 115);
            this.btn_dio.TabIndex = 3;
            this.btn_dio.Tag = "5";
            this.btn_dio.Text = "DIO";
            this.btn_dio.UseVisualStyleBackColor = true;
            this.btn_dio.Click += new System.EventHandler(this.BtnAction);
            this.btn_dio.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_dio.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_logoff
            // 
            this.btn_logoff.Location = new System.Drawing.Point(837, 669);
            this.btn_logoff.Name = "btn_logoff";
            this.btn_logoff.Size = new System.Drawing.Size(270, 115);
            this.btn_logoff.TabIndex = 3;
            this.btn_logoff.Tag = "6";
            this.btn_logoff.Text = "LOG OFF";
            this.btn_logoff.UseVisualStyleBackColor = true;
            this.btn_logoff.Click += new System.EventHandler(this.BtnAction);
            this.btn_logoff.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_logoff.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // groupBox8
            // 
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
            // btn_load_receive
            // 
            this.btn_load_receive.Location = new System.Drawing.Point(602, 372);
            this.btn_load_receive.Name = "btn_load_receive";
            this.btn_load_receive.Size = new System.Drawing.Size(96, 42);
            this.btn_load_receive.TabIndex = 1;
            this.btn_load_receive.TabStop = false;
            this.btn_load_receive.Tag = "10";
            this.btn_load_receive.Text = "Receive Log Load";
            this.btn_load_receive.UseVisualStyleBackColor = true;
            this.btn_load_receive.Click += new System.EventHandler(this.BtnAction);
            this.btn_load_receive.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_load_receive.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_load_Send
            // 
            this.btn_load_Send.Location = new System.Drawing.Point(500, 372);
            this.btn_load_Send.Name = "btn_load_Send";
            this.btn_load_Send.Size = new System.Drawing.Size(96, 42);
            this.btn_load_Send.TabIndex = 1;
            this.btn_load_Send.TabStop = false;
            this.btn_load_Send.Tag = "9";
            this.btn_load_Send.Text = "Send Log Load";
            this.btn_load_Send.UseVisualStyleBackColor = true;
            this.btn_load_Send.Click += new System.EventHandler(this.BtnAction);
            this.btn_load_Send.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_load_Send.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(704, 372);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(96, 42);
            this.btn_clear.TabIndex = 1;
            this.btn_clear.TabStop = false;
            this.btn_clear.Tag = "11";
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.BtnAction);
            this.btn_clear.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_clear.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(398, 372);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(96, 42);
            this.btn_save.TabIndex = 1;
            this.btn_save.TabStop = false;
            this.btn_save.Tag = "8";
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
            // EQUIPMENT01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 824);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.btn_logoff);
            this.Controls.Add(this.btn_dio);
            this.Controls.Add(this.btn_initialize);
            this.Controls.Add(this.groupBox2);
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
            this.groupBox7.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_iecs_status;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_iecs_disconnect;
        private System.Windows.Forms.Button btn_iece_connect;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_md1_ems;
        private System.Windows.Forms.Button btn_md1_pause;
        private System.Windows.Forms.Button btn_md1_stop;
        private System.Windows.Forms.Button btn_md1_run;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btn_plc_disconnect;
        private System.Windows.Forms.Button btn_plc_connect;
        private System.Windows.Forms.Button btn_plc_status;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btn_md1_1cycle;
        private System.Windows.Forms.Button btn_md1_manual;
        private System.Windows.Forms.Button btn_md1_Auto;
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
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button btn_md2_1cycle;
        private System.Windows.Forms.Button btn_md2_manual;
        private System.Windows.Forms.Button btn_md2_Auto;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button btn_md2_ems;
        private System.Windows.Forms.Button btn_md2_pause;
        private System.Windows.Forms.Button btn_md2_stop;
        private System.Windows.Forms.Button btn_md2_run;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Label lb_unstill;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label lb_still;
    }
}


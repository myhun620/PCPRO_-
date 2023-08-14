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
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.btn_connect = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btn_1cycle = new System.Windows.Forms.Button();
            this.btn_manual = new System.Windows.Forms.Button();
            this.btn_Auto = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_ems = new System.Windows.Forms.Button();
            this.btn_pause = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_run = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
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
            this.groupBox5.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.tb_iecsIPAddress);
            this.groupBox3.Controls.Add(this.btn_disconnect);
            this.groupBox3.Controls.Add(this.btn_connect);
            this.groupBox3.Controls.Add(this.button1);
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
            // btn_disconnect
            // 
            this.btn_disconnect.Location = new System.Drawing.Point(147, 75);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(117, 44);
            this.btn_disconnect.TabIndex = 3;
            this.btn_disconnect.Tag = "1";
            this.btn_disconnect.Text = "연결 끊기";
            this.btn_disconnect.UseVisualStyleBackColor = true;
            this.btn_disconnect.Click += new System.EventHandler(this.BtnAction);
            this.btn_disconnect.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_disconnect.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(7, 76);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(117, 44);
            this.btn_connect.TabIndex = 3;
            this.btn_connect.Tag = "0";
            this.btn_connect.Text = "TCP/IP 연결";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.BtnAction);
            this.btn_connect.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_connect.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(258, 49);
            this.button1.TabIndex = 0;
            this.button1.Text = "OFFLINE";
            this.button1.UseVisualStyleBackColor = true;
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
            this.groupBox7.Controls.Add(this.btn_1cycle);
            this.groupBox7.Controls.Add(this.btn_manual);
            this.groupBox7.Controls.Add(this.btn_Auto);
            this.groupBox7.Location = new System.Drawing.Point(7, 199);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(387, 133);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "운전 모드";
            // 
            // btn_1cycle
            // 
            this.btn_1cycle.Location = new System.Drawing.Point(266, 20);
            this.btn_1cycle.Name = "btn_1cycle";
            this.btn_1cycle.Size = new System.Drawing.Size(115, 102);
            this.btn_1cycle.TabIndex = 1;
            this.btn_1cycle.TabStop = false;
            this.btn_1cycle.Tag = "7";
            this.btn_1cycle.Text = "1회 운전";
            this.btn_1cycle.UseVisualStyleBackColor = true;
            this.btn_1cycle.Click += new System.EventHandler(this.BtnAction);
            this.btn_1cycle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_1cycle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_manual
            // 
            this.btn_manual.Location = new System.Drawing.Point(136, 20);
            this.btn_manual.Name = "btn_manual";
            this.btn_manual.Size = new System.Drawing.Size(115, 102);
            this.btn_manual.TabIndex = 1;
            this.btn_manual.TabStop = false;
            this.btn_manual.Tag = "6";
            this.btn_manual.Text = "수동운전";
            this.btn_manual.UseVisualStyleBackColor = true;
            this.btn_manual.Click += new System.EventHandler(this.BtnAction);
            this.btn_manual.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_manual.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_Auto
            // 
            this.btn_Auto.Location = new System.Drawing.Point(6, 20);
            this.btn_Auto.Name = "btn_Auto";
            this.btn_Auto.Size = new System.Drawing.Size(115, 102);
            this.btn_Auto.TabIndex = 1;
            this.btn_Auto.TabStop = false;
            this.btn_Auto.Tag = "5";
            this.btn_Auto.Text = "자동운전";
            this.btn_Auto.UseVisualStyleBackColor = true;
            this.btn_Auto.Click += new System.EventHandler(this.BtnAction);
            this.btn_Auto.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_Auto.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_ems);
            this.groupBox4.Controls.Add(this.btn_pause);
            this.groupBox4.Controls.Add(this.btn_stop);
            this.groupBox4.Controls.Add(this.btn_run);
            this.groupBox4.Location = new System.Drawing.Point(7, 21);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(387, 172);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "운영 상태";
            // 
            // btn_ems
            // 
            this.btn_ems.Location = new System.Drawing.Point(196, 93);
            this.btn_ems.Name = "btn_ems";
            this.btn_ems.Size = new System.Drawing.Size(185, 67);
            this.btn_ems.TabIndex = 1;
            this.btn_ems.TabStop = false;
            this.btn_ems.Tag = "4";
            this.btn_ems.Text = "EMS";
            this.btn_ems.UseVisualStyleBackColor = true;
            this.btn_ems.Click += new System.EventHandler(this.BtnAction);
            // 
            // btn_pause
            // 
            this.btn_pause.Location = new System.Drawing.Point(6, 93);
            this.btn_pause.Name = "btn_pause";
            this.btn_pause.Size = new System.Drawing.Size(185, 67);
            this.btn_pause.TabIndex = 1;
            this.btn_pause.TabStop = false;
            this.btn_pause.Tag = "3";
            this.btn_pause.Text = "PAUSE";
            this.btn_pause.UseVisualStyleBackColor = true;
            this.btn_pause.Click += new System.EventHandler(this.BtnAction);
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(196, 20);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(185, 67);
            this.btn_stop.TabIndex = 1;
            this.btn_stop.TabStop = false;
            this.btn_stop.Tag = "2";
            this.btn_stop.Text = "STOP";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.BtnAction);
            // 
            // btn_run
            // 
            this.btn_run.Location = new System.Drawing.Point(6, 20);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(185, 67);
            this.btn_run.TabIndex = 1;
            this.btn_run.TabStop = false;
            this.btn_run.Tag = "1";
            this.btn_run.Text = "RUN";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.BtnAction);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(419, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 344);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Module2 : Pick and Place Feeding Station";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Controls.Add(this.button4);
            this.groupBox5.Location = new System.Drawing.Point(837, 173);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(270, 130);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "PLC/MMC 연결";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(147, 75);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 44);
            this.button2.TabIndex = 3;
            this.button2.Tag = "3";
            this.button2.Text = "연결 끊기";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.BtnAction);
            this.button2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.button2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(7, 76);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 44);
            this.button3.TabIndex = 3;
            this.button3.Tag = "2";
            this.button3.Text = "PLC/MMC 연결";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.BtnAction);
            this.button3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.button3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 20);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(258, 49);
            this.button4.TabIndex = 0;
            this.button4.Text = "OFFLINE";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Location = new System.Drawing.Point(837, 309);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(270, 112);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "생산 수량";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(837, 427);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(270, 115);
            this.button5.TabIndex = 3;
            this.button5.Tag = "4";
            this.button5.Text = "Teach";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.BtnAction);
            this.button5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.button5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(837, 548);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(270, 115);
            this.button6.TabIndex = 3;
            this.button6.Tag = "5";
            this.button6.Text = "DIO";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.BtnAction);
            this.button6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.button6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(837, 669);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(270, 115);
            this.button7.TabIndex = 3;
            this.button7.Tag = "6";
            this.button7.Text = "Initialize";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.BtnAction);
            this.button7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.button7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
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
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
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
            this.Load += new System.EventHandler(this.EQUIPMENT01_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_disconnect;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_ems;
        private System.Windows.Forms.Button btn_pause;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btn_1cycle;
        private System.Windows.Forms.Button btn_manual;
        private System.Windows.Forms.Button btn_Auto;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox tb_Message;
        private System.Windows.Forms.Button btn_load_Send;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_load_receive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_iecsIPAddress;
    }
}


namespace PCPRO_실기
{
    partial class Manual
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_md1_supplyCylinder_fwd = new System.Windows.Forms.Button();
            this.btn_md1_supplyCylinder_bwd = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_md1_conveyor_cw = new System.Windows.Forms.Button();
            this.btn_md1_conveyor_ccw = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_md1_axisZ_down = new System.Windows.Forms.Button();
            this.btn_md1_axisZ_up = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btn_md1_axisX_right = new System.Windows.Forms.Button();
            this.btn_md1_axisX_left = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btn_md2_transferCylinder_up = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btn_md2_itemCylinder_bwd = new System.Windows.Forms.Button();
            this.btn_md2_itemCylinder_fwd = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.btn_md2_transferCylinder_down = new System.Windows.Forms.Button();
            this.btn_md2_transferCylinder_left = new System.Windows.Forms.Button();
            this.btn_md2_transferCylinder_right = new System.Windows.Forms.Button();
            this.btn_md2_transferCylinder_ungrip = new System.Windows.Forms.Button();
            this.btn_md2_transferCylinder_grip = new System.Windows.Forms.Button();
            this.btn_md2_supplyCylinder_up = new System.Windows.Forms.Button();
            this.btn_md2_supplyCylinder_down = new System.Windows.Forms.Button();
            this.btn_md2_supplyCylinder_ccw = new System.Windows.Forms.Button();
            this.btn_md2_supplyCylinder_cw = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_md1_supplyCylinder_bwd);
            this.groupBox1.Controls.Add(this.btn_md1_supplyCylinder_fwd);
            this.groupBox1.Location = new System.Drawing.Point(6, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(115, 159);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "공급실린더";
            // 
            // btn_md1_supplyCylinder_fwd
            // 
            this.btn_md1_supplyCylinder_fwd.Location = new System.Drawing.Point(6, 20);
            this.btn_md1_supplyCylinder_fwd.Name = "btn_md1_supplyCylinder_fwd";
            this.btn_md1_supplyCylinder_fwd.Size = new System.Drawing.Size(103, 60);
            this.btn_md1_supplyCylinder_fwd.TabIndex = 0;
            this.btn_md1_supplyCylinder_fwd.Tag = "0";
            this.btn_md1_supplyCylinder_fwd.Text = "전진";
            this.btn_md1_supplyCylinder_fwd.UseVisualStyleBackColor = true;
            this.btn_md1_supplyCylinder_fwd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_md1_supplyCylinder_fwd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_md1_supplyCylinder_bwd
            // 
            this.btn_md1_supplyCylinder_bwd.Location = new System.Drawing.Point(6, 86);
            this.btn_md1_supplyCylinder_bwd.Name = "btn_md1_supplyCylinder_bwd";
            this.btn_md1_supplyCylinder_bwd.Size = new System.Drawing.Size(103, 60);
            this.btn_md1_supplyCylinder_bwd.TabIndex = 1;
            this.btn_md1_supplyCylinder_bwd.Tag = "1";
            this.btn_md1_supplyCylinder_bwd.Text = "후진";
            this.btn_md1_supplyCylinder_bwd.UseVisualStyleBackColor = true;
            this.btn_md1_supplyCylinder_bwd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_md1_supplyCylinder_bwd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_md1_conveyor_ccw);
            this.groupBox3.Controls.Add(this.btn_md1_conveyor_cw);
            this.groupBox3.Location = new System.Drawing.Point(127, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(115, 159);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " 컨베이어";
            // 
            // btn_md1_conveyor_cw
            // 
            this.btn_md1_conveyor_cw.Location = new System.Drawing.Point(6, 20);
            this.btn_md1_conveyor_cw.Name = "btn_md1_conveyor_cw";
            this.btn_md1_conveyor_cw.Size = new System.Drawing.Size(103, 60);
            this.btn_md1_conveyor_cw.TabIndex = 2;
            this.btn_md1_conveyor_cw.Tag = "2";
            this.btn_md1_conveyor_cw.Text = "작동";
            this.btn_md1_conveyor_cw.UseVisualStyleBackColor = true;
            this.btn_md1_conveyor_cw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_md1_conveyor_cw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_md1_conveyor_ccw
            // 
            this.btn_md1_conveyor_ccw.Location = new System.Drawing.Point(6, 86);
            this.btn_md1_conveyor_ccw.Name = "btn_md1_conveyor_ccw";
            this.btn_md1_conveyor_ccw.Size = new System.Drawing.Size(103, 60);
            this.btn_md1_conveyor_ccw.TabIndex = 3;
            this.btn_md1_conveyor_ccw.Tag = "3";
            this.btn_md1_conveyor_ccw.Text = "후진";
            this.btn_md1_conveyor_ccw.UseVisualStyleBackColor = true;
            this.btn_md1_conveyor_ccw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_md1_conveyor_ccw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 350);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Module1 : Work Feeding";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_md1_axisZ_down);
            this.groupBox4.Controls.Add(this.btn_md1_axisZ_up);
            this.groupBox4.Location = new System.Drawing.Point(6, 185);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(115, 159);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Z축";
            // 
            // btn_md1_axisZ_down
            // 
            this.btn_md1_axisZ_down.Location = new System.Drawing.Point(6, 86);
            this.btn_md1_axisZ_down.Name = "btn_md1_axisZ_down";
            this.btn_md1_axisZ_down.Size = new System.Drawing.Size(103, 60);
            this.btn_md1_axisZ_down.TabIndex = 5;
            this.btn_md1_axisZ_down.Tag = "5";
            this.btn_md1_axisZ_down.Text = "▼";
            this.btn_md1_axisZ_down.UseVisualStyleBackColor = true;
            this.btn_md1_axisZ_down.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_md1_axisZ_down.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_md1_axisZ_up
            // 
            this.btn_md1_axisZ_up.Location = new System.Drawing.Point(6, 20);
            this.btn_md1_axisZ_up.Name = "btn_md1_axisZ_up";
            this.btn_md1_axisZ_up.Size = new System.Drawing.Size(103, 60);
            this.btn_md1_axisZ_up.TabIndex = 4;
            this.btn_md1_axisZ_up.Tag = "4";
            this.btn_md1_axisZ_up.Text = "▲";
            this.btn_md1_axisZ_up.UseVisualStyleBackColor = true;
            this.btn_md1_axisZ_up.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_md1_axisZ_up.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btn_md1_axisX_right);
            this.groupBox5.Controls.Add(this.btn_md1_axisX_left);
            this.groupBox5.Location = new System.Drawing.Point(127, 254);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(230, 90);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "X축";
            // 
            // btn_md1_axisX_right
            // 
            this.btn_md1_axisX_right.Location = new System.Drawing.Point(115, 20);
            this.btn_md1_axisX_right.Name = "btn_md1_axisX_right";
            this.btn_md1_axisX_right.Size = new System.Drawing.Size(103, 60);
            this.btn_md1_axisX_right.TabIndex = 7;
            this.btn_md1_axisX_right.Tag = "7";
            this.btn_md1_axisX_right.Text = "▶";
            this.btn_md1_axisX_right.UseVisualStyleBackColor = true;
            this.btn_md1_axisX_right.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_md1_axisX_right.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_md1_axisX_left
            // 
            this.btn_md1_axisX_left.Location = new System.Drawing.Point(6, 20);
            this.btn_md1_axisX_left.Name = "btn_md1_axisX_left";
            this.btn_md1_axisX_left.Size = new System.Drawing.Size(103, 60);
            this.btn_md1_axisX_left.TabIndex = 6;
            this.btn_md1_axisX_left.Tag = "6";
            this.btn_md1_axisX_left.Text = "◀";
            this.btn_md1_axisX_left.UseVisualStyleBackColor = true;
            this.btn_md1_axisX_left.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_md1_axisX_left.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox8);
            this.groupBox6.Controls.Add(this.groupBox9);
            this.groupBox6.Controls.Add(this.groupBox10);
            this.groupBox6.Location = new System.Drawing.Point(12, 370);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(393, 350);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Module2 : Pick and Place Feeding Station";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btn_md2_transferCylinder_grip);
            this.groupBox8.Controls.Add(this.btn_md2_transferCylinder_ungrip);
            this.groupBox8.Controls.Add(this.btn_md2_transferCylinder_right);
            this.groupBox8.Controls.Add(this.btn_md2_transferCylinder_left);
            this.groupBox8.Controls.Add(this.btn_md2_transferCylinder_down);
            this.groupBox8.Controls.Add(this.btn_md2_transferCylinder_up);
            this.groupBox8.Location = new System.Drawing.Point(6, 185);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(381, 159);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "이송 실린더";
            // 
            // btn_md2_transferCylinder_up
            // 
            this.btn_md2_transferCylinder_up.Location = new System.Drawing.Point(91, 20);
            this.btn_md2_transferCylinder_up.Name = "btn_md2_transferCylinder_up";
            this.btn_md2_transferCylinder_up.Size = new System.Drawing.Size(72, 60);
            this.btn_md2_transferCylinder_up.TabIndex = 14;
            this.btn_md2_transferCylinder_up.Tag = "14";
            this.btn_md2_transferCylinder_up.Text = "UP";
            this.btn_md2_transferCylinder_up.UseVisualStyleBackColor = true;
            this.btn_md2_transferCylinder_up.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_md2_transferCylinder_up.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btn_md2_itemCylinder_bwd);
            this.groupBox9.Controls.Add(this.btn_md2_itemCylinder_fwd);
            this.groupBox9.Location = new System.Drawing.Point(266, 20);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(115, 159);
            this.groupBox9.TabIndex = 0;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "제품 밀착 실린더";
            // 
            // btn_md2_itemCylinder_bwd
            // 
            this.btn_md2_itemCylinder_bwd.Location = new System.Drawing.Point(6, 86);
            this.btn_md2_itemCylinder_bwd.Name = "btn_md2_itemCylinder_bwd";
            this.btn_md2_itemCylinder_bwd.Size = new System.Drawing.Size(103, 60);
            this.btn_md2_itemCylinder_bwd.TabIndex = 13;
            this.btn_md2_itemCylinder_bwd.Tag = "13";
            this.btn_md2_itemCylinder_bwd.Text = "후진";
            this.btn_md2_itemCylinder_bwd.UseVisualStyleBackColor = true;
            this.btn_md2_itemCylinder_bwd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_md2_itemCylinder_bwd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_md2_itemCylinder_fwd
            // 
            this.btn_md2_itemCylinder_fwd.Location = new System.Drawing.Point(6, 20);
            this.btn_md2_itemCylinder_fwd.Name = "btn_md2_itemCylinder_fwd";
            this.btn_md2_itemCylinder_fwd.Size = new System.Drawing.Size(103, 60);
            this.btn_md2_itemCylinder_fwd.TabIndex = 12;
            this.btn_md2_itemCylinder_fwd.Tag = "12";
            this.btn_md2_itemCylinder_fwd.Text = "전진";
            this.btn_md2_itemCylinder_fwd.UseVisualStyleBackColor = true;
            this.btn_md2_itemCylinder_fwd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_md2_itemCylinder_fwd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.btn_md2_supplyCylinder_cw);
            this.groupBox10.Controls.Add(this.btn_md2_supplyCylinder_ccw);
            this.groupBox10.Controls.Add(this.btn_md2_supplyCylinder_down);
            this.groupBox10.Controls.Add(this.btn_md2_supplyCylinder_up);
            this.groupBox10.Location = new System.Drawing.Point(6, 20);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(246, 159);
            this.groupBox10.TabIndex = 0;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "공급실린더";
            // 
            // btn_md2_transferCylinder_down
            // 
            this.btn_md2_transferCylinder_down.Location = new System.Drawing.Point(91, 86);
            this.btn_md2_transferCylinder_down.Name = "btn_md2_transferCylinder_down";
            this.btn_md2_transferCylinder_down.Size = new System.Drawing.Size(72, 60);
            this.btn_md2_transferCylinder_down.TabIndex = 0;
            this.btn_md2_transferCylinder_down.Text = "DOWN";
            this.btn_md2_transferCylinder_down.UseVisualStyleBackColor = true;
            this.btn_md2_transferCylinder_down.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_md2_transferCylinder_down.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_md2_transferCylinder_left
            // 
            this.btn_md2_transferCylinder_left.Location = new System.Drawing.Point(13, 86);
            this.btn_md2_transferCylinder_left.Name = "btn_md2_transferCylinder_left";
            this.btn_md2_transferCylinder_left.Size = new System.Drawing.Size(72, 60);
            this.btn_md2_transferCylinder_left.TabIndex = 15;
            this.btn_md2_transferCylinder_left.Tag = "15";
            this.btn_md2_transferCylinder_left.Text = "LEFT";
            this.btn_md2_transferCylinder_left.UseVisualStyleBackColor = true;
            this.btn_md2_transferCylinder_left.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_md2_transferCylinder_left.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_md2_transferCylinder_right
            // 
            this.btn_md2_transferCylinder_right.Location = new System.Drawing.Point(169, 86);
            this.btn_md2_transferCylinder_right.Name = "btn_md2_transferCylinder_right";
            this.btn_md2_transferCylinder_right.Size = new System.Drawing.Size(72, 60);
            this.btn_md2_transferCylinder_right.TabIndex = 16;
            this.btn_md2_transferCylinder_right.Tag = "16";
            this.btn_md2_transferCylinder_right.Text = "RIGHT";
            this.btn_md2_transferCylinder_right.UseVisualStyleBackColor = true;
            this.btn_md2_transferCylinder_right.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_md2_transferCylinder_right.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_md2_transferCylinder_ungrip
            // 
            this.btn_md2_transferCylinder_ungrip.Location = new System.Drawing.Point(303, 20);
            this.btn_md2_transferCylinder_ungrip.Name = "btn_md2_transferCylinder_ungrip";
            this.btn_md2_transferCylinder_ungrip.Size = new System.Drawing.Size(72, 60);
            this.btn_md2_transferCylinder_ungrip.TabIndex = 18;
            this.btn_md2_transferCylinder_ungrip.Tag = "18";
            this.btn_md2_transferCylinder_ungrip.Text = "UNGRIP";
            this.btn_md2_transferCylinder_ungrip.UseVisualStyleBackColor = true;
            this.btn_md2_transferCylinder_ungrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_md2_transferCylinder_ungrip.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_md2_transferCylinder_grip
            // 
            this.btn_md2_transferCylinder_grip.Location = new System.Drawing.Point(225, 20);
            this.btn_md2_transferCylinder_grip.Name = "btn_md2_transferCylinder_grip";
            this.btn_md2_transferCylinder_grip.Size = new System.Drawing.Size(72, 60);
            this.btn_md2_transferCylinder_grip.TabIndex = 17;
            this.btn_md2_transferCylinder_grip.Tag = "17";
            this.btn_md2_transferCylinder_grip.Text = "GRIP";
            this.btn_md2_transferCylinder_grip.UseVisualStyleBackColor = true;
            this.btn_md2_transferCylinder_grip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_md2_transferCylinder_grip.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_md2_supplyCylinder_up
            // 
            this.btn_md2_supplyCylinder_up.Location = new System.Drawing.Point(86, 20);
            this.btn_md2_supplyCylinder_up.Name = "btn_md2_supplyCylinder_up";
            this.btn_md2_supplyCylinder_up.Size = new System.Drawing.Size(72, 60);
            this.btn_md2_supplyCylinder_up.TabIndex = 8;
            this.btn_md2_supplyCylinder_up.Tag = "8";
            this.btn_md2_supplyCylinder_up.Text = "UP";
            this.btn_md2_supplyCylinder_up.UseVisualStyleBackColor = true;
            this.btn_md2_supplyCylinder_up.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_md2_supplyCylinder_up.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_md2_supplyCylinder_down
            // 
            this.btn_md2_supplyCylinder_down.Location = new System.Drawing.Point(86, 86);
            this.btn_md2_supplyCylinder_down.Name = "btn_md2_supplyCylinder_down";
            this.btn_md2_supplyCylinder_down.Size = new System.Drawing.Size(72, 60);
            this.btn_md2_supplyCylinder_down.TabIndex = 9;
            this.btn_md2_supplyCylinder_down.Tag = "9";
            this.btn_md2_supplyCylinder_down.Text = "DOWN";
            this.btn_md2_supplyCylinder_down.UseVisualStyleBackColor = true;
            this.btn_md2_supplyCylinder_down.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_md2_supplyCylinder_down.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_md2_supplyCylinder_ccw
            // 
            this.btn_md2_supplyCylinder_ccw.Location = new System.Drawing.Point(8, 86);
            this.btn_md2_supplyCylinder_ccw.Name = "btn_md2_supplyCylinder_ccw";
            this.btn_md2_supplyCylinder_ccw.Size = new System.Drawing.Size(72, 60);
            this.btn_md2_supplyCylinder_ccw.TabIndex = 10;
            this.btn_md2_supplyCylinder_ccw.Tag = "10";
            this.btn_md2_supplyCylinder_ccw.Text = "CCW";
            this.btn_md2_supplyCylinder_ccw.UseVisualStyleBackColor = true;
            this.btn_md2_supplyCylinder_ccw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_md2_supplyCylinder_ccw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // btn_md2_supplyCylinder_cw
            // 
            this.btn_md2_supplyCylinder_cw.Location = new System.Drawing.Point(164, 86);
            this.btn_md2_supplyCylinder_cw.Name = "btn_md2_supplyCylinder_cw";
            this.btn_md2_supplyCylinder_cw.Size = new System.Drawing.Size(72, 60);
            this.btn_md2_supplyCylinder_cw.TabIndex = 11;
            this.btn_md2_supplyCylinder_cw.Tag = "11";
            this.btn_md2_supplyCylinder_cw.Text = "CW";
            this.btn_md2_supplyCylinder_cw.UseVisualStyleBackColor = true;
            this.btn_md2_supplyCylinder_cw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Down);
            this.btn_md2_supplyCylinder_cw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonColor_Up);
            // 
            // Manual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 732);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Manual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Manual";
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_md1_supplyCylinder_bwd;
        private System.Windows.Forms.Button btn_md1_supplyCylinder_fwd;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_md1_conveyor_ccw;
        private System.Windows.Forms.Button btn_md1_conveyor_cw;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btn_md1_axisX_right;
        private System.Windows.Forms.Button btn_md1_axisX_left;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_md1_axisZ_down;
        private System.Windows.Forms.Button btn_md1_axisZ_up;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btn_md2_transferCylinder_grip;
        private System.Windows.Forms.Button btn_md2_transferCylinder_ungrip;
        private System.Windows.Forms.Button btn_md2_transferCylinder_right;
        private System.Windows.Forms.Button btn_md2_transferCylinder_left;
        private System.Windows.Forms.Button btn_md2_transferCylinder_down;
        private System.Windows.Forms.Button btn_md2_transferCylinder_up;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button btn_md2_itemCylinder_bwd;
        private System.Windows.Forms.Button btn_md2_itemCylinder_fwd;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button btn_md2_supplyCylinder_cw;
        private System.Windows.Forms.Button btn_md2_supplyCylinder_ccw;
        private System.Windows.Forms.Button btn_md2_supplyCylinder_down;
        private System.Windows.Forms.Button btn_md2_supplyCylinder_up;
    }
}
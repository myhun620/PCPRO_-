namespace PCPRO_실기
{
    partial class Login_Page
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_loginID = new System.Windows.Forms.TextBox();
            this.tb_passWord = new System.Windows.Forms.TextBox();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "계정 : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password : ";
            // 
            // tb_loginID
            // 
            this.tb_loginID.Location = new System.Drawing.Point(116, 17);
            this.tb_loginID.Name = "tb_loginID";
            this.tb_loginID.Size = new System.Drawing.Size(100, 21);
            this.tb_loginID.TabIndex = 1;
            this.tb_loginID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_passWord_KeyDown);
            // 
            // tb_passWord
            // 
            this.tb_passWord.Location = new System.Drawing.Point(116, 44);
            this.tb_passWord.Name = "tb_passWord";
            this.tb_passWord.PasswordChar = '*';
            this.tb_passWord.Size = new System.Drawing.Size(100, 21);
            this.tb_passWord.TabIndex = 2;
            this.tb_passWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_passWord_KeyDown);
            // 
            // btn_confirm
            // 
            this.btn_confirm.Location = new System.Drawing.Point(22, 81);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(233, 48);
            this.btn_confirm.TabIndex = 3;
            this.btn_confirm.Text = "확인";
            this.btn_confirm.UseVisualStyleBackColor = true;
            this.btn_confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            this.btn_confirm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_passWord_KeyDown);
            // 
            // Login_Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 141);
            this.Controls.Add(this.btn_confirm);
            this.Controls.Add(this.tb_passWord);
            this.Controls.Add(this.tb_loginID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(283, 180);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(283, 180);
            this.Name = "Login_Page";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Login_Page";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_passWord_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_loginID;
        private System.Windows.Forms.TextBox tb_passWord;
        private System.Windows.Forms.Button btn_confirm;
    }
}
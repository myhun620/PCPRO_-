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
            this.btn_fwd = new System.Windows.Forms.Button();
            this.btn_bwd = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_bwd);
            this.groupBox1.Controls.Add(this.btn_fwd);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(115, 159);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "공급실린더";
            // 
            // btn_fwd
            // 
            this.btn_fwd.Location = new System.Drawing.Point(6, 20);
            this.btn_fwd.Name = "btn_fwd";
            this.btn_fwd.Size = new System.Drawing.Size(103, 60);
            this.btn_fwd.TabIndex = 0;
            this.btn_fwd.Text = "전진";
            this.btn_fwd.UseVisualStyleBackColor = true;
            // 
            // btn_bwd
            // 
            this.btn_bwd.Location = new System.Drawing.Point(6, 86);
            this.btn_bwd.Name = "btn_bwd";
            this.btn_bwd.Size = new System.Drawing.Size(103, 60);
            this.btn_bwd.TabIndex = 1;
            this.btn_bwd.Text = "후진";
            this.btn_bwd.UseVisualStyleBackColor = true;
            // 
            // Manual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 565);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Manual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Manual";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_bwd;
        private System.Windows.Forms.Button btn_fwd;
    }
}
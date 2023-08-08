using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCPRO_실기
{
    public partial class EQUIPMENT01 : Form
    {
        public EQUIPMENT01()
        {
            InitializeComponent();
            // WindowState = FormWindowState.Maximized; // form 최대 사이즈 적용
        }

        private void EQUIPMENT01_Load(object sender, EventArgs e)
        {
            //// 로그인 페이지
            //Login_Page login_Page = new Login_Page();
            //login_Page.ShowDialog();
            //if (!login_Page.login_OkNG)
            //{
            //    Application.Exit();
            //}
        }

        private void BtnAction(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int Tag = int.Parse(btn.Tag.ToString());
            int tabIndex = btn.TabIndex;


            TestResultTextBox(Tag.ToString() + ", " + btn.TabIndex.ToString());


        }

        private void TestResultTextBox(string msg)
        {
            tb_Module1.AppendText(msg);
        }
    }
}

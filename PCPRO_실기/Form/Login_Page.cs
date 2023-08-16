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
    public partial class Login_Page : Form
    {
        const string loginID = "admin";
        const string passWord = "1234";
        public bool login_OkNG;
        public Login_Page()
        {
            InitializeComponent();
            login_OkNG = false;
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_loginID.Text == loginID && tb_passWord.Text == passWord)
                {
                    login_OkNG = true;
                    this.Close();
                }
                else
                {
                    login_OkNG = false;
                    MessageBox.Show("계정 또는 비밀번호가 틀렸습니다.");
                }
            }
            catch (Exception)
            {
                tb_loginID.Text = "";
                tb_passWord.Text = "";
            }
        }

        private void tb_passWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (tb_loginID.Text == loginID && tb_passWord.Text == passWord)
                    {
                        login_OkNG = true;
                        this.Close();
                    }
                    else
                    {
                        login_OkNG = false;
                        MessageBox.Show("계정 또는 비밀번호가 틀렸습니다.");
                    }
                }
                catch (Exception)
                {
                    tb_loginID.Text = "";
                    tb_passWord.Text = "";
                }
            }
        }
    }
}

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
    public partial class Teach : Form
    {
        public bool[] Cartridge = new bool[25];
        static public bool[] sCartridge = new bool[25];

        public Teach()
        {
            InitializeComponent();
        }

        private void CartridgeChoice(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int tag = int.Parse(btn.Tag.ToString());

            for (int i = 0; i < Cartridge.Length; i++)
            {
                if (tag == i || sCartridge[i])
                {
                    Cartridge[i] = true;
                    btn.BackColor = Color.YellowGreen;
                }
            }
        }

        private void btn_teachsave_Click(object sender, EventArgs e)
        {
            sCartridge = Cartridge;
        }

        private void Teach_Load(object sender, EventArgs e)
        {
            foreach (Control ctr in gb_cartridge.Controls)
            {
                if (ctr is Button)
                {
                    for (int i = 0; i < sCartridge.Length; i++)
                    {
                        if (int.Parse(ctr.Tag.ToString()) == i)
                        {
                            if (sCartridge[i] == true)
                            {
                                ctr.BackColor = Color.YellowGreen;
                            }
                        }
                    }
                }
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in gb_cartridge.Controls)
            {
                if (ctr is Button)
                {
                    ctr.BackColor = SystemColors.Control;
                }
            }
            for (int i = 0; i < sCartridge.Length; i++)
                sCartridge[i] = false;
            for (int i = 0; i < Cartridge.Length; i++)
                Cartridge[i] = false;
        }
    }
}

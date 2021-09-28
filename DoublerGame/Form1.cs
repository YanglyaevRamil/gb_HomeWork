using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doubler
{
    public partial class Form1 : Form
    {

        Core frmCore;

        public Form1()
        {
            frmCore = new Core();
            InitializeComponent();
        }
        private void InputForm_Load(object sender, EventArgs e)
        {
            RstForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sender == btnCmd1)
            {
                frmCore.Inc();
            }
            else if (sender == btnCmd2)
            {
                frmCore.Mul();
            }
            else if (sender == btnRst)
            {
                RstForm();
            }
            else if (sender == btnBack)
            {
                frmCore.ReadLog();
                Up();
            }
            Up();
            Chek();
        }
        public void Up()
        {
            OutputLable.Text = Convert.ToString(frmCore.Sum);
            label1.Text = $"Получите число: {frmCore.Number}";
            label2.Text = $"Попыток: {frmCore.NumberClicks}";
        }
        public void RstForm()
        {
            frmCore.Rst();
            frmCore.Rnd();
            Up();
        }
        public void Chek()
        {
            if (frmCore.Sum > frmCore.Number || frmCore.Chek())
            {
                if (frmCore.Chek())
                {
                    MessageBox.Show($"Win! Потратили {frmCore.NumberClicks} ходов", "Вы выиграли", MessageBoxButtons.OK);
                }
                else if (frmCore.Sum > frmCore.Number)
                {
                    MessageBox.Show("Game Over", "Вы проиглали", MessageBoxButtons.OK);
                }
                
                if (MessageBox.Show("Хотите переиграть?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    RstForm();
                }
                else
                {
                    Form ifrm = Application.OpenForms[0];
                    ifrm.Close();
                }
            }
        }

    }
}

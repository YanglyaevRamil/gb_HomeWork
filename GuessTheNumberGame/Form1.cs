using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessTheNumber
{
    public partial class Form1 : Form
    {
        private int sum = 0;
        CoreForm1 formCore;
        public Form1()
        {
            formCore = new CoreForm1();
            InitializeComponent();
        }
        
        private void btnLess_Click(object sender, EventArgs e)
        {
            ChekEq();
            CheckLessDialog();
        }

        private void btnGreater_Click(object sender, EventArgs e)
        {
            ChekEq();
            CheckGreaterDialog();
        }

        private void btnInputNum_Click(object sender, EventArgs e)
        {
            sum++;
            label1.Text = "";
            Form2 fm2 = new Form2();
            fm2.ShowDialog();
        }

        private void btnAnew_Click(object sender, EventArgs e)
        {
            Rst();
        }

        private void Rst()
        {
            label1.Text = "Начните игру, введите число";
            DataBank.InputNumber = 0;
            formCore.Rnd();
        }

        private void CheckLessDialog()
        {
            if (DataBank.InputNumber != 0) 
            { 
                if (formCore.Less(DataBank.InputNumber))
                {
                    label1.Text = $"ДА : {DataBank.InputNumber} < Х";
                }
                else
                {
                    label1.Text = $"НЕТ : {DataBank.InputNumber} > Х";
                }
            }
        }
        private void CheckGreaterDialog()
        {
            if (DataBank.InputNumber != 0)
            {
                if (formCore.Greate(DataBank.InputNumber))
                {
                    label1.Text = $"ДА : {DataBank.InputNumber} > Х";
                }
                else
                {
                    label1.Text = $"НЕТ : {DataBank.InputNumber} < Х";
                }
            }
        }
        private void ChekEq()
        {
            if (formCore.Eq(DataBank.InputNumber))
            {
                MessageBox.Show($"Win! Загаданное число {DataBank.InputNumber}, вы потратили {sum} попыток", $"Вы выиграли!", MessageBoxButtons.OK);
                if (MessageBox.Show("Хотите переиграть?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Rst();
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

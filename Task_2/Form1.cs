using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int number))
            {
                numericUpDown1.Value = number;
            }
            else
            {
                MessageBox.Show("Вы ввели некорректное число", "Проверка данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(numericUpDown1.Value);
        }
    }
}

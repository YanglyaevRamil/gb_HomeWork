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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int number))
            {
                DataBank.InputNumber = number;
                //Form1 ifrm = (Form1)Application.OpenForms[0];// !!!!!!!!! плохая реалицация, переделать 
                //ifrm.LablelText = $"Вы ввели число: {Convert.ToString(number)}";  // !!!!!!!!! увеличиваем связность 
                this.Close();

            }
            else
            {
                MessageBox.Show("Вы ввели некорректное число", "Проверка данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

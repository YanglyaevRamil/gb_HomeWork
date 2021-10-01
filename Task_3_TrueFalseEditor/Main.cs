using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrueFalseEditor
{
    public partial class Main : Form
    {
        private TrueFalse database;

        public Main()
        {
            InitializeComponent();
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuItemNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(saveFileDialog.FileName);
                //database.Add("Земля круглая?", true);
                database.Save();
                nudNumber.Maximum = 1;
                nudNumber.Minimum = 1;
                nudNumber.Value = 1;
            }
        }

        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (new FileInfo(openFileDialog.FileName).Length <= 1024) 
                {
                    database = new TrueFalse(openFileDialog.FileName);
                    database.Load();
                    nudNumber.Maximum = database.Count;
                    nudNumber.Minimum = 1;
                    nudNumber.Value = 1;
                    txtBoxMax.Text = Convert.ToString(database.Count);
                }
            }
        }

        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            if(database != null)
            {
                tbQuestion.Text = database[(int)nudNumber.Value - 1].Text;
                cbTrue.Checked = database[(int)nudNumber.Value - 1].TrueFalse;
            }

        }

        private void menuItemSave_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                database.Save();
            }
        }

        private void menuItemSaveAs_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    database.FileName = saveFileDialog.FileName;
                    database.Save();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                database.Add(tbQuestion.Text, cbTrue.Checked);
                nudNumber.Maximum = database.Count;
                nudNumber.Value = database.Count;
                txtBoxMax.Text = Convert.ToString(database.Count);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                database[(int)nudNumber.Value - 1].Text = tbQuestion.Text;
                database[(int)nudNumber.Value - 1].TrueFalse = cbTrue.Checked;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                if (database.Count > 1)
                {
                    database.Remove((int)nudNumber.Value - 1);
                    nudNumber.Maximum = database.Count;
                    nudNumber.Value = database.Count;
                    txtBoxMax.Text = Convert.ToString(database.Count);
                }
            }
        }

        private void aboutTheProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор: Янгляев Рамиль\r\nВерсия: v1.0\r\n","Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}

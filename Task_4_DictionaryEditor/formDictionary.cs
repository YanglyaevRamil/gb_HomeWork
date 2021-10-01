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

namespace DictionaryEditor
{
    public partial class formDictionary : Form
    {
        private CoreDictionary database;
        public formDictionary()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                database = new CoreDictionary(saveFileDialog.FileName);
                database.Add("Дом", "House");
                database.Save();
                nudNumber.Maximum = 1;
                nudNumber.Minimum = 1;
                nudNumber.Value = 1;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (new FileInfo(openFileDialog.FileName).Length <= 1024)
                {
                    database = new CoreDictionary(openFileDialog.FileName);
                    database.Load();
                    nudNumber.Maximum = database.Count;
                    nudNumber.Minimum = 1;
                    nudNumber.Value = 1;
                    txtBoxMax.Text = Convert.ToString(database.Count);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                database.Save();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            if (database != null)
            {
                textBoxRU.Text = database[(int)nudNumber.Value - 1].WordRU;
                textBoxENG.Text = database[(int)nudNumber.Value - 1].WordENG;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                database[(int)nudNumber.Value - 1].WordRU = textBoxRU.Text;
                database[(int)nudNumber.Value - 1].WordENG = textBoxENG.Text;
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

                    textBoxRU.Text = database[(int)nudNumber.Value - 1].WordRU;
                    textBoxENG.Text = database[(int)nudNumber.Value - 1].WordENG;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                if (!(textBoxRU.Text == "" | textBoxENG.Text == ""))
                {
                    database.Add(textBoxRU.Text, textBoxENG.Text);
                    nudNumber.Maximum = database.Count;
                    nudNumber.Value = database.Count;
                    txtBoxMax.Text = Convert.ToString(database.Count);
                }
            }
        }
    }
}

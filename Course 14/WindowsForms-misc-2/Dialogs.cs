using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_misc_2
{
    public partial class Dialogs : Form
    {
        public Dialogs()
        {
            InitializeComponent();
        }

        private void btnChangeBackColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() != DialogResult.OK) return;

            textBox1.BackColor = colorDialog1.Color;
        }

        private void btnChangeForeColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() != DialogResult.OK) return;

            textBox1.ForeColor = colorDialog1.Color;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowApply = true;
            fontDialog1.ShowEffects = true;
            fontDialog1.ShowColor = true;

            fontDialog1.Font = textBox2.Font;

            if (fontDialog1.ShowDialog() != DialogResult.OK) return;

            textBox2.Font = fontDialog1.Font;
            textBox2.ForeColor = fontDialog1.Color;
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {
            textBox2.Font = fontDialog1.Font;
            textBox2.ForeColor = fontDialog1.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.Title = "Save File as";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;

            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            MessageBox.Show(saveFileDialog1.FileName);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Open File";
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            MessageBox.Show(openFileDialog1.FileName);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            foreach (String FileName in openFileDialog1.FileNames)
            {
                MessageBox.Show(FileName);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = true;

            if (folderBrowserDialog1.ShowDialog() != DialogResult.OK) return;

            MessageBox.Show(folderBrowserDialog1.SelectedPath);
        }
    }
}

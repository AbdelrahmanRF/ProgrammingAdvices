using System;
using System.Windows.Forms;

namespace WindowsForms_misc_2
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new MaskedTextBox();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = new ComboBox();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form frm = new FLinkLable();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form frm = new FCheckedListBox();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form frm = new FDateTimePicker();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form frm = new FTimer();
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form frm = new FNotifyIcon();
            frm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form frm = new TreeView_ImageList();
            frm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form frm = new FProgressBar();
            frm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form frm = new TodoList();
            frm.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form frm = new FListView();
            frm.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form frm = new FErrorProvider();
            frm.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form frm = new FTrackBar();
            frm.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form frm = new FNumericUpDown();
            frm.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form frm = new Containers();
            frm.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Form frm = new Dialogs();
            frm.Show();
        }
    }
}

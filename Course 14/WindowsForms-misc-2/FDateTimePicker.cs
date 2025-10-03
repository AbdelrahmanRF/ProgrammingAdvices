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
    public partial class FDateTimePicker : Form
    {
        public FDateTimePicker()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dateTimePicker1.Value.ToShortDateString());
        }

        private void lblLongDateString_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dateTimePicker1.Value.ToLongDateString());
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            lblDate.Text = dateTimePicker1.Value.ToString() + Environment.NewLine;
            lblDate.Text += dateTimePicker1.Value.ToString("dd-mm-yyyy") + Environment.NewLine;
            lblDate.Text += dateTimePicker1.Value.ToString("dddd-MMM-yyyy") + Environment.NewLine;
            lblDate.Text += dateTimePicker1.Value.ToString("mm-dd-yyyy") + Environment.NewLine;
            lblDate.Text += dateTimePicker1.Value.ToString("dd/mm/yyyy") + Environment.NewLine;
            lblDate.Text += dateTimePicker1.Value.ToString("dddd, dd-mm-yyyy") + Environment.NewLine;
        }

        private void btnRangeStart_Click(object sender, EventArgs e)
        {
            MessageBox.Show(monthCalendar1.SelectionRange.Start.ToShortDateString());
        }

        private void btnRangeEnd_Click(object sender, EventArgs e)
        {
            MessageBox.Show(monthCalendar1.SelectionRange.End.ToShortDateString());
        }

        private void btnSelectedRange_Click(object sender, EventArgs e)
        {
            MessageBox.Show(monthCalendar1.SelectionRange.ToString());

        }
    }
}

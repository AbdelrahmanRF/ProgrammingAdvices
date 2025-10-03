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
    public partial class FListView : Form
    {
        public FListView()
        {
            InitializeComponent();
        }

        private void FListView_Load(object sender, EventArgs e)
        {
            cbView.SelectedIndex = 0;
        }

        private void cbView_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cbView.Text)
            {
                case "Details":
                    lvPersonsList.View = View.Details;
                    break;

                case "Large Icon":
                    lvPersonsList.View = View.LargeIcon;
                    break;

                case "Small Icon":
                    lvPersonsList.View = View.SmallIcon;
                    break;

                case "List":
                    lvPersonsList.View = View.List;
                    break;

                case "Tile":
                    lvPersonsList.View = View.Tile;
                    break;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbID.Text) || String.IsNullOrEmpty(tbName.Text))
                return;

            ListViewItem item = new ListViewItem(tbID.Text.Trim());

            if (gMale.Checked)
                item.ImageIndex = 0;
            else
                item.ImageIndex = 1;

            item.SubItems.Add(tbName.Text.Trim());
            lvPersonsList.Items.Add(item);

            tbID.Clear();
            tbName.Clear();

            gMale.Checked = true;
            tbID.Focus();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(lvPersonsList.SelectedItems.Count == 0) return;

            lvPersonsList.Items.Remove(lvPersonsList.SelectedItems[0]);
        }

        private void btnFillRandom_Click(object sender, EventArgs e)
        {
            for(int i = 1; i <= 10;  i++)
            {
                ListViewItem item = new ListViewItem(i.ToString());

                if (i % 2 == 0)
                    item.ImageIndex = 0;
                else
                    item.ImageIndex = 1;

                item.SubItems.Add("Person " + i);
                lvPersonsList.Items.Add(item);
            }
        }
    }
}

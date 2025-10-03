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
    public partial class TodoList : Form
    {
        public TodoList()
        {
            InitializeComponent();
        }

        private void RefreshUITasksTrack()
        {
            int Pending = 0;
            int Completed = 0;
            int TotalTasks = tvTasks.Nodes.Count;

            if(tvTasks.Nodes.Count == 0)
            {
                lblPending.Text = "0";
                lblCompleted.Text = "0";
                lblTasksProgress.Text = "0%";
                pTasksProgressBar.Value = 0;
                return;
            }

            foreach (TreeNode node in tvTasks.Nodes)
            {
                if (node.Checked)
                    ++Completed;
            }

            Pending = TotalTasks - Completed;

            lblPending.Text = Pending.ToString();
            lblCompleted.Text = Completed.ToString();

            float Progress = ((float)Completed / TotalTasks) * 100;

            lblTasksProgress.Text = Progress.ToString("0") + "%";
            pTasksProgressBar.Value = (int)Progress;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbTodo.Text))
            {
                MessageBox.Show("Please Write your todo then press add", "Task Cannot be Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tvTasks.Nodes.Add(tbTodo.Text);
            tbTodo.Text = "";

            RefreshUITasksTrack();
        }

        private void btnDeleteAllTasks_Click(object sender, EventArgs e)
        {
            tvTasks.Nodes.Clear();
            RefreshUITasksTrack();
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if(tvTasks.SelectedNode == null)
            {
                MessageBox.Show("Please Select Task to Remove", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tvTasks.Nodes.Remove(tvTasks.SelectedNode);
            RefreshUITasksTrack();
        }

        private void tvTasks_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeNode Task = (TreeNode)e.Node;

            if(Task.Checked)
            {
                Task.NodeFont = new Font(tvTasks.Font, FontStyle.Strikeout);
            }
            else
            {
                e.Node.NodeFont = null;
            }

            RefreshUITasksTrack();
        }
    }
}

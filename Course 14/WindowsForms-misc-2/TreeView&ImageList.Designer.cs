namespace WindowsForms_misc_2
{
    partial class TreeView_ImageList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeView_ImageList));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Hyundai");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Toyota");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Cars", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("AirPlane", 1, 1);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Jet", 1, 1);
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Planes", 1, 1, new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "car.png");
            this.imageList1.Images.SetKeyName(1, "plane.png");
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(63, 34);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "cnHyundai";
            treeNode1.Text = "Hyundai";
            treeNode2.Name = "cnToyota";
            treeNode2.Text = "Toyota";
            treeNode3.Name = "nCars";
            treeNode3.Text = "Cars";
            treeNode4.ImageIndex = 1;
            treeNode4.Name = "cnAirPlane";
            treeNode4.SelectedImageIndex = 1;
            treeNode4.Text = "AirPlane";
            treeNode5.ImageIndex = 1;
            treeNode5.Name = "cnJet";
            treeNode5.SelectedImageIndex = 1;
            treeNode5.Text = "Jet";
            treeNode6.ImageIndex = 1;
            treeNode6.Name = "nPlanes";
            treeNode6.SelectedImageIndex = 1;
            treeNode6.Text = "Planes";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(310, 326);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            this.treeView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDoubleClick);
            // 
            // TreeView_ImageList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.treeView1);
            this.Name = "TreeView_ImageList";
            this.Text = "TreeView_ImageList";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TreeView treeView1;
    }
}
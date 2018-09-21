namespace Indicium
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Keyboards");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Pointing Devices");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Physical Adapters");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Virtual Adapters");
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Disks");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Volumes");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Opticals");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Removables");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Operating System");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("CPUs");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("RAM");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Motherboards");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Graphics");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Storage");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Network");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Audio");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Peripherals");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("BIOS");
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblbitness = new System.Windows.Forms.Label();
            this.lblos = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblversion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.LinkPeripherals = new System.Windows.Forms.LinkLabel();
            this.LinkBIOS = new System.Windows.Forms.LinkLabel();
            this.LinkAudio = new System.Windows.Forms.LinkLabel();
            this.LinkNetwork = new System.Windows.Forms.LinkLabel();
            this.LinkStorage = new System.Windows.Forms.LinkLabel();
            this.LinkGPU = new System.Windows.Forms.LinkLabel();
            this.LinkMotherboard = new System.Windows.Forms.LinkLabel();
            this.LinkRAM = new System.Windows.Forms.LinkLabel();
            this.LinkCPU = new System.Windows.Forms.LinkLabel();
            this.LinkSummary = new System.Windows.Forms.LinkLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.PeripheralsView = new System.Windows.Forms.TreeView();
            this.helperMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.googleSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BIOSView = new System.Windows.Forms.TreeView();
            this.AudioView = new System.Windows.Forms.TreeView();
            this.NetworkView = new System.Windows.Forms.TreeView();
            this.StorageView = new System.Windows.Forms.TreeView();
            this.GraphicsView = new System.Windows.Forms.TreeView();
            this.MotherboardView = new System.Windows.Forms.TreeView();
            this.RAMView = new System.Windows.Forms.TreeView();
            this.CPUView = new System.Windows.Forms.TreeView();
            this.SummaryView = new System.Windows.Forms.TreeView();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.helperMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblbitness);
            this.panel1.Controls.Add(this.lblos);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblversion);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(970, 77);
            this.panel1.TabIndex = 6;
            // 
            // lblbitness
            // 
            this.lblbitness.AutoSize = true;
            this.lblbitness.ForeColor = System.Drawing.Color.Silver;
            this.lblbitness.Location = new System.Drawing.Point(222, 46);
            this.lblbitness.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblbitness.Name = "lblbitness";
            this.lblbitness.Size = new System.Drawing.Size(56, 20);
            this.lblbitness.TabIndex = 6;
            this.lblbitness.Text = "bitness";
            // 
            // lblos
            // 
            this.lblos.AutoSize = true;
            this.lblos.ForeColor = System.Drawing.Color.Silver;
            this.lblos.Location = new System.Drawing.Point(222, 21);
            this.lblos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblos.Name = "lblos";
            this.lblos.Size = new System.Drawing.Size(24, 20);
            this.lblos.TabIndex = 5;
            this.lblos.Text = "os";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblversion
            // 
            this.lblversion.AutoSize = true;
            this.lblversion.ForeColor = System.Drawing.Color.Silver;
            this.lblversion.Location = new System.Drawing.Point(90, 46);
            this.lblversion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblversion.Name = "lblversion";
            this.lblversion.Size = new System.Drawing.Size(64, 20);
            this.lblversion.TabIndex = 4;
            this.lblversion.Text = "Version:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(88, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Indicium";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.LinkPeripherals);
            this.panel2.Controls.Add(this.LinkBIOS);
            this.panel2.Controls.Add(this.LinkAudio);
            this.panel2.Controls.Add(this.LinkNetwork);
            this.panel2.Controls.Add(this.LinkStorage);
            this.panel2.Controls.Add(this.LinkGPU);
            this.panel2.Controls.Add(this.LinkMotherboard);
            this.panel2.Controls.Add(this.LinkRAM);
            this.panel2.Controls.Add(this.LinkCPU);
            this.panel2.Controls.Add(this.LinkSummary);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 77);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(173, 652);
            this.panel2.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.BackColor = System.Drawing.Color.DodgerBlue;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(12, 554);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 39);
            this.button2.TabIndex = 69;
            this.button2.Tag = "themeable";
            this.button2.Text = "Theme";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(12, 468);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 39);
            this.button1.TabIndex = 68;
            this.button1.Tag = "themeable";
            this.button1.Text = "Screenshot";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button7.BackColor = System.Drawing.Color.DodgerBlue;
            this.button7.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button7.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(12, 511);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(124, 39);
            this.button7.TabIndex = 67;
            this.button7.Tag = "themeable";
            this.button7.Text = "Save as JSON";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // LinkPeripherals
            // 
            this.LinkPeripherals.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this.LinkPeripherals.AutoSize = true;
            this.LinkPeripherals.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkPeripherals.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.LinkPeripherals.LinkColor = System.Drawing.Color.DodgerBlue;
            this.LinkPeripherals.Location = new System.Drawing.Point(11, 236);
            this.LinkPeripherals.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LinkPeripherals.Name = "LinkPeripherals";
            this.LinkPeripherals.Size = new System.Drawing.Size(112, 28);
            this.LinkPeripherals.TabIndex = 66;
            this.LinkPeripherals.TabStop = true;
            this.LinkPeripherals.Tag = "themeable";
            this.LinkPeripherals.Text = "Peripherals";
            this.LinkPeripherals.VisitedLinkColor = System.Drawing.Color.DodgerBlue;
            this.LinkPeripherals.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkPeripherals_LinkClicked);
            // 
            // LinkBIOS
            // 
            this.LinkBIOS.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this.LinkBIOS.AutoSize = true;
            this.LinkBIOS.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkBIOS.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.LinkBIOS.LinkColor = System.Drawing.Color.DodgerBlue;
            this.LinkBIOS.Location = new System.Drawing.Point(11, 264);
            this.LinkBIOS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LinkBIOS.Name = "LinkBIOS";
            this.LinkBIOS.Size = new System.Drawing.Size(56, 28);
            this.LinkBIOS.TabIndex = 61;
            this.LinkBIOS.TabStop = true;
            this.LinkBIOS.Tag = "themeable";
            this.LinkBIOS.Text = "BIOS";
            this.LinkBIOS.VisitedLinkColor = System.Drawing.Color.DodgerBlue;
            this.LinkBIOS.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkBIOS_LinkClicked);
            // 
            // LinkAudio
            // 
            this.LinkAudio.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this.LinkAudio.AutoSize = true;
            this.LinkAudio.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkAudio.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.LinkAudio.LinkColor = System.Drawing.Color.DodgerBlue;
            this.LinkAudio.Location = new System.Drawing.Point(11, 208);
            this.LinkAudio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LinkAudio.Name = "LinkAudio";
            this.LinkAudio.Size = new System.Drawing.Size(66, 28);
            this.LinkAudio.TabIndex = 60;
            this.LinkAudio.TabStop = true;
            this.LinkAudio.Tag = "themeable";
            this.LinkAudio.Text = "Audio";
            this.LinkAudio.VisitedLinkColor = System.Drawing.Color.DodgerBlue;
            this.LinkAudio.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkAudio_LinkClicked);
            // 
            // LinkNetwork
            // 
            this.LinkNetwork.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this.LinkNetwork.AutoSize = true;
            this.LinkNetwork.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkNetwork.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.LinkNetwork.LinkColor = System.Drawing.Color.DodgerBlue;
            this.LinkNetwork.Location = new System.Drawing.Point(11, 180);
            this.LinkNetwork.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LinkNetwork.Name = "LinkNetwork";
            this.LinkNetwork.Size = new System.Drawing.Size(90, 28);
            this.LinkNetwork.TabIndex = 59;
            this.LinkNetwork.TabStop = true;
            this.LinkNetwork.Tag = "themeable";
            this.LinkNetwork.Text = "Network";
            this.LinkNetwork.VisitedLinkColor = System.Drawing.Color.DodgerBlue;
            this.LinkNetwork.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkNetwork_LinkClicked);
            // 
            // LinkStorage
            // 
            this.LinkStorage.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this.LinkStorage.AutoSize = true;
            this.LinkStorage.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkStorage.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.LinkStorage.LinkColor = System.Drawing.Color.DodgerBlue;
            this.LinkStorage.Location = new System.Drawing.Point(11, 152);
            this.LinkStorage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LinkStorage.Name = "LinkStorage";
            this.LinkStorage.Size = new System.Drawing.Size(81, 28);
            this.LinkStorage.TabIndex = 58;
            this.LinkStorage.TabStop = true;
            this.LinkStorage.Tag = "themeable";
            this.LinkStorage.Text = "Storage";
            this.LinkStorage.VisitedLinkColor = System.Drawing.Color.DodgerBlue;
            this.LinkStorage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkStorage_LinkClicked);
            // 
            // LinkGPU
            // 
            this.LinkGPU.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this.LinkGPU.AutoSize = true;
            this.LinkGPU.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkGPU.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.LinkGPU.LinkColor = System.Drawing.Color.DodgerBlue;
            this.LinkGPU.Location = new System.Drawing.Point(11, 124);
            this.LinkGPU.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LinkGPU.Name = "LinkGPU";
            this.LinkGPU.Size = new System.Drawing.Size(90, 28);
            this.LinkGPU.TabIndex = 57;
            this.LinkGPU.TabStop = true;
            this.LinkGPU.Tag = "themeable";
            this.LinkGPU.Text = "Graphics";
            this.LinkGPU.VisitedLinkColor = System.Drawing.Color.DodgerBlue;
            this.LinkGPU.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkGPU_LinkClicked);
            // 
            // LinkMotherboard
            // 
            this.LinkMotherboard.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this.LinkMotherboard.AutoSize = true;
            this.LinkMotherboard.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkMotherboard.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.LinkMotherboard.LinkColor = System.Drawing.Color.DodgerBlue;
            this.LinkMotherboard.Location = new System.Drawing.Point(11, 96);
            this.LinkMotherboard.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LinkMotherboard.Name = "LinkMotherboard";
            this.LinkMotherboard.Size = new System.Drawing.Size(141, 28);
            this.LinkMotherboard.TabIndex = 55;
            this.LinkMotherboard.TabStop = true;
            this.LinkMotherboard.Tag = "themeable";
            this.LinkMotherboard.Text = "Motherboards";
            this.LinkMotherboard.VisitedLinkColor = System.Drawing.Color.DodgerBlue;
            this.LinkMotherboard.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkMotherboard_LinkClicked);
            // 
            // LinkRAM
            // 
            this.LinkRAM.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this.LinkRAM.AutoSize = true;
            this.LinkRAM.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkRAM.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.LinkRAM.LinkColor = System.Drawing.Color.DodgerBlue;
            this.LinkRAM.Location = new System.Drawing.Point(11, 68);
            this.LinkRAM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LinkRAM.Name = "LinkRAM";
            this.LinkRAM.Size = new System.Drawing.Size(55, 28);
            this.LinkRAM.TabIndex = 56;
            this.LinkRAM.TabStop = true;
            this.LinkRAM.Tag = "themeable";
            this.LinkRAM.Text = "RAM";
            this.LinkRAM.VisitedLinkColor = System.Drawing.Color.DodgerBlue;
            this.LinkRAM.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkRAM_LinkClicked);
            // 
            // LinkCPU
            // 
            this.LinkCPU.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this.LinkCPU.AutoSize = true;
            this.LinkCPU.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkCPU.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.LinkCPU.LinkColor = System.Drawing.Color.DodgerBlue;
            this.LinkCPU.Location = new System.Drawing.Point(11, 40);
            this.LinkCPU.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LinkCPU.Name = "LinkCPU";
            this.LinkCPU.Size = new System.Drawing.Size(59, 28);
            this.LinkCPU.TabIndex = 55;
            this.LinkCPU.TabStop = true;
            this.LinkCPU.Tag = "themeable";
            this.LinkCPU.Text = "CPUs";
            this.LinkCPU.VisitedLinkColor = System.Drawing.Color.DodgerBlue;
            this.LinkCPU.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkCPU_LinkClicked);
            // 
            // LinkSummary
            // 
            this.LinkSummary.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this.LinkSummary.AutoSize = true;
            this.LinkSummary.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkSummary.LinkColor = System.Drawing.Color.White;
            this.LinkSummary.Location = new System.Drawing.Point(11, 12);
            this.LinkSummary.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LinkSummary.Name = "LinkSummary";
            this.LinkSummary.Size = new System.Drawing.Size(99, 28);
            this.LinkSummary.TabIndex = 54;
            this.LinkSummary.TabStop = true;
            this.LinkSummary.Tag = "themeable";
            this.LinkSummary.Text = "Summary";
            this.LinkSummary.VisitedLinkColor = System.Drawing.Color.DodgerBlue;
            this.LinkSummary.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.PeripheralsView);
            this.panel3.Controls.Add(this.BIOSView);
            this.panel3.Controls.Add(this.AudioView);
            this.panel3.Controls.Add(this.NetworkView);
            this.panel3.Controls.Add(this.StorageView);
            this.panel3.Controls.Add(this.GraphicsView);
            this.panel3.Controls.Add(this.MotherboardView);
            this.panel3.Controls.Add(this.RAMView);
            this.panel3.Controls.Add(this.CPUView);
            this.panel3.Controls.Add(this.SummaryView);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(173, 77);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(797, 652);
            this.panel3.TabIndex = 8;
            // 
            // PeripheralsView
            // 
            this.PeripheralsView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.PeripheralsView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PeripheralsView.ContextMenuStrip = this.helperMenu;
            this.PeripheralsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PeripheralsView.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PeripheralsView.ForeColor = System.Drawing.Color.White;
            this.PeripheralsView.Location = new System.Drawing.Point(0, 0);
            this.PeripheralsView.Margin = new System.Windows.Forms.Padding(2);
            this.PeripheralsView.Name = "PeripheralsView";
            treeNode9.ForeColor = System.Drawing.Color.White;
            treeNode9.Name = "rootKeyboard";
            treeNode9.Tag = "";
            treeNode9.Text = "Keyboards";
            treeNode10.Name = "rootPointing";
            treeNode10.Text = "Pointing Devices";
            this.PeripheralsView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10});
            this.PeripheralsView.Size = new System.Drawing.Size(795, 650);
            this.PeripheralsView.TabIndex = 21;
            this.PeripheralsView.Visible = false;
            this.PeripheralsView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.PeripheralsView_NodeMouseClick);
            // 
            // helperMenu
            // 
            this.helperMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.helperMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.helperMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helperMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.helperMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.googleSearchToolStripMenuItem});
            this.helperMenu.Name = "helperMenu";
            this.helperMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.helperMenu.ShowImageMargin = false;
            this.helperMenu.Size = new System.Drawing.Size(188, 68);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(187, 32);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // googleSearchToolStripMenuItem
            // 
            this.googleSearchToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.googleSearchToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.googleSearchToolStripMenuItem.Name = "googleSearchToolStripMenuItem";
            this.googleSearchToolStripMenuItem.Size = new System.Drawing.Size(187, 32);
            this.googleSearchToolStripMenuItem.Text = "Google Search";
            this.googleSearchToolStripMenuItem.Click += new System.EventHandler(this.googleSearchToolStripMenuItem_Click);
            // 
            // BIOSView
            // 
            this.BIOSView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BIOSView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BIOSView.ContextMenuStrip = this.helperMenu;
            this.BIOSView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BIOSView.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BIOSView.ForeColor = System.Drawing.Color.White;
            this.BIOSView.Location = new System.Drawing.Point(0, 0);
            this.BIOSView.Margin = new System.Windows.Forms.Padding(2);
            this.BIOSView.Name = "BIOSView";
            this.BIOSView.Size = new System.Drawing.Size(795, 650);
            this.BIOSView.TabIndex = 20;
            this.BIOSView.Visible = false;
            this.BIOSView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.BIOSView_NodeMouseClick);
            // 
            // AudioView
            // 
            this.AudioView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.AudioView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AudioView.ContextMenuStrip = this.helperMenu;
            this.AudioView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AudioView.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AudioView.ForeColor = System.Drawing.Color.White;
            this.AudioView.Location = new System.Drawing.Point(0, 0);
            this.AudioView.Margin = new System.Windows.Forms.Padding(2);
            this.AudioView.Name = "AudioView";
            this.AudioView.Size = new System.Drawing.Size(795, 650);
            this.AudioView.TabIndex = 19;
            this.AudioView.Visible = false;
            this.AudioView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.AudioView_NodeMouseClick);
            // 
            // NetworkView
            // 
            this.NetworkView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.NetworkView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NetworkView.ContextMenuStrip = this.helperMenu;
            this.NetworkView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NetworkView.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NetworkView.ForeColor = System.Drawing.Color.White;
            this.NetworkView.Location = new System.Drawing.Point(0, 0);
            this.NetworkView.Margin = new System.Windows.Forms.Padding(2);
            this.NetworkView.Name = "NetworkView";
            treeNode11.ForeColor = System.Drawing.Color.White;
            treeNode11.Name = "rootPhysical";
            treeNode11.Tag = "";
            treeNode11.Text = "Physical Adapters";
            treeNode12.ForeColor = System.Drawing.Color.White;
            treeNode12.Name = "rootVirtual";
            treeNode12.Tag = "";
            treeNode12.Text = "Virtual Adapters";
            this.NetworkView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12});
            this.NetworkView.Size = new System.Drawing.Size(795, 650);
            this.NetworkView.TabIndex = 18;
            this.NetworkView.Visible = false;
            this.NetworkView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.NetworkView_NodeMouseClick);
            // 
            // StorageView
            // 
            this.StorageView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.StorageView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StorageView.ContextMenuStrip = this.helperMenu;
            this.StorageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StorageView.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StorageView.ForeColor = System.Drawing.Color.White;
            this.StorageView.Location = new System.Drawing.Point(0, 0);
            this.StorageView.Margin = new System.Windows.Forms.Padding(2);
            this.StorageView.Name = "StorageView";
            treeNode1.ForeColor = System.Drawing.Color.White;
            treeNode1.Name = "rootDisk";
            treeNode1.Tag = "";
            treeNode1.Text = "Disks";
            treeNode2.ForeColor = System.Drawing.Color.White;
            treeNode2.Name = "rootVolume";
            treeNode2.Tag = "";
            treeNode2.Text = "Volumes";
            treeNode13.ForeColor = System.Drawing.Color.White;
            treeNode13.Name = "rootOptical";
            treeNode13.Text = "Opticals";
            treeNode14.ForeColor = System.Drawing.Color.White;
            treeNode14.Name = "rootRemovable";
            treeNode14.Text = "Removables";
            this.StorageView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode13,
            treeNode14});
            this.StorageView.Size = new System.Drawing.Size(795, 650);
            this.StorageView.TabIndex = 17;
            this.StorageView.Visible = false;
            this.StorageView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.StorageView_NodeMouseClick);
            // 
            // GraphicsView
            // 
            this.GraphicsView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.GraphicsView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GraphicsView.ContextMenuStrip = this.helperMenu;
            this.GraphicsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GraphicsView.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GraphicsView.ForeColor = System.Drawing.Color.White;
            this.GraphicsView.Location = new System.Drawing.Point(0, 0);
            this.GraphicsView.Margin = new System.Windows.Forms.Padding(2);
            this.GraphicsView.Name = "GraphicsView";
            this.GraphicsView.Size = new System.Drawing.Size(795, 650);
            this.GraphicsView.TabIndex = 16;
            this.GraphicsView.Visible = false;
            this.GraphicsView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.GraphicsView_NodeMouseClick);
            // 
            // MotherboardView
            // 
            this.MotherboardView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.MotherboardView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MotherboardView.ContextMenuStrip = this.helperMenu;
            this.MotherboardView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MotherboardView.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MotherboardView.ForeColor = System.Drawing.Color.White;
            this.MotherboardView.Location = new System.Drawing.Point(0, 0);
            this.MotherboardView.Margin = new System.Windows.Forms.Padding(2);
            this.MotherboardView.Name = "MotherboardView";
            this.MotherboardView.Size = new System.Drawing.Size(795, 650);
            this.MotherboardView.TabIndex = 15;
            this.MotherboardView.Visible = false;
            this.MotherboardView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.MotherboardView_NodeMouseClick);
            // 
            // RAMView
            // 
            this.RAMView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.RAMView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RAMView.ContextMenuStrip = this.helperMenu;
            this.RAMView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RAMView.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RAMView.ForeColor = System.Drawing.Color.White;
            this.RAMView.Location = new System.Drawing.Point(0, 0);
            this.RAMView.Margin = new System.Windows.Forms.Padding(2);
            this.RAMView.Name = "RAMView";
            this.RAMView.Size = new System.Drawing.Size(795, 650);
            this.RAMView.TabIndex = 14;
            this.RAMView.Visible = false;
            this.RAMView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.RAMView_NodeMouseClick);
            // 
            // CPUView
            // 
            this.CPUView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.CPUView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CPUView.ContextMenuStrip = this.helperMenu;
            this.CPUView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CPUView.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CPUView.ForeColor = System.Drawing.Color.White;
            this.CPUView.Location = new System.Drawing.Point(0, 0);
            this.CPUView.Margin = new System.Windows.Forms.Padding(2);
            this.CPUView.Name = "CPUView";
            this.CPUView.Size = new System.Drawing.Size(795, 650);
            this.CPUView.TabIndex = 13;
            this.CPUView.Visible = false;
            this.CPUView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.CPUView_NodeMouseClick);
            // 
            // SummaryView
            // 
            this.SummaryView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.SummaryView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SummaryView.ContextMenuStrip = this.helperMenu;
            this.SummaryView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SummaryView.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SummaryView.ForeColor = System.Drawing.Color.White;
            this.SummaryView.Location = new System.Drawing.Point(0, 0);
            this.SummaryView.Margin = new System.Windows.Forms.Padding(2);
            this.SummaryView.Name = "SummaryView";
            treeNode3.ForeColor = System.Drawing.Color.DodgerBlue;
            treeNode3.Name = "rootOS";
            treeNode3.Tag = "themeable";
            treeNode3.Text = "Operating System";
            treeNode4.ForeColor = System.Drawing.Color.DodgerBlue;
            treeNode4.Name = "rootCPU";
            treeNode4.Tag = "themeable";
            treeNode4.Text = "CPUs";
            treeNode15.ForeColor = System.Drawing.Color.DodgerBlue;
            treeNode15.Name = "rootRAM";
            treeNode15.Tag = "themeable";
            treeNode15.Text = "RAM";
            treeNode16.ForeColor = System.Drawing.Color.DodgerBlue;
            treeNode16.Name = "rootMotherboard";
            treeNode16.Tag = "themeable";
            treeNode16.Text = "Motherboards";
            treeNode17.ForeColor = System.Drawing.Color.DodgerBlue;
            treeNode17.Name = "rootGPU";
            treeNode17.Tag = "themeable";
            treeNode17.Text = "Graphics";
            treeNode18.ForeColor = System.Drawing.Color.DodgerBlue;
            treeNode18.Name = "rootStorage";
            treeNode18.Tag = "themeable";
            treeNode18.Text = "Storage";
            treeNode19.ForeColor = System.Drawing.Color.DodgerBlue;
            treeNode19.Name = "rootNetwork";
            treeNode19.Tag = "themeable";
            treeNode19.Text = "Network";
            treeNode20.ForeColor = System.Drawing.Color.DodgerBlue;
            treeNode20.Name = "rootAudio";
            treeNode20.Tag = "themeable";
            treeNode20.Text = "Audio";
            treeNode21.ForeColor = System.Drawing.Color.DodgerBlue;
            treeNode21.Name = "rootPeripheral";
            treeNode21.Tag = "themeable";
            treeNode21.Text = "Peripherals";
            treeNode22.ForeColor = System.Drawing.Color.DodgerBlue;
            treeNode22.Name = "rootBIOS";
            treeNode22.Tag = "themeable";
            treeNode22.Text = "BIOS";
            this.SummaryView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22});
            this.SummaryView.Size = new System.Drawing.Size(795, 650);
            this.SummaryView.TabIndex = 12;
            this.SummaryView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.SummaryView_NodeMouseClick);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.BackColor = System.Drawing.Color.DodgerBlue;
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(12, 597);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(124, 39);
            this.button3.TabIndex = 70;
            this.button3.Tag = "themeable";
            this.button3.Text = "Update";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(970, 729);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Indicium";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.helperMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblbitness;
        private System.Windows.Forms.Label lblos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblversion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel LinkRAM;
        private System.Windows.Forms.LinkLabel LinkCPU;
        private System.Windows.Forms.LinkLabel LinkSummary;
        private System.Windows.Forms.LinkLabel LinkAudio;
        private System.Windows.Forms.LinkLabel LinkNetwork;
        private System.Windows.Forms.LinkLabel LinkStorage;
        private System.Windows.Forms.LinkLabel LinkGPU;
        private System.Windows.Forms.LinkLabel LinkMotherboard;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.LinkLabel LinkBIOS;
        private System.Windows.Forms.TreeView CPUView;
        private System.Windows.Forms.TreeView RAMView;
        private System.Windows.Forms.TreeView MotherboardView;
        private System.Windows.Forms.TreeView GraphicsView;
        private System.Windows.Forms.TreeView StorageView;
        private System.Windows.Forms.TreeView NetworkView;
        private System.Windows.Forms.TreeView AudioView;
        private System.Windows.Forms.TreeView BIOSView;
        internal System.Windows.Forms.TreeView SummaryView;
        private System.Windows.Forms.LinkLabel LinkPeripherals;
        private System.Windows.Forms.TreeView PeripheralsView;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ContextMenuStrip helperMenu;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem googleSearchToolStripMenuItem;
        private System.Windows.Forms.Button button3;
    }
}


using System.Xml;

namespace IPChanger
{
    partial class IPChangerMainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IPChangerMainWindow));
            BtnReconnect = new Button();
            mainMenu = new MenuStrip();
            MMFileMenu = new ToolStripMenuItem();
            MMFileExit = new ToolStripMenuItem();
            MMToolsMenu = new ToolStripMenuItem();
            MMToolsPingHostname = new ToolStripMenuItem();
            MMToolsOpenNetworkConnections = new ToolStripMenuItem();
            MMToolsOpenNetworkSharing = new ToolStripMenuItem();
            MMToolsPublicIP = new ToolStripMenuItem();
            MMHelpMenu = new ToolStripMenuItem();
            MMHelpAbout = new ToolStripMenuItem();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            GroupBox0 = new GroupBox();
            lblConfig0Name = new Label();
            TbConfig0Name = new TextBox();
            CbConfig0Dhcp = new CheckBox();
            lblConfig0IP = new Label();
            TbConfig0IP = new TextBox();
            lblConfig0Mask = new Label();
            TbConfig0Mask = new TextBox();
            lblConfig0Gateway = new Label();
            TbConfig0Gateway = new TextBox();
            lblConfig0Dns = new Label();
            TbConfig0Dns = new TextBox();
            tabPage2 = new TabPage();
            BtnExit = new Button();
            BtnHideToTray = new Button();
            BtnTabAdd = new Button();
            CbNicSelect = new ComboBox();
            GroupBoxNicDetails = new GroupBox();
            TbCurrentDhcp = new TextBox();
            TbCurrentMac = new TextBox();
            TbCurrentFirewall = new TextBox();
            TbCurrentDNS = new TextBox();
            TbCurrentGateway = new TextBox();
            TbCurrentMask = new TextBox();
            TbCurrentIP = new TextBox();
            LblLangDhcpServer = new Label();
            LblLangWifi = new Label();
            LblLangFirewall = new Label();
            LblLangDns = new Label();
            LblLangGateway = new Label();
            LblLangMask = new Label();
            LblLangIP = new Label();
            BtnGetIP = new Button();
            BtnGetAdapters = new Button();
            lblTransAdapter = new Label();
            trayMenu = new ContextMenuStrip(components);
            trayMenuTools = new ToolStripMenuItem();
            trayMenuSeparator1 = new ToolStripSeparator();
            trayExit = new ToolStripMenuItem();
            trayIcon = new NotifyIcon(components);
            mainMenu.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            GroupBox0.SuspendLayout();
            GroupBoxNicDetails.SuspendLayout();
            trayMenu.SuspendLayout();
            SuspendLayout();
            // 
            // mainMenu
            // 
            resources.ApplyResources(mainMenu, "mainMenu");
            mainMenu.AccessibleRole = AccessibleRole.MenuBar;
            mainMenu.ImageScalingSize = new Size(20, 20);
            mainMenu.Items.AddRange(new ToolStripItem[] { MMFileMenu, MMToolsMenu, MMHelpMenu });
            mainMenu.Name = "mainMenu";
            // 
            // MMFileMenu
            // 
            resources.ApplyResources(MMFileMenu, "MMFileMenu");
            MMFileMenu.DropDownItems.AddRange(new ToolStripItem[] { MMFileExit });
            MMFileMenu.Name = "MMFileMenu";
            // 
            // MMFileExit
            // 
            resources.ApplyResources(MMFileExit, "MMFileExit");
            MMFileExit.Name = "MMFileExit";
            MMFileExit.Click += BtnExit_Click;
            // 
            // MMToolsMenu
            // 
            resources.ApplyResources(MMToolsMenu, "MMToolsMenu");
            MMToolsMenu.DropDownItems.AddRange(new ToolStripItem[] { MMToolsPingHostname, MMToolsOpenNetworkConnections, MMToolsOpenNetworkSharing, MMToolsPublicIP });
            MMToolsMenu.Name = "MMToolsMenu";
            // 
            // MMToolsPingHostname
            // 
            resources.ApplyResources(MMToolsPingHostname, "MMToolsPingHostname");
            MMToolsPingHostname.Name = "MMToolsPingHostname";
            MMToolsPingHostname.Click += ToolsPing_Click;
            // 
            // MMToolsOpenNetworkConnections
            // 
            resources.ApplyResources(MMToolsOpenNetworkConnections, "MMToolsOpenNetworkConnections");
            MMToolsOpenNetworkConnections.Name = "MMToolsOpenNetworkConnections";
            MMToolsOpenNetworkConnections.Click += MMToolsOpenNetworkConnections_Click;
            // 
            // MMToolsOpenNetworkSharing
            // 
            resources.ApplyResources(MMToolsOpenNetworkSharing, "MMToolsOpenNetworkSharing");
            MMToolsOpenNetworkSharing.Name = "MMToolsOpenNetworkSharing";
            MMToolsOpenNetworkSharing.Click += MMToolsOpenNetworkSharing_Click;
            // 
            // MMToolsPublicIP
            // 
            resources.ApplyResources(MMToolsPublicIP, "MMToolsPublicIP");
            MMToolsPublicIP.Name = "MMToolsPublicIP";
            MMToolsPublicIP.Click += MMToolsPublicIP_Click;
            // 
            // MMHelpMenu
            // 
            resources.ApplyResources(MMHelpMenu, "MMHelpMenu");
            MMHelpMenu.DropDownItems.AddRange(new ToolStripItem[] { MMHelpAbout });
            MMHelpMenu.Name = "MMHelpMenu";
            // 
            // MMHelpAbout
            // 
            resources.ApplyResources(MMHelpAbout, "MMHelpAbout");
            MMHelpAbout.Name = "MMHelpAbout";
            MMHelpAbout.Click += HelpAbout_Click;
            // 
            // BtnReconnect
            // 
            resources.ApplyResources(BtnReconnect, "BtnReconnect");
            BtnReconnect.Name = "BtnReconnect";
            BtnReconnect.UseVisualStyleBackColor = false;
            BtnReconnect.Click += BtnReconnect_Click;
            // 
            // tabControl1
            // 
            resources.ApplyResources(tabControl1, "tabControl1");
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            resources.ApplyResources(tabPage1, "tabPage1");
            tabPage1.Controls.Add(GroupBox0);
            tabPage1.Name = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // GroupBox0
            // 
            resources.ApplyResources(GroupBox0, "GroupBox0");
            GroupBox0.Controls.Add(lblConfig0Name);
            GroupBox0.Controls.Add(TbConfig0Name);
            GroupBox0.Controls.Add(CbConfig0Dhcp);
            GroupBox0.Controls.Add(lblConfig0IP);
            GroupBox0.Controls.Add(TbConfig0IP);
            GroupBox0.Controls.Add(lblConfig0Mask);
            GroupBox0.Controls.Add(TbConfig0Mask);
            GroupBox0.Controls.Add(lblConfig0Gateway);
            GroupBox0.Controls.Add(TbConfig0Gateway);
            GroupBox0.Controls.Add(lblConfig0Dns);
            GroupBox0.Controls.Add(TbConfig0Dns);
            GroupBox0.Name = "GroupBox0";
            GroupBox0.TabStop = false;
            // 
            // lblConfig0Name
            // 
            resources.ApplyResources(lblConfig0Name, "lblConfig0Name");
            lblConfig0Name.Name = "lblConfig0Name";
            // 
            // TbConfig0Name
            // 
            resources.ApplyResources(TbConfig0Name, "TbConfig0Name");
            TbConfig0Name.Name = "TbConfig0Name";
            TbConfig0Name.TextChanged += TbConfig_TextChanged;
            // 
            // CbConfig0Dhcp
            // 
            resources.ApplyResources(CbConfig0Dhcp, "CbConfig0Dhcp");
            CbConfig0Dhcp.Name = "CbConfig0Dhcp";
            CbConfig0Dhcp.UseVisualStyleBackColor = true;
            CbConfig0Dhcp.CheckedChanged += CbConfig0Dhcp_CheckedChanged;
            // 
            // lblConfig0IP
            // 
            resources.ApplyResources(lblConfig0IP, "lblConfig0IP");
            lblConfig0IP.Name = "lblConfig0IP";
            // 
            // TbConfig0IP
            // 
            resources.ApplyResources(TbConfig0IP, "TbConfig0IP");
            TbConfig0IP.Name = "TbConfig0IP";
            TbConfig0IP.TextChanged += TbConfig_TextChanged;
            // 
            // lblConfig0Mask
            // 
            resources.ApplyResources(lblConfig0Mask, "lblConfig0Mask");
            lblConfig0Mask.Name = "lblConfig0Mask";
            // 
            // TbConfig0Mask
            // 
            resources.ApplyResources(TbConfig0Mask, "TbConfig0Mask");
            TbConfig0Mask.Name = "TbConfig0Mask";
            TbConfig0Mask.TextChanged += TbConfig_TextChanged;
            // 
            // lblConfig0Gateway
            // 
            resources.ApplyResources(lblConfig0Gateway, "lblConfig0Gateway");
            lblConfig0Gateway.Name = "lblConfig0Gateway";
            // 
            // TbConfig0Gateway
            // 
            resources.ApplyResources(TbConfig0Gateway, "TbConfig0Gateway");
            TbConfig0Gateway.Name = "TbConfig0Gateway";
            // 
            // lblConfig0Dns
            // 
            resources.ApplyResources(lblConfig0Dns, "lblConfig0Dns");
            lblConfig0Dns.Name = "lblConfig0Dns";
            // 
            // TbConfig0Dns
            // 
            resources.ApplyResources(TbConfig0Dns, "TbConfig0Dns");
            TbConfig0Dns.Name = "TbConfig0Dns";
            TbConfig0Dns.TextChanged += TbConfig_TextChanged;
            // 
            // tabPage2
            // 
            resources.ApplyResources(tabPage2, "tabPage2");
            tabPage2.Name = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // BtnExit
            // 
            resources.ApplyResources(BtnExit, "BtnExit");
            BtnExit.Name = "BtnExit";
            BtnExit.UseVisualStyleBackColor = true;
            BtnExit.Click += BtnExit_Click;
            // 
            // BtnHideToTray
            // 
            resources.ApplyResources(BtnHideToTray, "BtnHideToTray");
            BtnHideToTray.Name = "BtnHideToTray";
            BtnHideToTray.UseVisualStyleBackColor = true;
            BtnHideToTray.Click += HideApp;
            // 
            // BtnTabAdd
            // 
            resources.ApplyResources(BtnTabAdd, "BtnTabAdd");
            BtnTabAdd.Name = "BtnTabAdd";
            BtnTabAdd.UseVisualStyleBackColor = true;
            BtnTabAdd.Click += BtnTabAdd_Click;
            // 
            // CbNicSelect
            // 
            resources.ApplyResources(CbNicSelect, "CbNicSelect");
            CbNicSelect.FormattingEnabled = true;
            CbNicSelect.Name = "CbNicSelect";
            CbNicSelect.Sorted = true;
            CbNicSelect.SelectedIndexChanged += CbNicSelect_SelectionChanged;
            // 
            // GroupBoxNicDetails
            // 
            resources.ApplyResources(GroupBoxNicDetails, "GroupBoxNicDetails");
            GroupBoxNicDetails.Controls.Add(TbCurrentDhcp);
            GroupBoxNicDetails.Controls.Add(TbCurrentMac);
            GroupBoxNicDetails.Controls.Add(TbCurrentFirewall);
            GroupBoxNicDetails.Controls.Add(TbCurrentDNS);
            GroupBoxNicDetails.Controls.Add(TbCurrentGateway);
            GroupBoxNicDetails.Controls.Add(TbCurrentMask);
            GroupBoxNicDetails.Controls.Add(TbCurrentIP);
            GroupBoxNicDetails.Controls.Add(LblLangDhcpServer);
            GroupBoxNicDetails.Controls.Add(LblLangWifi);
            GroupBoxNicDetails.Controls.Add(LblLangFirewall);
            GroupBoxNicDetails.Controls.Add(LblLangDns);
            GroupBoxNicDetails.Controls.Add(LblLangGateway);
            GroupBoxNicDetails.Controls.Add(LblLangMask);
            GroupBoxNicDetails.Controls.Add(LblLangIP);
            GroupBoxNicDetails.Name = "GroupBoxNicDetails";
            GroupBoxNicDetails.TabStop = false;
            GroupBoxNicDetails.Enter += GroupBox1_Enter;
            // 
            // TbCurrentDhcp
            // 
            resources.ApplyResources(TbCurrentDhcp, "TbCurrentDhcp");
            TbCurrentDhcp.Name = "TbCurrentDhcp";
            TbCurrentDhcp.ReadOnly = true;
            TbCurrentDhcp.Click += CurrentDetails_Click;
            // 
            // TbCurrentMac
            // 
            resources.ApplyResources(TbCurrentMac, "TbCurrentMac");
            TbCurrentMac.Name = "TbCurrentMac";
            TbCurrentMac.ReadOnly = true;
            TbCurrentMac.Click += CurrentDetails_Click;
            // 
            // TbCurrentFirewall
            // 
            resources.ApplyResources(TbCurrentFirewall, "TbCurrentFirewall");
            TbCurrentFirewall.Name = "TbCurrentFirewall";
            TbCurrentFirewall.ReadOnly = true;
            TbCurrentFirewall.Click += CurrentDetails_Click;
            // 
            // TbCurrentDNS
            // 
            resources.ApplyResources(TbCurrentDNS, "TbCurrentDNS");
            TbCurrentDNS.Name = "TbCurrentDNS";
            TbCurrentDNS.ReadOnly = true;
            TbCurrentDNS.Click += CurrentDetails_Click;
            // 
            // TbCurrentGateway
            // 
            resources.ApplyResources(TbCurrentGateway, "TbCurrentGateway");
            TbCurrentGateway.Name = "TbCurrentGateway";
            TbCurrentGateway.ReadOnly = true;
            TbCurrentGateway.Click += CurrentDetails_Click;
            // 
            // TbCurrentMask
            // 
            resources.ApplyResources(TbCurrentMask, "TbCurrentMask");
            TbCurrentMask.Name = "TbCurrentMask";
            TbCurrentMask.ReadOnly = true;
            TbCurrentMask.Click += CurrentDetails_Click;
            // 
            // TbCurrentIP
            // 
            resources.ApplyResources(TbCurrentIP, "TbCurrentIP");
            TbCurrentIP.Name = "TbCurrentIP";
            TbCurrentIP.ReadOnly = true;
            TbCurrentIP.Click += CurrentDetails_Click;
            // 
            // LblLangDhcpServer
            // 
            resources.ApplyResources(LblLangDhcpServer, "LblLangDhcpServer");
            LblLangDhcpServer.Name = "LblLangDhcpServer";
            // 
            // LblLangWifi
            // 
            resources.ApplyResources(LblLangWifi, "LblLangWifi");
            LblLangWifi.Name = "LblLangWifi";
            // 
            // LblLangFirewall
            // 
            resources.ApplyResources(LblLangFirewall, "LblLangFirewall");
            LblLangFirewall.Name = "LblLangFirewall";
            // 
            // LblLangDns
            // 
            resources.ApplyResources(LblLangDns, "LblLangDns");
            LblLangDns.Name = "LblLangDns";
            // 
            // LblLangGateway
            // 
            resources.ApplyResources(LblLangGateway, "LblLangGateway");
            LblLangGateway.Name = "LblLangGateway";
            // 
            // LblLangMask
            // 
            resources.ApplyResources(LblLangMask, "LblLangMask");
            LblLangMask.Name = "LblLangMask";
            // 
            // LblLangIP
            // 
            resources.ApplyResources(LblLangIP, "LblLangIP");
            LblLangIP.Name = "LblLangIP";
            LblLangIP.Click += LblLangIP_Click;
            // 
            // BtnGetIP
            // 
            resources.ApplyResources(BtnGetIP, "BtnGetIP");
            BtnGetIP.Name = "BtnGetIP";
            BtnGetIP.UseVisualStyleBackColor = true;
            BtnGetIP.Click += BtnGetIP_Click;
            // 
            // BtnGetAdapters
            // 
            resources.ApplyResources(BtnGetAdapters, "BtnGetAdapters");
            BtnGetAdapters.Name = "BtnGetAdapters";
            BtnGetAdapters.UseVisualStyleBackColor = true;
            BtnGetAdapters.Click += BtnGetAdapters_Click;
            // 
            // lblTransAdapter
            // 
            resources.ApplyResources(lblTransAdapter, "lblTransAdapter");
            lblTransAdapter.Name = "lblTransAdapter";
            // 
            // trayMenu
            // 
            resources.ApplyResources(trayMenu, "trayMenu");
            trayMenu.ImageScalingSize = new Size(20, 20);
            trayMenu.Items.AddRange(new ToolStripItem[] { trayMenuTools, trayMenuSeparator1, trayExit });
            trayMenu.Name = "trayMenu";
            // 
            // trayMenuTools
            // 
            resources.ApplyResources(trayMenuTools, "trayMenuTools");
            trayMenuTools.Name = "trayMenuTools";
            // 
            // trayMenuSeparator1
            // 
            resources.ApplyResources(trayMenuSeparator1, "trayMenuSeparator1");
            trayMenuSeparator1.Name = "trayMenuSeparator1";
            // 
            // trayExit
            // 
            resources.ApplyResources(trayExit, "trayExit");
            trayExit.Name = "trayExit";
            trayExit.Click += TrayExit_Click;
            // 
            // trayIcon
            // 
            trayIcon.BalloonTipIcon = ToolTipIcon.Info;
            resources.ApplyResources(trayIcon, "trayIcon");
            trayIcon.ContextMenuStrip = trayMenu;
            trayIcon.MouseClick += TrayIcon_MouseClick;
            // 
            // IPChangerMainWindow
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblTransAdapter);
            Controls.Add(BtnGetAdapters);
            Controls.Add(BtnGetIP);
            Controls.Add(GroupBoxNicDetails);
            Controls.Add(CbNicSelect);
            Controls.Add(BtnTabAdd);
            Controls.Add(BtnHideToTray);
            Controls.Add(BtnExit);
            Controls.Add(tabControl1);
            Controls.Add(BtnReconnect);
            Controls.Add(mainMenu);
            MainMenuStrip = mainMenu;
            MaximizeBox = false;
            Name = "IPChangerMainWindow";
            Load += Form_Load;
            mainMenu.ResumeLayout(false);
            mainMenu.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            GroupBox0.ResumeLayout(false);
            GroupBox0.PerformLayout();
            GroupBoxNicDetails.ResumeLayout(false);
            GroupBoxNicDetails.PerformLayout();
            trayMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private async void MMToolsPublicIP_Click(object sender, EventArgs e)
        {
            // Replace with your desired URL.
            string url = "http://tools.yts.au/ip.php";

            Readers reader = new Readers();
            await reader.ReadUrlAsync(url);
        }

        private void MMToolsOpenNetworkSharing_Click(object sender, EventArgs e)
        {
            //            throw new NotImplementedException();
            ExecuteCommand("control", "/name Microsoft.NetworkAndSharingCenter");
        }

        private void MMToolsOpenNetworkConnections_Click(object sender, EventArgs e)
        {
//            throw new NotImplementedException();
            ExecuteCommand("control", "ncpa.cpl");
        }

        #endregion

        private NotifyIcon trayIcon;
        private ContextMenuStrip trayMenu;


        private Button BtnReconnect;
        private MenuStrip mainMenu;
        private ToolStripMenuItem MMFileMenu;
        private ToolStripMenuItem MMFileExit;
        private ToolStripMenuItem MMToolsMenu;
        private ToolStripMenuItem MMToolsPingHostname;
        private ToolStripMenuItem MMHelpMenu;
        private ToolStripMenuItem MMHelpAbout;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button BtnExit;
        private Button BtnHideToTray;
        private Button BtnTabAdd;
        public ComboBox CbNicSelect;
        private GroupBox GroupBoxNicDetails;
        private Button BtnGetIP;
        private Button BtnGetAdapters;
        private GroupBox GroupBox0;
        private Label lblConfig0Name;
        private TextBox TbConfig0Name;
        private Label lblConfig0IP;
        private TextBox TbConfig0IP;
        private TextBox TbConfig0Dns;
        private TextBox TbConfig0Gateway;
        private TextBox TbConfig0Mask;
        private CheckBox CbConfig0Dhcp;
        private Label lblConfig0Dns;
        private Label lblConfig0Gateway;
        private Label lblConfig0Mask;
        private Label LblLangWifi;
        private Label LblLangFirewall;
        private Label LblLangDns;
        private Label LblLangGateway;
        private Label LblLangMask;
        private Label LblLangIP;
        private Label LblLangDhcpServer;
        private TextBox TbCurrentGateway;
        private TextBox TbCurrentMask;
        private TextBox TbCurrentIP;
        private TextBox TbCurrentDNS;
        private TextBox TbCurrentDhcp;
        private TextBox TbCurrentMac;
        private TextBox TbCurrentFirewall;
        private Label lblTransAdapter;
        private ToolStripSeparator trayMenuSeparator1;
        private ToolStripMenuItem trayExit;
        private ToolStripMenuItem trayMenuTools;
        private ToolStripMenuItem MMToolsOpenNetworkConnections;
        private ToolStripMenuItem MMToolsOpenNetworkSharing;
        private ToolStripMenuItem MMToolsPublicIP;
    }
}

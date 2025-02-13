using System.Net.NetworkInformation;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using NetFwTypeLib; // Add reference to `FirewallAPI.dll` for firewall settings
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace IPChanger
{
    public partial class IPChangerMainWindow : Form
    {
        private bool allowExit = false;
        private const uint WM_SHOWAPP = 0x0400 + 1;  // Custom Windows Message

        public IPChangerMainWindow()
        {
            InitializeComponent();

            // Attach event handler for window resizing
            this.Resize += MainForm_Resize;

            // Handle form closing event (for close button)
            this.FormClosing += MainForm_FormClosing;

            // Handle key press event (for Escape key)
            this.KeyPreview = true;  // Enables key events to be handled at form level
            this.KeyDown += MainForm_KeyDown;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            //ToDo add functions to read the IP information into the App (if Adapter was known)
//            LoadNetworkInterfaces(); // OLD way of loading interfaces
            List<Dictionary<string, string>> networkAdapters = GetNetworkInfo();
            LoadNetworkInterfaces();
        }

        private void BtnReconnect_Click(object sender, EventArgs e)
        {
            RestartNetworkAdapter();
//            MessageBox.Show(this,"Testing Reconnect");

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void BtnGetAdapters_Click(object sender, EventArgs e)
        {
            LoadNetworkInterfaces();
//            MessageBox.Show(this,"Testing Get Adapters");
        }
        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ToolsPing_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this,"Testing Ping MenuItem");
        }

        private void BtnGetIP_Click(object sender, EventArgs e)
        {
            List<Dictionary<string, string>> networkAdapters = GetNetworkInfo();
            CbNicSelect_SelectionChanged(sender,e);
            MessageBox.Show(this,"Testing Get IP Button\nTodo add some disable / enable or clearing of the displayed items...");
        }

        private void HelpAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this,"IPChanger is an Application that allows the user to pre-define a list of networks and set a network adapter to use this config in a few clicks\n\nGoogle: 'IPChanger Securetech' for more information");
        }
        private void TbConfig_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show(this,"Config Text Changed");
        }

        private void CbConfig0Dhcp_CheckedChanged(object sender, EventArgs e)
        {
            if (!CbConfig0Dhcp.Checked)
            {
                // Enable the Textboxes
                TbConfig0IP.Enabled = true;
                TbConfig0Mask.Enabled = true;
                TbConfig0Gateway.Enabled = true;
                TbConfig0Dns.Enabled = true;
                // Enable the labels
                lblConfig0IP.Enabled = true;
                lblConfig0Mask.Enabled = true;
                lblConfig0Gateway.Enabled = true;
                lblConfig0Dns.Enabled = true;
            }
            else
            {
                // Disable the Textboxes
                TbConfig0IP.Enabled = false;
                TbConfig0Mask.Enabled = false;
                TbConfig0Gateway.Enabled = false;
                TbConfig0Dns.Enabled = false;
                // Disable the Labels
                lblConfig0IP.Enabled = false;
                lblConfig0Mask.Enabled = false;
                lblConfig0Gateway.Enabled = false;
                lblConfig0Dns.Enabled = false;
            }
        }

        private void LblLangIP_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this,"Testing LblLangIP");
        }

        private void CurrentDetails_Click(object sender, EventArgs e)
        {
            // Cast the sender to a TextBox
            if (sender is System.Windows.Forms.TextBox textBox)
            {
                // Retrieve the text
                string text = textBox.Text;

                // Copy the text to the clipboard
                Clipboard.SetText(text);

                // Optionally, notify the user
                MessageBox.Show(this, $"Text: '{text}'\n\nCopied to clipboard!");
            }
        }

        private static void STG_GetAdapters()  // To get current ethernet config
        {
            var ip = "";
            var dns = "";
            var nic = "";
            string[] NwDesc = { "TAP", "VMware", "Windows", "Virtual" };  // Adapter types (Description) to be ommited
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet && !NwDesc.Any(ni.Description.Contains))  // check for adapter type and its description
                {

                    foreach (IPAddress dnsAdress in ni.GetIPProperties().DnsAddresses)
                    {
                        if (dnsAdress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            dns = dnsAdress.ToString();
                        }
                    }



                    foreach (UnicastIPAddressInformation ips in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ips.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork && !ips.Address.ToString().StartsWith("169")) //to exclude automatic ips
                        {
                            ip = ips.Address.ToString();
                            nic = ni.Name;
                        }
                    }
                }
            }

        }

        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ToggleAppVisibility();
            }
        }

/*        private void ShowApp(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
        }
*/
        private void HideApp(object sender, EventArgs e)
        {
//            MessageBox.Show(this,"Testing Hide App");
            ToggleAppVisibility();
        }

        private void ExitApp(object sender, EventArgs e)
        {
            //            trayIcon.Visible = false;
            ExitApplication();
        }


        private void ToggleAppVisibility()
        {
            if (this.Visible)
            {
                this.Hide();
                ShowTrayNotification("Application Hidden", "IPChanger is still running in the system tray.");
            }
            else
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void NicSelect_LostFocus(object sender, EventArgs e)
        {
/*
 *          BtnGetIP.Enabled = false;
            MessageBox.Show(this,"Testing Nic Selection");
            BtnGetIP.Enabled = true;
//            throw new NotImplementedException();
*/
        }

        private void BtnTabAdd_Click(object sender, EventArgs e)
        {
//            throw new NotImplementedException();
            MessageBox.Show(this,"When Implemented, This will add a config TAB with sample config","Testing");
        }

        private void TrayExit_Click(object sender, EventArgs e)
        {
            //            trayIcon.Visible = false;
            //            MessageBox.Show(this,"Exit");
            ExitApplication();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                HideApp(sender,e);
                ShowTrayNotification("Application Hidden", "IPChanger is still running in the system tray.");
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowExit) // If Application.Exit() was NOT explicitly called
            {
                e.Cancel = true; // Cancel the close action
                HideApp(sender,e); // Hide to tray instead
                ShowTrayNotification("Application Hidden", "IPChanger is still running in the system tray.");
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                HideApp(sender,e);
                ShowTrayNotification("Application Hidden", "IPChanger is still running in the system tray.");
            }
        }

        private void ShowTrayNotification(string title, string message)
        {
            trayIcon.BalloonTipTitle = title;
            trayIcon.BalloonTipText = message;
            trayIcon.BalloonTipIcon = ToolTipIcon.Info; // Info, Warning, or Error
            trayIcon.ShowBalloonTip(3000); // Show for 3 seconds
        }

        private void ExitApplication()
        {
            allowExit = true; // Allow the application to exit
            Application.Exit();
        }

        // 🔹 UPDATED: Override `WndProc` to listen for the restore message
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SHOWAPP)
            {
                ShowApp(); // Call ShowApp() when message is received
            }
            base.WndProc(ref m);
        }

        // 🔹 UPDATED: Ensure this restores the window even if hidden
        public void ShowApp()
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.BringToFront();
//                trayIcon.Visible = false; // Hide tray icon if applicable
            });
        }

        private List<Dictionary<string, string>> GetNetworkInfo()
        {
//            List<Dictionary<string, string>> networkDetails = new List<Dictionary<string, string>>();
            List<Dictionary<string, string>> networkDetails = [];

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
//                Dictionary<string, string> adapterInfo = new Dictionary<string, string>
                Dictionary<string, string> adapterInfo = new ()
                {
                    { "Name", nic.Name }
                };

                // Get IP, Subnet, and Gateway information
                IPInterfaceProperties ipProps = nic.GetIPProperties();
//                List<string> ipAddresses = new List<string>();
                List<string> ipAddresses = [];
//                List<string> ipAddressesV6 = new List<string>();
                List<string> ipAddressesV6 = [];
//                List<string> subnets = new List<string>();
                List<string> subnets = [];
                //                List<string> subnetsV6 = new List<string>();
//                List<string> gateways = new List<string>();
                List<string> gateways = [];
//                List<string> dnsServers = new List<string>();
                List<string> dnsServers = [];
//                List<string> dnsServersV6 = new List<string>();
                List<string> dnsServersV6 = [];

                // Get IP & Subnet Mask
                foreach (UnicastIPAddressInformation ip in ipProps.UnicastAddresses)
                {
                    if (ip.Address.AddressFamily == AddressFamily.InterNetwork) // IPv4 only
                    {
                        ipAddresses.Add(ip.Address.ToString());
                        subnets.Add(ip.IPv4Mask.ToString());
                    } else if (ip.Address.AddressFamily == AddressFamily.InterNetworkV6)
                    {
                        ipAddressesV6.Add(ip.Address.ToString());
//                        subnetsV6.Add(ip.IPv4Mask.ToString());
                    }
                }

                foreach (GatewayIPAddressInformation gateway in ipProps.GatewayAddresses)
                {
                    gateways.Add(gateway.Address.ToString());
                }

                foreach (IPAddress dns in ipProps.DnsAddresses)
                {
                    if (dns.AddressFamily == AddressFamily.InterNetwork) // IPv4 only
                    {
                        dnsServers.Add(dns.ToString());
                    } else if (dns.AddressFamily == AddressFamily.InterNetworkV6)
                    {
                        dnsServersV6.Add(dns.ToString());
                    }
                }

                // Get DHCP Server
                string dhcpServer = "Not Found";
                try
                {
                    foreach (var dhcp in ipProps.DhcpServerAddresses)
                    {
                        dhcpServer = dhcp.ToString();
                        break;
                    }
                }
                catch { }

                // Get Firewall Profile
                string firewallProfile = GetFirewallProfile(nic.Name);

                // Get WiFi SSID (Only for Wireless Interfaces)
                //                string wifiSSID = nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ? GetWiFiSSID() : "N/A";

                string macAddress = "";
                if (nic != null)
                {
                    byte[] bytes = nic.GetPhysicalAddress().GetAddressBytes();
                    macAddress = string.Join(":", bytes.Select(b => b.ToString("X2")));
                }
                else
                {
                    MessageBox.Show("Selected adapter not found.");
                }


                // Store collected data in the dictionary for this adapter
                adapterInfo["IP"] = string.Join(", ", ipAddresses);
                adapterInfo["IPv6"] = string.Join(", ", ipAddressesV6);
                adapterInfo["Subnet"] = string.Join(", ", subnets);
                adapterInfo["Gateway"] = string.Join(", ", gateways);
                adapterInfo["DNS"] = string.Join(", ", dnsServers);
                adapterInfo["DNSv6"] = string.Join(", ", dnsServersV6);
                adapterInfo["DHCP"] = dhcpServer;
                adapterInfo["Firewall"] = firewallProfile;
                adapterInfo["MAC"] = macAddress;
//                adapterInfo["WiFi-SSID"] = wifiSSID;

                // Add this adapter information to the list for all adapters Details
                networkDetails.Add(adapterInfo);
            }

            return networkDetails;
        }

/*
                private string GetWiFiSSID()
                {
                    try
                    {
                        string query = "SELECT * FROM MSNdis_80211_ServiceSetIdentifier";
                        ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\WMI", query);
                        foreach (ManagementObject obj in searcher.Get())
                        {
                            byte[] ssidBytes = (byte[])obj["Ndis80211SsId"];
                            return System.Text.Encoding.ASCII.GetString(ssidBytes);
                        }
                    }
                    catch { }

                    return "Unknown";
                }

*/
        private string GetFirewallProfile(string interfaceName)
        {
            try
            {
                Type type = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
                INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(type);

                int profileType = firewallPolicy.CurrentProfileTypes;
                return profileType switch
                {
                    1 => "Domain",
                    2 => "Private",
                    4 => "Public",
                    _ => "Unknown"
                };
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

/*
        private string GetFirewallProfile(string interfaceName)
        {
            try
            {
                Type type = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
                dynamic firewallPolicy = Activator.CreateInstance(type);

                int profileType = firewallPolicy.CurrentProfileTypes;
                return profileType switch
                {
                    1 => "Domain",
                    2 => "Private",
                    4 => "Public",
                    _ => "Unknown"
                };
            }
            catch
            {
                return "Error";
            }
        }
*/

        private void LoadNetworkInterfaces()
        {
            var ip = "";
            var mask = "";
            var gw = "";
            var dns = "";
            var nicName = "";
            string[] NwDesc = { "TAP", "VMware", "Windows", "Virtual", "Loopback", "VPN" };  // Adapter types (Description) to be ommited
                    CbNicSelect.Items.Clear(); // Clear existing items
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (!NwDesc.Any(nic.Description.Contains))  // check for adapter type and its description
                { 
                    CbNicSelect.Items.Add(nic.Name); // Add the interface name to the ComboBox
//                            MessageBox.Show($"Name: {nic.Name}\nStatus: {nic.OperationalStatus}");
                    if (CbNicSelect.Items.Count > 0)
                    {
                        if (nic.OperationalStatus.ToString() == "Up")
                        {
                            CbNicSelect.SelectedIndex = (CbNicSelect.Items.Count)-1;
                        } else
                        {
                            CbNicSelect.SelectedIndex = 0; // Select the first interface by default
                        }
                    }
                }
            }
        }


        private void CbNicSelect_SelectionChanged(object sender, EventArgs e)
        {
            string selectedNic = CbNicSelect.SelectedItem.ToString();

            List<Dictionary<string, string>> networkAdapters = GetNetworkInfo();

            foreach (var adapter in networkAdapters)
            {
                if (adapter["Name"] == selectedNic)
                {
                    TbCurrentIP.Text = adapter["IP"];
                    TbCurrentMask.Text = adapter["Subnet"];
                    TbCurrentDNS.Text = adapter["DNS"];
                    TbCurrentGateway.Text = adapter["Gateway"];
                    TbCurrentMac.Text = adapter["MAC"];
                    TbCurrentFirewall.Text = adapter["Firewall"];
                    TbCurrentDhcp.Text = adapter["DHCP"];
                }
                Console.WriteLine($"Adapter: {adapter["Name"]}");
                Console.WriteLine($"IP: {adapter["IP"]}");
                Console.WriteLine($"Subnet: {adapter["Subnet"]}");
                Console.WriteLine($"Gateway: {adapter["Gateway"]}");
                Console.WriteLine($"DNS: {adapter["DNS"]}");
                Console.WriteLine($"MAC: {adapter["MAC"]}");
                Console.WriteLine($"DHCP: {adapter["DHCP"]}");
                Console.WriteLine($"Firewall: {adapter["Firewall"]}");
                Console.WriteLine("------------------------------------------------");
            }
        }

        private void CbNicSelect_SelectionChanged_old(object sender, EventArgs e)
        {
            string selectedNic = CbNicSelect.SelectedItem.ToString();


//
            NetworkInterface nic = NetworkInterface.GetAllNetworkInterfaces()
                .FirstOrDefault(n => n.Name == selectedNic);

            if (nic != null)
            {
                var ip = "";
                var mask = "";
                var SuffixOrigin = "";
                var type = "";
                var gw = "";
                var dns = "";
                var nicName = "";
                var nicStatus = "";


                foreach (IPAddress dnsAdress in nic.GetIPProperties().DnsAddresses)
                {
                    if (dnsAdress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        dns = dnsAdress.ToString();
                    }
                }

                foreach (UnicastIPAddressInformation ips in nic.GetIPProperties().UnicastAddresses)
                {
                    if (ips.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork && !ips.Address.ToString().StartsWith("169")) //to exclude automatic ips
                    {
                        ip = ips.Address.ToString();
                        mask = ips.IPv4Mask.ToString();
                        SuffixOrigin = ips.SuffixOrigin.ToString();
                        type = nic.NetworkInterfaceType.ToString();
                        nicStatus = nic.OperationalStatus.ToString();
                        nicName = nic.Name;
                    }
                }

                List<Dictionary<string, string>> networkAdapters = GetNetworkInfo();


                foreach (var adapter in networkAdapters)
                {
                    if (adapter["Name"] == selectedNic)
                    {
                        TbCurrentMask.Text = adapter["Subnet"];
                    }
                    Console.WriteLine($"Adapter: {adapter["Name"]}");
                    Console.WriteLine($"IP: {adapter["IP"]}");
                    Console.WriteLine($"Subnet: {adapter["Subnet"]}");
                    Console.WriteLine($"Gateway: {adapter["Gateway"]}");
                    Console.WriteLine($"DNS: {adapter["DNS"]}");
                    Console.WriteLine($"DHCP: {adapter["DHCP"]}");
                    Console.WriteLine($"Firewall: {adapter["Firewall"]}");
                    Console.WriteLine($"WiFi SSID: {adapter["WiFi SSID"]}");
                    Console.WriteLine("------------------------------------------------");
                }
                /*

                                var ipProperties = NetworkInterface.GetIPProperties();
                                var gatewayAddresses = ipProperties.GatewayAddresses;

                                foreach (var gateway in gatewayAddresses)
                                {
                                    Console.WriteLine($"Network Interface: {networkInterface.Name}");
                                    Console.WriteLine($"Gateway Address: {gateway.Address}");
                                }

                                //********  Testing Start  ********
                                var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

                                foreach (var networkInterface in networkInterfaces)
                                {
                                    var ipProperties = nic.GetIPProperties();
                                    var gatewayAddresses = ipProperties.GatewayAddresses;

                                    foreach (var gateway in gatewayAddresses)
                                    {
                                        Console.WriteLine($"Network Interface: {networkInterface.Name}");
                                        Console.WriteLine($"Gateway Address: {gateway.Address}");
                                    }
                                }
                                */
                //********  Testing End  ********




                //                MessageBox.Show(this,$"Selected NIC: {nicName}\nStatus: {nicStatus}\nType: {type}\nIP Address: {ip}\nDNS Server: {dns}\nSpeed: {((nic.Speed)/1024)/1024} Mb\nIP Address: {ip}");

                TbCurrentIP.Text = ip;
                TbCurrentMask.Text = mask;
                TbCurrentDNS.Text = dns;
                TbCurrentGateway.Text = gw;
                TbCurrentFirewall.Text = type;

            }
        }

        private void ExecuteCommand(string FileNameIn, string arguments = "", bool AsAdmin = false)
        {
//            MessageBox.Show($"Running the following: '{FileNameIn} {arguments}' with AsAdmin={AsAdmin}");
            ProcessStartInfo psi;
            if (AsAdmin == true)
            {
                psi = new ProcessStartInfo
                {
                    FileName = FileNameIn,
                    Arguments = arguments,
//                    RedirectStandardOutput = true,
//                    RedirectStandardError = true,
                    UseShellExecute = true,
                    CreateNoWindow = true,           // Ignored when UseShellExecute is true
                    WindowStyle = ProcessWindowStyle.Hidden, // Hide the window when using shellexec
                    Verb = "runas" // Run as administrator
                };
            } 
            else
            {
                psi = new ProcessStartInfo
                {
                    FileName = FileNameIn,
                    Arguments = arguments,
//                    RedirectStandardOutput = true,         // cannot use with ShellExec
//                    RedirectStandardError = true,          // cannot use with ShellExec
                    UseShellExecute = true,
                    CreateNoWindow = true,           // Ignored when UseShellExecute is true
                    WindowStyle = ProcessWindowStyle.Hidden, // Hide the window when using shellexec
                };
            }

            using (Process process = new Process { StartInfo = psi })
            {
                process.Start();
                process.WaitForExit();
            }
        }

        private async void RestartNetworkAdapter()
        {
            if (CbNicSelect.SelectedItem == null)
            {
                MessageBox.Show("Please select a network adapter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string adapterName = CbNicSelect.SelectedItem.ToString();

            try
            {
                // Disable the adapter
                ExecuteCommand("Netsh",$"interface set interface \"{adapterName}\" admin=disable", true);

                // Wait for 1 seconds
//                await Task.Delay(1000);

                // Enable the adapter
                ExecuteCommand("Netsh",$"interface set interface \"{adapterName}\" admin=enable", true);

                ShowTrayNotification("IPChanger", $"Network adapter '{adapterName}' has been restarted successfully.");
//                MessageBox.Show(this, $"Network adapter '{adapterName}' has been restarted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Error restarting adapter '{adapterName}': {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}


/*
public class WindowHelper
{
    private const int SW_SHOW = 5;
    private const int SW_RESTORE = 9;

    [DllImport("user32.dll")]
    private static extern bool IsWindowVisible(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);

    /// <summary>
    /// Shows the window pointed by the handle. 
    /// If the window is hidden, it is shown; if it is minimized, it is restored.
    /// Finally, the window is brought to the front.
    /// </summary>
    /// <param name="handle">Handle to the window.</param>
    public static void ShowProcess(IntPtr handle)
    {
        if (handle == IntPtr.Zero) return;

        if (!IsWindowVisible(handle))
        {
            // If the window is hidden, show it.
            ShowWindow(handle, SW_SHOW);
        }
        else
        {
            // If the window is visible (or minimized), restore it.
            ShowWindow(handle, SW_RESTORE);
        }

        // Bring the window to the foreground.
        SetForegroundWindow(handle);
    }
}
*/
public class Readers
{
    /// <summary>
    /// Asynchronously reads text from the given URL, copies it to the clipboard, and displays it in a message box.
    /// </summary>
    /// <param name="url">The URL to read the text from.</param>
    public async Task ReadUrlAsync(string url)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                // Asynchronously get the string content from the URL.
                string content = await client.GetStringAsync(url);

                // Copy the retrieved content to the clipboard.
                Clipboard.SetText(content);

                // Show the content in a message box.
                MessageBox.Show(content, "URL Content", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
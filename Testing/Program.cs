using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Threading;
using IPChanger;

namespace IPChanger
{
    internal static class Program
    {
        private static Mutex mutex = new Mutex(true, "IPChangerCSharpMutex"); // Unique name
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!mutex.WaitOne(TimeSpan.Zero, true))
            {
                // If another instance is running, bring it to the front
                BringToFront();
                MessageBox.Show("Application already running.\nPlease check for Tray Icon.","Duplicate Instance");
                return; // Exit the new instance
            }
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new IPChangerMainWindow());

            mutex.ReleaseMutex(); // Release when exiting
        }

        // Function to bring the existing app to the front
        private static void BringToFront()
        {
            Process currentProcess = Process.GetCurrentProcess();
            foreach (Process process in Process.GetProcessesByName(currentProcess.ProcessName))
            {
                if (process.Id != currentProcess.Id) // Find the original instance
                {
                    WindowHelper.ShowProcess(process.MainWindowHandle);
//                    ShowProcess(process.MainWindowHandle);
                    break;
                }
            }
        }
/*
        // Import Windows API to show the existing app
        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private const int SW_SHOWNORMAL = 1; 
        private const int SW_SHOW = 5;
        private const int SW_RESTORE = 9;
*/
//      This is the original function, which was superseeded
        /*
                private static void ShowProcess(IntPtr handle)
                {
                    if (handle == IntPtr.Zero) return;

                    ShowWindow(handle, SW_RESTORE); // Restore the window

                    SetForegroundWindow(handle); // Bring it to the front
                }
        */
/*
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
                ShowWindow(handle, SW_SHOWNORMAL);
            }
            else
            {
                // If the window is visible (or minimized), restore it.
                ShowWindow(handle, SW_RESTORE);
            }

            // Bring the window to the foreground.
            SetForegroundWindow(handle);
        }
*/
    }

}


public static class WindowHelper
{
    /*
    SW_HIDE(0) – Hides the window and activates another one.
    SW_SHOWNORMAL(1) – Activates and displays a window, restoring it to original size if minimized or maximized.
    There are more options for the ShowWindow() second argument:

    SW_NORMAL – Same as SW_SHOWNORMAL(value 1, for compatibility).
    SW_SHOWMINIMIZED(2) – Activates the window and displays it minimized.
    SW_SHOWMAXIMIZED(3) – Activates and displays the window maximized.
    SW_MAXIMIZE(3) – Maximizes the window.
    SW_SHOWNOACTIVATE(4) – Displays the window without activation.
    SW_SHOW(5) – Activates and displays it in its current size/position.
    SW_MINIMIZE(6) – Minimizes the window and activates the next in Z order.
    SW_SHOWMINNOACTIVE(7) – Minimizes the window without activation.
    SW_SHOWNA(8) – Displays the window in current size/position without activation.
    SW_RESTORE(9) – Restores a minimized/maximized window.
    SW_SHOWDEFAULT(10) – Sets based on the application’s start state.
    SW_FORCEMINIMIZE(11) – Minimizes window even if unresponsive.
    */
    private const int SW_SHOWNORMAL = 1;
    private const int SW_RESTORE = 9;
    private const uint SWP_NOMOVE = 0x0002;
    private const uint SWP_NOSIZE = 0x0001;
    private const uint SWP_SHOWWINDOW = 0x0040;

    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool SetWindowPos(
        IntPtr hWnd,
        IntPtr hWndInsertAfter,
        int X,
        int Y,
        int cx,
        int cy,
        uint uFlags);

    /// <summary>
    /// Forces the window identified by the handle to be shown even if hidden,
    /// and then brings it to the foreground.
    /// </summary>
    /// <param name="handle">The window handle.</param>
    public static void ShowProcess(IntPtr handle)
    {
        if (handle == IntPtr.Zero)
            return;

        //This should unhide the window
        ShowWindow(handle, SW_SHOWNORMAL);

        // Restore the window (if minimized, etc.)
//        ShowWindow(handle, SW_RESTORE);

        // Force the window to show by updating its position flags.
        SetWindowPos(handle, IntPtr.Zero, 0, 0, 0, 0,
            SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);

        // Bring the window to the foreground.
        SetForegroundWindow(handle);
    }
    /*
    public static void IPCShowWindow()
    {

        // Assuming mainForm is your main form instance.
        IPChangerMainWindow.Invoke((Action)(() =>
        {
            IPChangerMainWindow.Show();
            if (IPChangerMainWindow.WindowState == FormWindowState.Minimized)
            {
                IPChangerMainWindow.WindowState = FormWindowState.Normal;
            }
            IPChangerMainWindow.BringToFront();
            IPChangerMainWindow.Activate();
        }));
    }
    */
}
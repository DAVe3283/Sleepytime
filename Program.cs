using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Sleepytime
{
    class Program
    {
        #region DLL Imports
        /// <summary>
        /// Lock the workstation.
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/aa376875%28v=vs.85%29.aspx
        /// </summary>
        /// <returns>Nonzero means success</returns>
        [DllImport("user32.dll")]
        private static extern Int32 LockWorkStation();

        /// <summary>
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms644950%28v=vs.85%29.aspx
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="Msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(
            IntPtr hWnd,
            UInt32 Msg,
            IntPtr wParam,
            IntPtr lParam
        );
        #endregion DLL Imports

        // Things that would be in a C header somewhere
        // https://msdn.microsoft.com/en-us/library/windows/desktop/ms646360%28v=vs.85%29.aspx
        private const UInt32 WM_SYSCOMMAND = 0x0112;
        private static IntPtr SC_MONITORPOWER = (IntPtr)0xF170;
        private static IntPtr SC_MONITORPOWER_Off = (IntPtr)2;

        static int Main(string[] args)
        {
            // Lock the workstation
            if (LockWorkStation() == 0)
            {
                MessageBox.Show(
                    "Unable to lock the workstation!\nLockWorkStation() API call failed.",
                    "Can't lock PC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                return 1;
            }

            // Put monitors into powersave mode
            using (Form tempForm = new Form())
            {
                SendMessage(tempForm.Handle, WM_SYSCOMMAND, SC_MONITORPOWER, SC_MONITORPOWER_Off);
            }

            // Done! Now get to sleep!
            return 0;
        }
    }
}

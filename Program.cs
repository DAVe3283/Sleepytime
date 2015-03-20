using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Sleepytime
{
    class Program
    {
        #region DLL Imports
        [DllImport("user32")]
        public static extern void LockWorkStation();
        #endregion DLL Imports

        static void Main(string[] args)
        {
            LockWorkStation();
            // TODO: powersave monitors
        }
    }
}

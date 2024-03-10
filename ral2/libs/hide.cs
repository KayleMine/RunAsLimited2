using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ral2
{
    public class helper
    {
        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hwnd, uint dwAffinity);

        const uint WDA_EXCLUDEFROMCAPTURE = 0x00000011;
        const uint WDA_NONE = 0x00000000;

        public void Hide(IntPtr Handle)
        {
            SetWindowDisplayAffinity(Handle, WDA_EXCLUDEFROMCAPTURE);
        }
        public void Unhide(IntPtr handle)
        {
            SetWindowDisplayAffinity(handle, WDA_NONE); // Set the window display affinity to none (remove exclusion)
        }
    }
}

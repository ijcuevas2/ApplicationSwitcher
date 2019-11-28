using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSwitcher.Model
{
    public class ChildWindowSummary
    {
        public string title;
        public uint lpdwProcessId;
        public IntPtr windowHandle;

        public ChildWindowSummary(string title, uint lpdwProcessId, IntPtr windowHandle)
        {
            this.title = title;
            this.lpdwProcessId = lpdwProcessId;
            this.windowHandle = windowHandle;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSwitcher.Service
{
    // A service is injected into the constructor of a class.
    public interface IProgramDataService
    {
        void retrieveRunningWindows();
    }
}

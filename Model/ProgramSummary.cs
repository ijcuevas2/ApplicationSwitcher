using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSwitcher.Model
{
    public class ProgramSummary
    {
        public Process mainWindowProcess;
        Icon programIcon;
        public List<ChildWindowSummary> childProgramSummaries;

        public ProgramSummary(Process process, Icon icon)
        {
            mainWindowProcess = process;
            programIcon = icon;
            childProgramSummaries = new List<ChildWindowSummary>();
        }
        public void AddChildWindowSummary(ChildWindowSummary childWindowSummary)
        {
            childProgramSummaries.Add(childWindowSummary);
        }
    }
}

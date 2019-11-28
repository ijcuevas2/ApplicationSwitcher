using System;
using System.Windows.Automation;
using System.Windows.Media;


namespace ApplicationSwitcher.Model
{
    public class WindowSummary
    {
       public AutomationElement Element { get; set; }
       public ImageSource ProgramIcon { get; set; }
       public string ProgramName { get; set; }
       public string ProgramWindowTitle { get; set; }
    }
}

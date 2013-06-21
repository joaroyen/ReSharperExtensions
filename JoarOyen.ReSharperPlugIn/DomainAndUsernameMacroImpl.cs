using System.Diagnostics;
using System.Security.Principal;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;

namespace JoarOyen.ReSharperPlugIn
{
    [MacroImplementation(Definition = typeof(DomainAndUsernameMacro))]
    public class DomainAndUsernameMacroImpl : QuickParameterlessMacro
    {
        public override string QuickEvaluate(string value)
        {
            var windowsIdentity = WindowsIdentity.GetCurrent();
            Debug.Assert(windowsIdentity != null);
            string name = windowsIdentity.Name;

            if (value != null && value.Contains("\\"))
            {
                name = name.Replace("\\", "\\\\");
            }

            return name;
        }
 
    }
}
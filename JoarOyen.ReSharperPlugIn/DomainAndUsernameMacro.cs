using System.Diagnostics;
using System.Security.Principal;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;

namespace JoarOyen.ReSharperPlugIn
{
    [Macro("JoarOyenLiveTemplateMacros.DomainAndUsername",
      ShortDescription = "Current username with domain",
      LongDescription = "Current username with domain on the format <Domain>\\<Username>")]
    public class DomainAndUsernameMacro : QuickParameterlessMacro
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
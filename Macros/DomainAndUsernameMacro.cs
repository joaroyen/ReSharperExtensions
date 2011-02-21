using System.Threading;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;

namespace JoarOyen.Tools.ReSharper.Macros
{
    [Macro("JoarOyenLiveTemplateMacros.DomainAndUsername",
      ShortDescription = "Current username with domain",
      LongDescription = "Current username with domain on the format <Domain>\\<Username>")]
    public class DomainAndUsernameMacro : QuickParameterlessMacro
    {
        public override string QuickEvaluate(string value)
        {
            return Thread.CurrentPrincipal.Identity.Name;
        }
    }
}
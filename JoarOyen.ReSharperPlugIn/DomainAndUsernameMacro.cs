using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;

namespace JoarOyen.ReSharperPlugIn
{
    [MacroDefinition("JoarOyenLiveTemplateMacros.DomainAndUsername",
      ShortDescription = "Current username with domain",
      LongDescription = "Current username with domain on the format <Domain>\\<Username>")]
    public class DomainAndUsernameMacro : SimpleMacroDefinition
    {
    }
}
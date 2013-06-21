using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;

namespace JoarOyen.ReSharperPlugIn
{
    [MacroDefinition("JoarOyenLiveTemplateMacros.CapitalizedWordsIdentifier",
        ShortDescription = "Ensures that given variable is a valid C# identifier and capitalizes the first character of each word",
        LongDescription = "Replaces invalid characters in a C# identifier with underscores and capitalizes the first character of each word")]
    public class CapitalizedWordsIdentifierMacro : SimpleMacroDefinition
    {
    }
}
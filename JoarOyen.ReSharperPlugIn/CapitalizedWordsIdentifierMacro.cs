using System.Text;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;

namespace JoarOyen.ReSharperPlugIn
{
    [Macro("JoarOyenLiveTemplateMacros.CapitalizedWordsIdentifier",
        ShortDescription = "Ensures that given variable is a valid C# identifier and capitalizes the first character of each word",
        LongDescription = "Replaces invalid characters in a C# identifier with underscores and capitalizes the first character of each word")]
    public class CapitalizedWordsIdentifierMacro : QuickParameterlessMacro
    {
        public override string QuickEvaluate(string value)
        {
            var _identifierBuilder = new IdentifierBuilder(value);
            _identifierBuilder.TransformToValidIdentifier();
            _identifierBuilder.CapitalizeFirstCharacterInEveryWord();
            return _identifierBuilder.ToString();
        }
    }
}
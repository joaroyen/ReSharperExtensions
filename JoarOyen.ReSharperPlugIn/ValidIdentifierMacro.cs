using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;

namespace JoarOyen.ReSharperPlugIn
{
    [Macro("JoarOyenLiveTemplateMacros.ValidIdentifier",
      ShortDescription = "Ensures that given variable is a valid C# identifier",
      LongDescription = "Replaces invalid characters in a C# identifier with underscores")]
    public class ValidIdentifierMacro : QuickParameterlessMacro
    {
        public override string QuickEvaluate(string value)
        {
            var _identifierBuilder = new IdentifierBuilder(value);
            _identifierBuilder.TransformToValidIdentifier();
            return _identifierBuilder.ToString();
        }
    }
}
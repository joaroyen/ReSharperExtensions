using System.Text;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;

namespace JoarOyen.Tools.ReSharper.Macros
{
    [Macro("JoarOyenLiveTemplateMacros.ValidIdentifier",
      ShortDescription = "Ensures that given variable is a valid C# identifier",
      LongDescription = "Replaces invalid characters in a C# identifier with underscores")]
    public class ValidIdentifierMacro : QuickParameterlessMacro
    {
        public override string QuickEvaluate(string value)
        {
            return TransformToValidIdentifier(value);
        }

        private static string TransformToValidIdentifier(string value)
        {
            if (string.IsNullOrEmpty(value)) return value;

            var validIdentifier = new StringBuilder(value);

            PrefixWithUnderscoreIfNotStartingWithACharacter(validIdentifier);
            ReplaceInvalidCharactersWithUnderscore(validIdentifier);

            return validIdentifier.ToString();
        }

        private static void PrefixWithUnderscoreIfNotStartingWithACharacter(StringBuilder validIdentifier)
        {
            if (!char.IsLetter(validIdentifier[0]) && validIdentifier[0] != '_')
            {
                validIdentifier.Insert(0, '_');
            }
        }

        private static void ReplaceInvalidCharactersWithUnderscore(StringBuilder validIdentifier)
        {
            for (int i = 0; i < validIdentifier.Length; i++)
            {
                if (!char.IsLetterOrDigit(validIdentifier[i]))
                {
                    validIdentifier[i] = '_';
                }
            }
        }
    }
}
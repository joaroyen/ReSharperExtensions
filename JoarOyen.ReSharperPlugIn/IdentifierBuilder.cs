using System.Text;

namespace JoarOyen.ReSharperPlugIn
{
    public class IdentifierBuilder
    {
        private StringBuilder _identifier;

        public IdentifierBuilder(string value)
        {
            _identifier = new StringBuilder(value);
        }

        public override string ToString()
        {
            return _identifier.ToString();
        }

        public void TransformToValidIdentifier()
        {
            if (_identifier.Length == 0) return; 

            PrefixWithUnderscoreIfNotStartingWithACharacter();
            ReplaceInvalidCharactersWithUnderscore();
        }

        private void PrefixWithUnderscoreIfNotStartingWithACharacter()
        {
            if (!char.IsLetter(_identifier[0]) && _identifier[0] != '_')
            {
                _identifier.Insert(0, '_');
            }
        }

        private void ReplaceInvalidCharactersWithUnderscore()
        {
            for (int i = 0; i < _identifier.Length; i++)
            {
                if (!char.IsLetterOrDigit(_identifier[i]))
                {
                    _identifier[i] = '_';
                }
            }
        }

        public void CapitalizeFirstCharacterInEveryWord()
        {
            if (_identifier.Length == 0) return;
            
            _identifier[0] = char.ToUpper(_identifier[0]);

            for (int i = 1; i < _identifier.Length; i++)
            {
                if (_identifier[i - 1] == '_')
                {
                    _identifier[i] = char.ToUpper(_identifier[i]);
                }
            }
        }
    }
}
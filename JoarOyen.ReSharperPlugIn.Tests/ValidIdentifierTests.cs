using NUnit.Framework;

namespace JoarOyen.ReSharperPlugIn.Tests
{
    [TestFixture]
    public class ValidIdentifierTests
    {
        private readonly ValidIdentifierMacroImpl _validIdentifierMacro = new ValidIdentifierMacroImpl();

        [TestCase(Category = "Unit")]
        public void Empty_identifier_returns_empty()
        {
            Assert.That(_validIdentifierMacro.QuickEvaluate(""), Is.EqualTo(""));
        }

        [TestCase(Category = "Unit")]
        public void Valid_identifier_returns_an_unmodified_value()
        {
            Assert.That(_validIdentifierMacro.QuickEvaluate("This_is_a_valid_identifier42"), Is.EqualTo("This_is_a_valid_identifier42"));
        }

        [TestCase(Category = "Unit")]
        public void An_identifier_starting_with_a_number_is_prefixed_with_an_underscore()
        {
            Assert.That(_validIdentifierMacro.QuickEvaluate("1InvalidIdentifier"), Is.EqualTo("_1InvalidIdentifier"));
        }

        [TestCase(Category = "Unit")]
        public void An_identifier_starting_with_an_underscore_is_not_prefixed_with_another_underscore()
        {
            Assert.That(_validIdentifierMacro.QuickEvaluate("_1InvalidIdentifier"), Is.EqualTo("_1InvalidIdentifier"));
        }

        [TestCase(Category = "Unit")]
        public void Invalid_characters_in_an_identifier_is_replaced_with_underscores()
        {
            Assert.That(_validIdentifierMacro.QuickEvaluate("Invalid identifier #/!-"), Is.EqualTo("Invalid_identifier_____"));
        }

        [TestCase(Category = "Unit")]
        public void Norwegian_characters_are_valid()
        {
            Assert.That(_validIdentifierMacro.QuickEvaluate("Valid_norwegian_identifier_æøåÆØÅ"), Is.EqualTo("Valid_norwegian_identifier_æøåÆØÅ"));
        }
    }
}
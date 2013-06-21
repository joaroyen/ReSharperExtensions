using NUnit.Framework;

namespace JoarOyen.ReSharperPlugIn.Tests
{
    [TestFixture]
    public class CapitalizedWordsIdentifierMacroTests
    {
        private readonly CapitalizedWordsIdentifierMacroImpl _capitalizedWordsIdentifierMacro = new CapitalizedWordsIdentifierMacroImpl();
        
        [TestCase(Category = "Unit")]
        public void Empty_identifier_returns_empty()
        {
            Assert.That(_capitalizedWordsIdentifierMacro.QuickEvaluate(""), Is.EqualTo(""));
        }

        [TestCase(Category = "Unit")]
        public void The_first_character_is_capitalized()
        {
            Assert.That(_capitalizedWordsIdentifierMacro.QuickEvaluate("identifier"), Is.EqualTo("Identifier"));
        }

        [TestCase(Category = "Unit")]
        public void Every_character_after_an_underscore_is_capitalize()
        {
            Assert.That(
                _capitalizedWordsIdentifierMacro.QuickEvaluate("first_character_of_every_word_should_be_capitaliced_including_i"), 
                Is.EqualTo("First_Character_Of_Every_Word_Should_Be_Capitaliced_Including_I"));            
        }

        [TestCase(Category = "Unit")]
        public void An_identifier_can_start_with_an_underscore()
        {
            Assert.That(
                _capitalizedWordsIdentifierMacro.QuickEvaluate("_identifier_starting_with_an_underscore"), 
                Is.EqualTo("_Identifier_Starting_With_An_Underscore"));
        }

        [TestCase(Category = "Unit")]
        public void An_identifier_can_contain_multiple_underscores_in_a_row()
        {
            Assert.That(
                _capitalizedWordsIdentifierMacro.QuickEvaluate("identifier___with_multiple__underscores"), 
                Is.EqualTo("Identifier___With_Multiple__Underscores"));
        }
    }
}
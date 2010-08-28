using JoarOyen.Tools.ReSharper.Macros;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Macros.Tests.Unit
{
    [TestClass]
    public class ValidIdentifierTests
    {
        readonly ValidIdentifierMacro _validIdentifierMacro = new ValidIdentifierMacro();

        [TestMethod, TestCategory("Unit"), Owner("HOME\\joaro")]
        public void Empty_identifier_returns_empty()
        {
            Assert.AreEqual("", _validIdentifierMacro.QuickEvaluate(""));
        }

        [TestMethod, TestCategory("Unit"), Owner("HOME\\joaro")]
        public void Valid_identifier_returns_an_unmodified_value()
        {
            Assert.AreEqual("This_is_a_valid_identifier42", _validIdentifierMacro.QuickEvaluate("This_is_a_valid_identifier42"));
        }

        [TestMethod, TestCategory("Unit"), Owner("HOME\\joaro")]
        public void An_identifier_starting_with_a_number_is_prefixed_with_an_underscore()
        {
            Assert.AreEqual("_1InvalidIdentifier", _validIdentifierMacro.QuickEvaluate("1InvalidIdentifier"));
        }

        [TestMethod, TestCategory("Unit"), Owner("HOME\\joaro")]
        public void An_identifier_starting_with_an_underscore_is_not_prefixed_with_another_underscore()
        {
            Assert.AreEqual("_1InvalidIdentifier", _validIdentifierMacro.QuickEvaluate("_1InvalidIdentifier"));
        }

        [TestMethod, TestCategory("Unit"), Owner("HOME\\joaro")]
        public void Invalid_characters_in_an_identifier_is_replaced_with_underscores()
        {
            Assert.AreEqual("Invalid_identifier_____", _validIdentifierMacro.QuickEvaluate("Invalid identifier #/!-"));
        }

        [TestMethod, TestCategory("Unit"), Owner("HOME\\joaro")]
        public void Norwegian_characters_are_valid()
        {
            Assert.AreEqual("Valid_norwegian_identifier_æøåÆØÅ", _validIdentifierMacro.QuickEvaluate("Valid_norwegian_identifier_æøåÆØÅ"));
        }
    }
}
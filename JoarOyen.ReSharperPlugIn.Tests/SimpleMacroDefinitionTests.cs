using NUnit.Framework;

namespace JoarOyen.ReSharperPlugIn.Tests
{
    [TestFixture]
    public class SimpleMacroDefinitionTests
    {
        private SimpleMacroDefinition _simpleMacroDefinition;

        [SetUp]
        public void SetUp()
        {
            _simpleMacroDefinition = new DomainAndUsernameMacro();
        }

        [TestCase(Category = "Unit")]
        public void Has_no_parameters()
        {
            Assert.That(_simpleMacroDefinition.Parameters, Has.Length.EqualTo(0));
        }
 
        [TestCase(Category="Unit")]
        public void Has_a_dummy_placeholder()
        {
            Assert.That(_simpleMacroDefinition.GetPlaceholder(null, null), Is.EqualTo("a"));
        }

    }
}
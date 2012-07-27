using NUnit.Framework;

namespace JoarOyen.ReSharperPlugIn.Tests
{
    [TestFixture]
    public class DomainAndUsernameMacroTests
    {
        private readonly DomainAndUsernameMacro _domainAndUsernameMacro = new DomainAndUsernameMacro();

        [TestCase(Category = "Unit")]
        public void Getting_the_current_domain_and_username_returns_domain_and_user_name_with_one_escaped_backslash_when_not_at_hotspot()
        {
            Assert.That(_domainAndUsernameMacro.QuickEvaluate(null), Contains.Substring("\\"));
        }

        [TestCase(Category = "Unit")]
        public void Getting_the_current_domain_and_username_returns_domain_and_user_name_with_two_escaped_backslash_when_at_hotspot()
        {
            Assert.That(_domainAndUsernameMacro.QuickEvaluate("domain\\user"), Contains.Substring("\\\\"));
        }
    }
}
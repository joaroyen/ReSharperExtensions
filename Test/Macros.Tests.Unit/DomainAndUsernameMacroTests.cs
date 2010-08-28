using JoarOyen.Tools.ReSharper.Macros;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Macros.Tests.Unit
{
    [TestClass]
    public class DomainAndUsernameMacroTests
    {
        private readonly DomainAndUsernameMacro _domainAndUsernameMacro = new DomainAndUsernameMacro();

        [TestMethod, TestCategory("Unit"), Owner("HOME\\joaro")]
        public void Getting_the_current_domain_and_username_returns_an_non_empty_string()
        {
            Assert.IsFalse(string.IsNullOrEmpty(_domainAndUsernameMacro.QuickEvaluate(null)));
        }
    }
}
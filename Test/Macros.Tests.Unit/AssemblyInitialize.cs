using System;
using System.Security.Principal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Macros.Tests.Unit
{
    [TestClass]
    public class AssemblyInitialize
    {
        [AssemblyInitialize]
        public static void Initialize(TestContext context)
        {
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
        }
    }
}

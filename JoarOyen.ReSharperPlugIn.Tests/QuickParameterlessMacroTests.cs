using System.Collections.Generic;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Hotspots;
using JetBrains.ReSharper.LiveTemplates;
using NSubstitute;
using NUnit.Framework;

namespace JoarOyen.ReSharperPlugIn.Tests
{
    [TestFixture]
    public class QuickParameterlessMacroTests
    {
        private QuickParameterlessMacro _quickParamterlessMacro;
        private IHotspotContext _context;
        private IHotspotSession _hotspotSession;

        [SetUp]
        public void SetUp()
        {
            _quickParamterlessMacro = new DomainAndUsernameMacroImpl();
            _hotspotSession = CreateFakeHotspotSession();
            _context = CreateFakeHotspotContext(_hotspotSession);
        }

        [TestCase(Category="Unit")]
        public void Has_no_lookup_items()
        {
            Assert.That(_quickParamterlessMacro.GetLookupItems(null), Is.Null);
        }

        [TestCase(Category = "Unit")]
        public void Evaluates_to_null_for_templates_without_hotspots()
        {
            var hotspotSession = Substitute.For<IHotspotSession>();
            hotspotSession.Hotspots.Returns(new List<Hotspot>());
            var context = Substitute.For<IHotspotContext>();
            context.HotspotSession.Returns(hotspotSession);

            Assert.That(_quickParamterlessMacro.EvaluateQuickResult(context), Is.Null);
        }

        [TestCase(Category = "Unit"), Ignore("Unable to create fake valid hotspot")]
        public void Evaluates_to_a_non_empty_string_for_templates_with_a_valid_hotspot()
        {
            Assert.That(_quickParamterlessMacro.EvaluateQuickResult(_context), Has.Length.GreaterThan(0));
        }

        [TestCase(Category = "Unit")]
        public void Handle_expansion_returns_false()
        {
            Assert.That(_quickParamterlessMacro.HandleExpansion(_context), Is.False);
        }

        [TestCase(Category = "Unit")]
        public void Test()
        {
            _quickParamterlessMacro.HotspotSessionHotspotUpdated(_hotspotSession, null);
        }

        private IHotspotContext CreateFakeHotspotContext(IHotspotSession hotspotSession)
        {
            var context = Substitute.For<IHotspotContext>();
            context.HotspotSession.Returns(hotspotSession);
            return context;
        }

        private IHotspotSession CreateFakeHotspotSession()
        {
            var hotspotSession = Substitute.For<IHotspotSession>();
            //var templateField = new TemplateField("", new MacroCallExpressionNew(_quickParamterlessMacro), 0);
            //var hotspot = new Hotspot(new HotspotInfo(templateField), hotspotSession);
            //var rangeMarger = Substitute.For<IRangeMarker>();
            //hotspot.RangeMarkers.Add(rangeMarger);

            var hotspots = new List<Hotspot>
            {
                new Hotspot(new HotspotInfo(new TemplateField("", 0)), hotspotSession)
                //, 
                //hotspot
            };
            hotspotSession.Hotspots.Returns(hotspots);
            return hotspotSession;
        }
    }
}
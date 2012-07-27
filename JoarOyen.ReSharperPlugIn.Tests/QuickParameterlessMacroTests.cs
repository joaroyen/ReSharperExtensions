using System.Collections.Generic;
using JetBrains.DocumentModel;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Hotspots;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;
using JetBrains.ReSharper.LiveTemplates;
using NSubstitute;
using NUnit.Framework;

namespace JoarOyen.ReSharperPlugIn.Tests
{
    [TestFixture]
    public class QuickParameterlessMacroTests
    {
        private readonly QuickParameterlessMacro _quickParamterlessMacro;
        private readonly IHotspotContext _context;
        private readonly IHotspotSession _hotspotSession;

        public QuickParameterlessMacroTests()
        {
            _quickParamterlessMacro = new DomainAndUsernameMacro();
            _hotspotSession = CreateFakeHotspotSession();
            _context = CreateFakeHotspotContext(_hotspotSession);
        }

        [TestCase(Category="Unit")]
        public void Has_no_parameters()
        {
            Assert.That(_quickParamterlessMacro.Parameters, Has.Length.EqualTo(0));
        }

        [TestCase(Category="Unit")]
        public void Has_no_lookup_items()
        {
            Assert.That(_quickParamterlessMacro.GetLookupItems(null, null), Is.Null);
        }

        [TestCase(Category="Unit")]
        public void Has_a_dummy_placeholder()
        {
            Assert.That(_quickParamterlessMacro.GetPlaceholder(null), Is.EqualTo("a"));
        }

        [TestCase(Category = "Unit")]
        public void Evaluates_to_null_for_templates_without_hotspots()
        {
            var hotspotSession = Substitute.For<IHotspotSession>();
            hotspotSession.Hotspots.Returns(new List<Hotspot>());
            var context = Substitute.For<IHotspotContext>();
            context.HotspotSession.Returns(hotspotSession);

            Assert.That(_quickParamterlessMacro.EvaluateQuickResult(context, null), Is.Null);
        }

        [TestCase(Category = "Unit")]
        public void Evaluates_to_a_non_empty_string_for_templates_with_a_valid_hotspot()
        {
            Assert.That(_quickParamterlessMacro.EvaluateQuickResult(_context, null), Has.Length.GreaterThan(0));
        }

        [TestCase(Category = "Unit")]
        public void Handle_expansion_returns_false()
        {
            Assert.That(_quickParamterlessMacro.HandleExpansion(_context, null), Is.False);
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
            var templateField = new TemplateField("", new MacroCallExpression(_quickParamterlessMacro), 0);
            var hotspot = new Hotspot(new HotspotInfo(templateField), hotspotSession);
            var rangeMarger = Substitute.For<IRangeMarker>();
            hotspot.RangeMarkers.Add(rangeMarger);

            var hotspots = new List<Hotspot>
            {
                new Hotspot(new HotspotInfo(new TemplateField("", 0)), hotspotSession), 
                hotspot
            };
            hotspotSession.Hotspots.Returns(hotspots);
            return hotspotSession;
        }
    }
}
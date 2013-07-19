using System;
using System.Linq;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Hotspots;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;

namespace JoarOyen.ReSharperPlugIn
{
    public abstract class QuickParameterlessMacro : SimpleMacroImplementation
    {
        public abstract string QuickEvaluate(string value);

        public override string EvaluateQuickResult(IHotspotContext context)
        {
            var q = 
                from hotspot in context.HotspotSession.Hotspots
                where ShouldHandle(hotspot)
                select QuickEvaluate(HotspotValue(hotspot));
            
            return q.FirstOrDefault();
        }

        public override bool HandleExpansion(IHotspotContext context)
        {
            context.HotspotSession.HotspotUpdated += HotspotSessionHotspotUpdated;

            return false;
        }

        public void HotspotSessionHotspotUpdated(object sender, EventArgs e)
        {
            var hotspotSession = (IHotspotSession)sender;

            foreach (var hotspot in hotspotSession.Hotspots)
            {
                if (ShouldHandle(hotspot))
                {
                    hotspot.QuickEvaluate();
                }
            }
        }

        private bool ShouldHandle(Hotspot hotspot)
        {
            if (hotspot == null) return false;

            var macroCallExpressionNew = hotspot.Expression as MacroCallExpressionNew;
            if (macroCallExpressionNew == null) return false;

            return ThisImplementationsMacroDefinition().IsInstanceOfType(macroCallExpressionNew.Definition);
        }

        private Type ThisImplementationsMacroDefinition()
        {
            var macroDefinitionTypeOfCurrentImplementation = (MacroImplementationAttribute)GetType().GetCustomAttributes(
                typeof (MacroImplementationAttribute), true).First();

            return macroDefinitionTypeOfCurrentImplementation.Definition;
        }

        private string HotspotValue(Hotspot hotspot)
        {
            return string.IsNullOrEmpty(hotspot.CurrentValue) ? hotspot.Name : hotspot.CurrentValue;
        }
    }
}

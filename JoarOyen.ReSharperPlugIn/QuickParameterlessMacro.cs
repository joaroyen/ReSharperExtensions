using System.Diagnostics;
using System.Linq;
using System.Reflection;
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

        public void HotspotSessionHotspotUpdated(object sender, System.EventArgs e)
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

            var macroImplementationType = TryAndGetMacroImplementationFromPrivateFields(hotspot);

            return macroImplementationType != null && GetType().IsInstanceOfType(macroImplementationType);
        }

        private static object TryAndGetMacroImplementationFromPrivateFields(Hotspot hotspot)
        {
            var expressionField = hotspot.GetType().GetField("myExpression", BindingFlags.NonPublic | BindingFlags.Instance);
            Debug.Assert(expressionField != null);
            var expression = expressionField.GetValue(hotspot);
            if (expression == null)
            {
                return null;
            }

            var macroImplementationField = expression.GetType().GetField("myImplementation", BindingFlags.NonPublic | BindingFlags.Instance);
            Debug.Assert(macroImplementationField != null);
            
            return macroImplementationField.GetValue(expression);
        }

        private string HotspotValue(Hotspot hotspot)
        {
            return string.IsNullOrEmpty(hotspot.CurrentValue) ? hotspot.Name : hotspot.CurrentValue;
        }
    }
}

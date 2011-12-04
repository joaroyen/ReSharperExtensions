using System.Collections.Generic;
using JetBrains.DocumentModel;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Hotspots;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;
using JetBrains.Util;

namespace JoarOyen.Tools.ReSharper.Macros
{
    public abstract class QuickParameterlessMacro : IMacro
    {
        public abstract string QuickEvaluate(string value);

        public ParameterInfo[] Parameters
        {
            get { return EmptyArray<ParameterInfo>.Instance; }
        }

        public HotspotItems GetLookupItems(IHotspotContext context, IList<string> arguments)
        {
            return null;
        }

        public string GetPlaceholder(IDocument document)
        {
            return "a";
        }

        public string EvaluateQuickResult(IHotspotContext context, IList<string> arguments)
        {
            foreach (var hotspot in context.HotspotSession.Hotspots)
            {
                if (ShouldHandle(hotspot))
                {
                    return QuickEvaluate(HotspotValue(hotspot));
                }
            }

            return null;
        }

        public bool HandleExpansion(IHotspotContext context, IList<string> arguments)
        {
            context.HotspotSession.HotspotUpdated += HotspotSessionHotspotUpdated;

            return false;
        }

        private void HotspotSessionHotspotUpdated(object sender, System.EventArgs e)
        {
            var hotspotSession = (HotspotSession)sender;

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

            var macroCallExpression = hotspot.Expression as MacroCallExpression;

            return macroCallExpression != null &&
                   GetType().IsInstanceOfType(macroCallExpression.Macro);
        }

        private string HotspotValue(Hotspot hotspot)
        {
            return string.IsNullOrEmpty(hotspot.CurrentValue) ? hotspot.Name : hotspot.CurrentValue;
        }
    }
}

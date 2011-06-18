using System.Collections.Generic;
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

        public string GetPlaceholder()
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
            context.HotspotSession.Closed += HotspotSessionClosed;

            return false;
        }

        private void HotspotSessionClosed(IHotspotSession hotspotSession, TerminationType arg2)
        {
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
            if (string.IsNullOrEmpty(hotspot.CurrentValue))
            {
                return hotspot.Name;
            }

            return hotspot.CurrentValue;
        }
    }
}

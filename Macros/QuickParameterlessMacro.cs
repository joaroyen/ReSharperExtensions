using System.Collections.Generic;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Hotspots;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;

namespace JoarOyen.Tools.ReSharper.Macros
{
    public abstract class QuickParameterlessMacro : IMacro
    {
        public abstract string QuickEvaluate(string value);

        public ParameterInfo[] Parameters
        {
            get { return new ParameterInfo[] { }; }
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
            var currentHotspot = new CurrentHotspot(context.HotspotSession);
            return QuickEvaluate(currentHotspot.Value);
        }

        public bool HandleExpansion(IHotspotContext context, IList<string> arguments)
        {
            context.HotspotSession.HotspotUpdated += HotspotSessionHotspotUpdated;
            return false;
        }

        private static void HotspotSessionHotspotUpdated(object sender, System.EventArgs e)
        {
            var currentHotspot = new CurrentHotspot((HotspotSession)sender);
            currentHotspot.InvokeEvaluateQuickResult();
        }
    }
}

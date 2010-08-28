using System.Collections.Generic;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Hotspots;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;
using JetBrains.ReSharper.Feature.Services.Lookup;

namespace JoarOyen.Tools.ReSharper.Macros
{
    [Macro("JoarOyenLiveTemplateMacros.RecentItemList",
      ShortDescription = "List of recent items",
      LongDescription = "List of recent items")]
    public class RecentItemListMacro : QuickParameterlessMacro
    {
        public override string QuickEvaluate(string value)
        {
            return value;
        }

        public override HotspotItems GetLookupItems(IHotspotContext context, IList<string> arguments)
        {
            return new HotspotItems(new List<ILookupItem>() { new TextLookupItem("Value 1"), new TextLookupItem("Value 2") });   
        }
    }
}
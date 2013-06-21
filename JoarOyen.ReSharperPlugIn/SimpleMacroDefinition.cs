using System.Collections.Generic;
using JetBrains.DocumentModel;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;
using JetBrains.Util;

namespace JoarOyen.ReSharperPlugIn
{
    public class SimpleMacroDefinition : IMacroDefinition
    {
        public string GetPlaceholder(IDocument document, IEnumerable<IMacroParameterValue> parameters)
        {
            return "a";
        }

        public ParameterInfo[] Parameters
        {
            get
            {
                return EmptyArray<ParameterInfo>.Instance;
            }
        }
    }
}
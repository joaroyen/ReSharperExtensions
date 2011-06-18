using JetBrains.ReSharper.Feature.Services.LiveTemplates.Hotspots;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;
using JetBrains.TextControl;
using JetBrains.TextControl.Coords;

namespace JoarOyen.Tools.ReSharper.Macros
{
    public class CurrentHotspot
    {
        private readonly IHotspotSession _hotspotSession;
        private ITextControlPos _caretPosition;

        public CurrentHotspot(IHotspotSession hotspotSession)
        {
            _hotspotSession = hotspotSession;
        }

        public bool ValueShouldBeHandledBy(IMacro macro)
        {
            if (_hotspotSession.CurrentHotspot == null)
            {
                return true;
            }

            var macroCallExpression = _hotspotSession.CurrentHotspot.Expression as MacroCallExpression;
            if (macroCallExpression != null &&
                macroCallExpression.Macro.GetType() == macro.GetType())
            {
                return true;
            }

            return false;
        }
        
        public void InvokeEvaluateQuickResult()
        {
            SaveCaretPosition();
            _hotspotSession.CurrentHotspot.QuickEvaluate();
            RestoreCaretPosition();
        }

        public string Value
        {
            get
            {
                return _hotspotSession.CurrentHotspot == null ? null : _hotspotSession.CurrentHotspot.CurrentValue;
            }
        }

        private void SaveCaretPosition()
        {
            _caretPosition = _hotspotSession.Context.TextControl.Caret.Position.Value;
        }

        private void RestoreCaretPosition()
        {
            _hotspotSession.Context.TextControl.Caret.MoveTo(_caretPosition, CaretVisualPlacement.Generic);
        }
    }
}
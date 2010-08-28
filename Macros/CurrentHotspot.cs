using JetBrains.ReSharper.Feature.Services.LiveTemplates.Hotspots;
using JetBrains.TextControl;
using JetBrains.TextControl.Coords;

namespace JoarOyen.Tools.ReSharper.Macros
{
    public class CurrentHotspot
    {
        private readonly HotspotSession _hotspotSession;
        private ITextControlPos _caretPosition;

        public CurrentHotspot(HotspotSession hotspotSession)
        {
            _hotspotSession = hotspotSession;
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
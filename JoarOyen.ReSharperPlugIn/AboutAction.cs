using System.Windows.Forms;
using JetBrains.ActionManagement;
using JetBrains.Application.DataContext;

namespace JoarOyen.ReSharperPlugIn
{
  [ActionHandler("JoarOyen.ReSharperPlugIn.About")]
  public class AboutAction : IActionHandler
  {
    public bool Update(IDataContext context, ActionPresentation presentation, DelegateUpdate nextUpdate)
    {
      // return true or false to enable/disable this action
      return true;
    }

    public void Execute(IDataContext context, DelegateExecute nextExecute)
    {
      MessageBox.Show(
        "Joar Øyen's extensions for ReSharper\nJoar Øyen\n\nContains Live Templates and macros for writing test methods",
        "About Joar Øyen's extensions for ReSharper",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);
    }
  }
}

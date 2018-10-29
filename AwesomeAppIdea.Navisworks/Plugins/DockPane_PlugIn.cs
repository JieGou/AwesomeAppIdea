using Autodesk.Navisworks.Api.Plugins;
using AwesomeAppIdea.Core.Constants;
using AwesomeAppIdea.UI.View;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace AwesomeAppIdea.Navisworks.Plugins
{
    [DockPanePlugin(800, 600, FixedSize = false, MinimumHeight = 800, MinimumWidth = 600)]
    [Plugin(AppConstants.APP_NAME, "AWESOME", DisplayName = "Awesome App Idea")]
    public class DockPane_PlugIn : DockPanePlugin
    {
        public override Control CreateControlPane()
        {
            var mainview = new Main_View();

            ElementHost element = new ElementHost()
            {
                AutoSize = true,
                Child = mainview
            };

            element.CreateControl();

            return element;
        }

        public override void DestroyControlPane(Control pane)
        {
            pane?.Dispose();
        }
    }
}
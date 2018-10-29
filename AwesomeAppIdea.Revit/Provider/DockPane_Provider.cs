using Autodesk.Revit.UI;
using AwesomeAppIdea.UI.View;

namespace Streamliner.Revit.Client.Providers
{
    public class DockPane_Provider : IDockablePaneProvider
    {
        public void SetupDockablePane(DockablePaneProviderData data)
        {
            data.FrameworkElement = new Main_View();
            
            data.InitialState = new DockablePaneState()
            {
                DockPosition = DockPosition.Tabbed,
                TabBehind = DockablePanes.BuiltInDockablePanes.PropertiesPalette,  
            };

#if !REVIT2016

            data.EditorInteraction = new EditorInteraction(EditorInteractionType.KeepAlive);

#endif
        }
    }
}
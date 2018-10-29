using Autodesk.Revit.UI;
using System;

namespace AwesomeAppIdea.Revit.Extensions
{
    public static class DockPane_Extensions
    {
        public static bool PaneExists(this UIApplication application, Guid id, out DockablePane pane)
        {
            var dPid = new DockablePaneId(id);
            if (DockablePane.PaneExists(dPid))
            {
                pane = application.GetDockablePane(dPid);
                
                return true;
            }
            pane = null;
            return false;
        }
    }
}
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using AwesomeAppIdea.Core.Constants;
using AwesomeAppIdea.Revit.Extensions;
using System;

namespace AwesomeAppIdea.Revit.Commands
{
    [Transaction(TransactionMode.ReadOnly)]
    public class DockPaneShow_Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            if (commandData.Application.PaneExists(new Guid(AppConstants.APP_ID), out DockablePane _pane))
            {
                if (!_pane.IsShown()) _pane.Show();
            }

            return Result.Succeeded;
        }
    }
}
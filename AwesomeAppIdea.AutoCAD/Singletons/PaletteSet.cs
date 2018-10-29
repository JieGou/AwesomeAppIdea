using AwesomeAppIdea.Core.Constants;
using AwesomeAppIdea.UI.View;
using System;

namespace AwesomeAppIdea.AutoCAD.Singleton
{
    public class PaletteSet
    {
        private static PaletteSet _current;

        public static PaletteSet Current
        {
            get
            {
                if (_current != null) return _current;

                lock (_synclock)
                {
                    if (_current == null)
                    {
                        _current = new PaletteSet();
                    }
                }
                return _current;
            }
        }

        public Autodesk.AutoCAD.Windows.PaletteSet Palette { get; private set; }

        private static readonly object _synclock = new object();

        public void WireUp()
        {
            Palette = new Autodesk.AutoCAD.Windows.PaletteSet(AppConstants.APP_NAME, Commands.Commands.PALETTESET_COMMAND, new Guid(AppConstants.APP_ID))
            {
                MinimumSize = new System.Drawing.Size(800, 600), 
            };
            Palette.AddVisual("Main", new Main_View(), true);
        }

        public void Load()
        {
            Palette.Visible = true;
        }
    }
}
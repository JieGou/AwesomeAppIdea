using System.ComponentModel;

namespace AwesomeAppIdea.Core.Enums
{
    public enum Products
    {
        None = -1,

        [Description("AutoCAD")]
        ACAD = 0,

        [Description("Navisworks")]
        NAVIS = 1,

        [Description("Revit")]
        REVIT = 2,
    }
}
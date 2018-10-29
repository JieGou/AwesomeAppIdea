using System.ComponentModel;

namespace AwesomeAppIdea.Revit.Enums
{
    public enum Versions
    {
        [Description("Architecture")]
        Architecture = 0,

        [Description("Structure")]
        Structure = 1,

        [Description("MEP")]
        MEP = 2,

        [Description("Revit")]
        Revit = 4,

        [Description("LT")]
        LT = 8,

        [Description("Unknown")]
        Unknown = 16
    }
}
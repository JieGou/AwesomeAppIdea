using System.ComponentModel;

namespace AwesomeAppIdea.AutoCAD.Enums
{
    public enum Versions
    {
        None = -1,

        [Description("R20.1")]
        R20_1 = 0,

        [Description("R21.0")]
        R21_0 = 1,

        [Description("R22.0")]
        R22_0 = 2,

        [Description("R23.0")]
        R23_0 = 4,
    }
}
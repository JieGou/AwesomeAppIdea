using Autodesk.Navisworks.Api.ApplicationParts;
using AwesomeAppIdea.Core.Enums;

namespace AwesomeAppIdea.Navisworks.Extensions
{
    public static class Version_Extensions
    {
        public static Enums.Versions GetVersion(this ApplicationVersion version)
        {
            if (version.RuntimeProductName.Contains("Manage"))
            {
                return Enums.Versions.Manage;
            }
            else if (version.RuntimeProductName.Contains("Simulate"))
            {
                return Enums.Versions.Simulate;
            }
            else
            {
                return Enums.Versions.Freedom;
            }
        }

        public static Years GetYear(this ApplicationVersion version)
        {
            int RuntimeVersion = version.RuntimeMajor;

            if (RuntimeVersion == 13)
            {
                return Years.Y2016;
            }
            else if (RuntimeVersion == 14)
            {
                return Years.Y2017;
            }
            else if (RuntimeVersion == 15)
            {
                return Years.Y2018;
            }
            else if (RuntimeVersion == 16)
            {
                return Years.Y2019;
            }
            else
            {
                return Years.None;
            }
        }
    }
}
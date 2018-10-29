using AwesomeAppIdea.AutoCAD.Enums;
using AwesomeAppIdea.Core.Enums;
using System;

namespace AwesomeAppIdea.AutoCAD.Helpers
{
    public struct Application_Helpers
    {
        public static string Language()
        {
            string language = string.Empty;

            switch (Registry_Helpers.GetCurrentLanguageCode())
            {
                case "409":
                    language = "en-US";
                    break;

                case "804":
                    language = "zh-cn";
                    break;
            }

            return language;
        }

        public static Products Product()
        {
            Products loadedversion = Products.ACAD;

            switch (Registry_Helpers.GetCurrentProductCode())
            {
                case "001":
                    loadedversion = Products.ACAD;
                    break;
            }

            return loadedversion;
        }

        private static Tuple<string, Years, Versions> VersionInfo(string currentrelease)
        {
            Tuple<string, Years, Versions> returnvalue = null;

            switch (currentrelease)
            {
                case "R20.1":
                    returnvalue = new Tuple<string, Years, Versions>(currentrelease, Years.Y2016, Versions.R20_1);
                    break;

                case "R21.0":
                    returnvalue = new Tuple<string, Years, Versions>(currentrelease, Years.Y2017, Versions.R21_0);
                    break;

                case "R22.0":
                    returnvalue = new Tuple<string, Years, Versions>(currentrelease, Years.Y2018, Versions.R22_0);
                    break;

                case "R23.0":
                    returnvalue = new Tuple<string, Years, Versions>(currentrelease, Years.Y2019, Versions.R23_0);
                    break;
            }

            return returnvalue;
        }

        public static Years Year()
        {
            string currentrelease = Registry_Helpers.GetCurrentRelease();
            return VersionInfo(currentrelease).Item2;
        }

        public static Versions Version()
        {
            string currentrelease = Registry_Helpers.GetCurrentRelease();
            return VersionInfo(currentrelease).Item3;
        }
    }
}
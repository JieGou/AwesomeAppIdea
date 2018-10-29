using Autodesk.Revit.UI;
using AwesomeAppIdea.Core.Enums;
using AwesomeAppIdea.Revit.Enums;

namespace AwesomeAppIdea.Revit.Extensions
{
    public static class Version_Extensions
    {
        public static Versions GetProduct(this UIControlledApplication uiapp)
        {
            switch (uiapp.ControlledApplication.Product)
            {
                case Autodesk.Revit.ApplicationServices.ProductType.Architecture:
                    return Versions.Architecture;

                case Autodesk.Revit.ApplicationServices.ProductType.Structure:
                    return Versions.Structure;

                case Autodesk.Revit.ApplicationServices.ProductType.MEP:
                    return Versions.MEP;

                case Autodesk.Revit.ApplicationServices.ProductType.Revit:
                    return Versions.Revit;

                case Autodesk.Revit.ApplicationServices.ProductType.LT:
                    return Versions.LT;
            }

            return Versions.Unknown;
        }

        public static Years GetYear(this UIControlledApplication uiapp)
        {
            string YearNumber = uiapp.ControlledApplication.VersionNumber;

            if (YearNumber == "2016")
            {
                return Years.Y2016;
            }
            else if (YearNumber == "2017")
            {
                return Years.Y2017;
            }
            else if (YearNumber == "2018")
            {
                return Years.Y2018;
            }
            else if (YearNumber == "2019")
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
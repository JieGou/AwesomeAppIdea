using AwesomeAppIdea.Core.Enums;
using AwesomeAppIdea.Core.Models;
using AwesomeAppIdea.Revit.Contracts;
using AwesomeAppIdea.Revit.Enums;

namespace AwesomeAppIdea.Revit.Models
{
    public class RevitClientInformation_Model : ClientInformation_Model, IRevitClientInformation
    {
        public RevitClientInformation_Model(Years year, Versions version) : base(Products.REVIT, year)
        {
            Version = version;
        }

        public Versions Version { get; }
    }
}
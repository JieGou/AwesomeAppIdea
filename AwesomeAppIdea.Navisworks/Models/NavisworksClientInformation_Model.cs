using AwesomeAppIdea.Core.Enums;
using AwesomeAppIdea.Core.Models;
using AwesomeAppIdea.Navisworks.Contracts;

namespace AwesomeAppIdea.Navisworks.Models
{
    public class NavisworksClientInformation_Model : ClientInformation_Model, INavisworksClientInformation
    {
        public NavisworksClientInformation_Model(Years year, Enums.Versions version) : base(Products.NAVIS, year)
        {
            Version = version;
        }

        public Enums.Versions Version { get; }
    }
}
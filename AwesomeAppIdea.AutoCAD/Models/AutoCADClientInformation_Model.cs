using AwesomeAppIdea.AutoCAD.Contracts;
using AwesomeAppIdea.AutoCAD.Enums;
using AwesomeAppIdea.AutoCAD.Helpers;
using AwesomeAppIdea.Core.Contracts;
using AwesomeAppIdea.Core.Models;

namespace AwesomeAppIdea.AutoCAD.Models
{
    public class AutoCADClientInformation_Model : ClientInformation_Model, IAutoCADClientInformation
    {
        public AutoCADClientInformation_Model(IClientInformation clientInformation, Versions version) : base(clientInformation.Product, clientInformation.Year)
        {
            CurrentVersion = Registry_Helpers.GetCurrentVersion();
            Language = Application_Helpers.Language();
            Version = version;
        }

        public string CurrentVersion { get; }
        public string Language { get; }
        public Versions Version { get; }
    }
}
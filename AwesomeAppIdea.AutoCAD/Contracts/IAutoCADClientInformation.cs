using AwesomeAppIdea.AutoCAD.Enums;
using AwesomeAppIdea.Core.Contracts;

namespace AwesomeAppIdea.AutoCAD.Contracts
{
    public interface IAutoCADClientInformation : IClientInformation
    {
        string CurrentVersion { get; }
        string Language { get; }
        Versions Version { get; }
    }
}
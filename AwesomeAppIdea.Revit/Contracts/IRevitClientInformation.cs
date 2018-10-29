using AwesomeAppIdea.Core.Contracts;
using AwesomeAppIdea.Revit.Enums;

namespace AwesomeAppIdea.Revit.Contracts
{
    public interface IRevitClientInformation : IClientInformation
    {
        Versions Version { get; }
    }
}
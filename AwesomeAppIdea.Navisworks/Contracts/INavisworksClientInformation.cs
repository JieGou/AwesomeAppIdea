using AwesomeAppIdea.Core.Contracts;

namespace AwesomeAppIdea.Navisworks.Contracts
{
    public interface INavisworksClientInformation : IClientInformation
    {
        Enums.Versions Version { get; }
    }
}
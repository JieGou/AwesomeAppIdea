using Autodesk.Revit.UI;
using AwesomeAppIdea.Core.Contracts;

namespace AwesomeAppIdea.Revit.Contracts
{
    public interface IClientRVT : IClient
    {
        void Load(UIControlledApplication uiapp);
    }
}
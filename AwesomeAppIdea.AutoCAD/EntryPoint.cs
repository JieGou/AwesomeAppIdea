using AwesomeAppIdea.Core.Components;
using AwesomeAppIdea.Core.Contracts;
using Microsoft.Practices.Unity;
using AAR = Autodesk.AutoCAD.Runtime;

namespace AwesomeAppIdea.AutoCAD
{
    public class EntryPoint : AAR.IExtensionApplication
    {
       public static IClient Client { get; private set; }

        public void Initialize()
        {
            Core.Helpers.Dependancy_Helpers.LoadDependancies();

            var bootstrapper = new Bootstrapper_Model();
            bootstrapper.Initialize();

            Client = bootstrapper.Container.Resolve<IClient>();
            Client.Load();

        }

        public void Terminate()
        {
        }
    }
}
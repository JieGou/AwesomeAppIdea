using Autodesk.Navisworks.Api.Plugins;
using AwesomeAppIdea.Core.Components;
using AwesomeAppIdea.Core.Contracts;
using Microsoft.Practices.Unity;

namespace AwesomeAppIdea.Navisworks
{
    [Plugin("AWESOME_AwesomeAppIdea", "AWESOME")]
    public class EntryPoint : EventWatcherPlugin
    {
        public static IClient Client { get; private set; }

        public override void OnLoaded()
        {
            Core.Helpers.Dependancy_Helpers.LoadDependancies();

            var bootstrapper = new Bootstrapper_Model();
            bootstrapper.Initialize();

            Client = bootstrapper.Container.Resolve<IClient>();
            Client.Load();
        }

        public override void OnUnloading()
        {
        }
    }
}
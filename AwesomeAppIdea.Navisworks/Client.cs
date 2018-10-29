using AwesomeAppIdea.Core.Contracts;
using AwesomeAppIdea.Core.Models;
using AwesomeAppIdea.Navisworks.Contracts;
using AwesomeAppIdea.Navisworks.Models;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Logging;
using System.Reflection;

namespace AwesomeAppIdea.Navisworks
{
    internal class Client : UI.ViewModel.Client
    {
        public Client(IUnityContainer container, IEventAggregator eventaggregator, ILoggerFacade logger) : base(container, eventaggregator, logger)
        {
        }

        public override IApplicationInfo GetAppInfo()
        {
            return new ApplicationInfo_Model(Assembly.GetExecutingAssembly(), Container.Resolve<IApplicationAuthor>());
        }

        public override IClientTheme GetClientTheme()
        {
            return new NavisworksClientTheme_Model(Container.Resolve<INavisworksClientInformation>());
        }

        public override void SetupUI()
        {
            // Not required for navisworks
        }
    }
}
using AwesomeAppIdea.Core.Contracts;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Logging;

namespace AwesomeAppIdea.UI.ViewModel
{
    public abstract class Client : IClient
    {
        protected IUnityContainer Container { get; set; }

        protected IEventAggregator EventAggregator { get; set; }
        protected ILoggerFacade Logger { get; set; }

        public Client(IUnityContainer container, IEventAggregator eventaggregator, ILoggerFacade logger)
        {
            Container = container;
            EventAggregator = eventaggregator;
            Logger = logger;
        }

        public void Load()
        {
            Container.RegisterInstance(GetAppInfo());
            Container.RegisterInstance(GetClientTheme());
            SetupUI();
        }

        public abstract IApplicationInfo GetAppInfo();

        public abstract IClientTheme GetClientTheme();

        public abstract void SetupUI();
    }
}
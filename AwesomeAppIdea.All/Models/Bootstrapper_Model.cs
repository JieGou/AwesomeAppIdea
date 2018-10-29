using AwesomeAppIdea.Core.Contracts;
using AwesomeAppIdea.Core.Models;
using Microsoft.Practices.Unity;
using Prism.Logging;

#if ACAD

using AwesomeAppIdea.AutoCAD.Contracts;
using AwesomeAppIdea.AutoCAD.Helpers;
using AwesomeAppIdea.AutoCAD.Models;
using AwesomeAppIdea.AutoCAD.Services;
using AwesomeAppIdea.AutoCAD;

#elif NAVIS

using AwesomeAppIdea.Navisworks.Contracts;
using AwesomeAppIdea.Navisworks.Helpers;
using AwesomeAppIdea.Navisworks.Models;
using AwesomeAppIdea.Navisworks.Services;
using AwesomeAppIdea.Navisworks;

#elif REVIT

using Autodesk.Revit.UI;
using AwesomeAppIdea.Revit.Contracts;
using AwesomeAppIdea.Revit.Extensions;
using AwesomeAppIdea.Revit.Models;
using AwesomeAppIdea.Revit.Services;
using AwesomeAppIdea.Revit;

#endif

namespace AwesomeAppIdea.Core.Components
{
    internal class Bootstrapper_Model : IBootstrapper
    {
        public IUnityContainer Container { get; private set; }

        public void Initialize()
        {
            var boot = new Bootstrapper();
            boot.Run();

            if (boot.Container == null) return;

            Container = boot.Container;

            IApplicationAuthor author = new ApplicationAuthor_Model("Ben de Vries", "ben.devries@aurecongroup.com");
            Container.RegisterInstance(author);

#if ACAD
            IClientInformation appclient = new ClientInformation_Model(Application_Helpers.Product(), Application_Helpers.Year());

            IAutoCADClientInformation acadclient = new AutoCADClientInformation_Model(appclient, Application_Helpers.Version());
            Container.RegisterInstance(acadclient, new ContainerControlledLifetimeManager());

            Container.RegisterType<IClient, Client>();
            Container.RegisterType<IMessageBoxService, MessageBox_Service>();

#elif NAVIS

            IClientInformation appclient = new ClientInformation_Model(Core.Enums.Products.NAVIS, Application_Helpers.Year());

            INavisworksClientInformation acadclient = new NavisworksClientInformation_Model(Application_Helpers.Year(), Application_Helpers.Version());
            Container.RegisterInstance(acadclient, new ContainerControlledLifetimeManager());

            Container.RegisterType<IClient, Client>();
            Container.RegisterType<IMessageBoxService, MessageBox_Service>();

#endif
        }

#if REVIT

        public void InitializeRVT(UIControlledApplication uiapp)
        {
            if (uiapp == null) throw new System.ArgumentNullException(nameof(uiapp));

            Initialize();

            IClientInformation appclient = new ClientInformation_Model(Core.Enums.Products.REVIT, uiapp.GetYear());

            IRevitClientInformation revitclient = new RevitClientInformation_Model(uiapp.GetYear(), uiapp.GetProduct());
            Container.RegisterInstance(revitclient, new ContainerControlledLifetimeManager());

            Container.RegisterType<IClientRVT, Client>();
            Container.RegisterType<IMessageBoxService, MessageBox_Service>();
        }

#endif

    }
}
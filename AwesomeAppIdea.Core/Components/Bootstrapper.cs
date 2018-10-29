using Prism.Logging;
using Prism.Mvvm;
using Prism.Unity;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace AwesomeAppIdea.Core.Components
{
    public sealed class Bootstrapper : UnityBootstrapper
    {
        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            {
                var viewName = viewType.FullName;
                var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
                var viewModelName = $"{viewName.Replace(".View.", ".ViewModel.")}Model, {viewAssemblyName}";
                return Type.GetType(viewModelName);
            });
        }

        protected override ILoggerFacade CreateLogger()
        {
            string LogsFolder = Path.Combine(Environment.GetEnvironmentVariable("AppData"), "AwesomeAppIdea", "Logs");

            if (!Directory.Exists(LogsFolder)) Directory.CreateDirectory(LogsFolder);

            Directory.GetFiles(LogsFolder).ToList().Select((filepath) => new FileInfo(filepath)).Where((file) => file.LastAccessTime < DateTime.Now.AddDays(-14)).ToList().ForEach((foundfile) => foundfile.Delete());

            FileVersionInfo ProcessVersion = Process.GetCurrentProcess().MainModule.FileVersionInfo;

            StreamWriter writer = null;

            for (int Count = 0; Count <= 100; Count++)
            {
                try
                {
                    writer = File.CreateText(Path.Combine(LogsFolder, $"AwesomeAppIdea Log - {ProcessVersion.ProductName}({ProcessVersion.ProductMajorPart}_{ProcessVersion.ProductMinorPart}) Session({Count}).txt"));
                    break;
                }
                catch { }
            }

            writer.AutoFlush = true;
            return new TextLogger(writer);
        }

        protected override DependencyObject CreateShell()
        {
            return null;
        }
    }
}
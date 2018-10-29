using AwesomeAppIdea.Core.Contracts;
using Prism.Commands;
using Prism.Mvvm;
using System;

namespace AwesomeAppIdea.UI.ViewModel
{
    public class Main_ViewModel : BindableBase
    {
        public Main_ViewModel(IApplicationInfo applicationInfo, IMessageBoxService dialogService)
        {
            _messageboxService = dialogService;
            Info = applicationInfo;
            About_Command = new DelegateCommand(Handler_About_Command);
        }

        private void Handler_About_Command()
        {
            var messagecontent = $"Developed by: {Info.Author.Name}{Environment.NewLine}Email Address: {Info.Author.EmailAddress}{Environment.NewLine}Version: {Info.Version}";
            _messageboxService?.Show("About", messagecontent);
        }

        private readonly IMessageBoxService _messageboxService;

        public IApplicationInfo Info { get; }

        public DelegateCommand About_Command { get; }
    }
}
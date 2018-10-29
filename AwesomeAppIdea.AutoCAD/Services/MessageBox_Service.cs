using AwesomeAppIdea.AutoCAD.Contracts;
using AwesomeAppIdea.Core.Contracts;
using System.Windows.Forms;

namespace AwesomeAppIdea.AutoCAD.Services
{
    internal class MessageBox_Service : IMessageBoxService
    {
        public MessageBox_Service(IAutoCADClientInformation ClientInformation)
        {
            _clientinfo = ClientInformation;
        }

        private readonly IAutoCADClientInformation _clientinfo;

        public void Show(string title, string content)
        {
            MessageBox.Show(Autodesk.AutoCAD.ApplicationServices.Core.Application.MainWindow as IWin32Window, content, $"{Core.Extensions.Enum_Extensions<Core.Enums.Products>.GetDescription(_clientinfo.Product)} {Core.Extensions.Enum_Extensions<Core.Enums.Years>.GetDescription(_clientinfo.Year)} - {title}", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
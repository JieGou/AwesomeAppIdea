using AwesomeAppIdea.Core.Contracts;
using AwesomeAppIdea.Core.Models;
using System;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AwesomeAppIdea.AutoCAD.Models
{
    internal class AutoCADClientTheme_Model : ClientTheme_Model
    {
        public AutoCADClientTheme_Model(IClientInformation clientInformation)
        {
            String filename = $"AwesomeAppIdea.AutoCAD.Resources.{clientInformation.Product.ToString()}{Core.Extensions.Enum_Extensions<Core.Enums.Years>.GetDescription(clientInformation.Year)}.jpg";

            var imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.StreamSource = Assembly.GetExecutingAssembly().GetManifestResourceStream(filename);
            imageSource.EndInit();

            Background = new ImageBrush() { ImageSource = imageSource };

            Bomb = Brushes.White;
            BorderPen = new Pen(new SolidColorBrush(Color.FromArgb(255, 145, 13, 26)), 2.0);
            Invader1 = new SolidColorBrush(Color.FromArgb(255, 255, 113, 102));
            Invader2 = new SolidColorBrush(Color.FromArgb(255, 198, 42, 44));
            Invader3 = new SolidColorBrush(Color.FromArgb(255, 149, 30, 32));
            Missile = new SolidColorBrush(Color.FromArgb(255, 34, 56, 110));
            Player = new SolidColorBrush(Color.FromArgb(255, 34, 56, 110));
            Saucer = Brushes.Azure;
            Shield = new SolidColorBrush(Color.FromArgb(255, 241, 241, 235));
            TextGameOver = Brushes.Red;
            TextTitle = Brushes.Firebrick;
            TextValue = new SolidColorBrush(Color.FromArgb(255, 217, 216, 210));
        }
    }
}
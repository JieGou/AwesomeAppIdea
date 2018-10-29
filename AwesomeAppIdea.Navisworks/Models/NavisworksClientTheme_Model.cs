using AwesomeAppIdea.Core.Contracts;
using AwesomeAppIdea.Core.Models;
using System;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AwesomeAppIdea.Navisworks.Models
{
    internal class NavisworksClientTheme_Model : ClientTheme_Model
    {
        public NavisworksClientTheme_Model(IClientInformation clientInformation)
        {
            String filename = $"AwesomeAppIdea.Navisworks.Resources.{clientInformation.Product.ToString()}{Core.Extensions.Enum_Extensions<Core.Enums.Years>.GetDescription(clientInformation.Year)}.jpg";

            var imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.StreamSource = Assembly.GetExecutingAssembly().GetManifestResourceStream(filename);
            imageSource.EndInit();

            Background = new ImageBrush() { ImageSource = imageSource };

            Bomb = Brushes.White;
            BorderPen = new Pen(new SolidColorBrush(Color.FromArgb(255, 0, 42, 21)), 2.0);
            Invader1 = new SolidColorBrush(Color.FromArgb(255, 166, 209, 177));
            Invader2 = new SolidColorBrush(Color.FromArgb(255, 76, 155, 93));
            Invader3 = new SolidColorBrush(Color.FromArgb(255, 29, 78, 43));
            Missile = new SolidColorBrush(Color.FromArgb(255, 34, 56, 110));
            Player = new SolidColorBrush(Color.FromArgb(255, 34, 56, 110));
            Saucer = Brushes.Azure;
            Shield = new SolidColorBrush(Color.FromArgb(255, 241, 241, 235));
            TextGameOver = Brushes.Red;
            TextTitle = new SolidColorBrush(Color.FromArgb(255, 166, 209, 177));
            TextValue = new SolidColorBrush(Color.FromArgb(255, 217, 216, 210));
        }
    }
}
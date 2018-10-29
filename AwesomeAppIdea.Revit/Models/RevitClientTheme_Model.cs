using AwesomeAppIdea.Core.Contracts;
using AwesomeAppIdea.Core.Models;
using System;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AwesomeAppIdea.Revit.Models
{
    internal class RevitClientTheme_Model : ClientTheme_Model
    {
        public RevitClientTheme_Model(IClientInformation clientInformation)
        {
            String filename = $"AwesomeAppIdea.Revit.Resources.{clientInformation.Product.ToString()}{Core.Extensions.Enum_Extensions<Core.Enums.Years>.GetDescription(clientInformation.Year)}.jpg";

            var imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.StreamSource = Assembly.GetExecutingAssembly().GetManifestResourceStream(filename);
            imageSource.EndInit();

            Background = new ImageBrush() { ImageSource = imageSource };

            Bomb = Brushes.White;
            BorderPen = new Pen(new SolidColorBrush(Color.FromArgb(255, 70, 109, 192)), 2.0);
            Invader1 = new SolidColorBrush(Color.FromArgb(255, 158, 198, 234));
            Invader2 = new SolidColorBrush(Color.FromArgb(255, 88, 143, 193));
            Invader3 = new SolidColorBrush(Color.FromArgb(255, 56, 82, 131));
            Missile = Brushes.MediumPurple;
            Player = Brushes.MediumPurple;
            Saucer = Brushes.Azure;
            Shield = new SolidColorBrush(Color.FromArgb(255, 241, 241, 235));
            TextGameOver = Brushes.Red;
            TextTitle = new SolidColorBrush(Color.FromArgb(255, 70, 109, 192));
            TextValue = new SolidColorBrush(Color.FromArgb(255, 217, 216, 210));
        }
    }
}
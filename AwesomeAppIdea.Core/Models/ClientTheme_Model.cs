using AwesomeAppIdea.Core.Contracts;
using System.Windows.Media;

namespace AwesomeAppIdea.Core.Models
{
    public class ClientTheme_Model : IClientTheme
    {
        public Brush Background { get; set; }
        public Brush Bomb { get; set; }
        public Brush Invader1 { get; set; }
        public Brush Invader2 { get; set; }
        public Brush Invader3 { get; set; }
        public Brush Missile { get; set; }
        public Brush Player { get; set; }
        public Brush Saucer { get; set; }
        public Brush Shield { get; set; }
        public Brush TextGameOver { get; set; }
        public Brush TextTitle { get; set; }
        public Brush TextValue { get; set; }
        public Pen BorderPen { get; set; }
    }
}
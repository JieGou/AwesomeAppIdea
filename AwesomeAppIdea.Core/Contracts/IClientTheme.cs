using System.Windows.Media;

namespace AwesomeAppIdea.Core.Contracts
{
    public interface IClientTheme
    {
        Brush Background { get; set; }
        Brush Bomb { get; set; }
        Brush Invader1 { get; set; }
        Brush Invader2 { get; set; }
        Brush Invader3 { get; set; }
        Brush Missile { get; set; }
        Brush Player { get; set; }
        Brush Saucer { get; set; }
        Brush Shield { get; set; }
        Brush TextGameOver { get; set; }
        Brush TextTitle { get; set; }
        Brush TextValue { get; set; }
        Pen BorderPen { get; set; }
    }
}
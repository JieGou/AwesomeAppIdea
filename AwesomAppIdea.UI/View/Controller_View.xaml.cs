using AwesomeAppIdea.UI.ViewModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace AwesomeAppIdea.UI.View
{
    /// <summary>
    /// Interaction logic for Controller_View.xaml
    /// </summary>
    public partial class Controller_View : UserControl
    {
        public Controller_View()
        {
            InitializeComponent();

            VM = DataContext as Controller_ViewModel;
        }

        private Controller_ViewModel VM { get; }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            VM?.Game?.Draw(drawingContext);
        }
    }
}
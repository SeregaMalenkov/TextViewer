using System.Windows.Controls;

using TextViewer.Models;

namespace TextViewer.Controls
{
    /// <summary>
    /// Interaction logic for ViewerIndicator.xaml
    /// </summary>
    public partial class ViewerIndicator : Button
    {
        public ViewerIndicator()
        {
            InitializeComponent();

            Loaded += ViewerIndicator_Loaded;

            Click += ViewerIndicator_Click;
        }

        private void ViewerIndicator_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _model = DataContext as ViewerIndicatorModel;
        }

        private void ViewerIndicator_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!_model.IsOpen)
                _model.OpenFile();
        }

        private void Close_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            e.Handled = true;

            _model.CloseFile();
        }

        private ViewerIndicatorModel _model;
    }
}

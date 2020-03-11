using System.Windows;

namespace TextViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Utils.Logger.Instance.Log("Старт");

            Closed += MainWindow_Closed;
        }

        private void MainWindow_Closed(object sender, System.EventArgs e)
        {
            PART_Launcher.CloseAll();

            Utils.Logger.Instance.Log("Финиш");
        }
    }
}

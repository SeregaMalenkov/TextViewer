using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

using TextViewer.Models;

namespace TextViewer.Controls
{
    /// <summary>
    /// Interaction logic for Launcher.xaml
    /// </summary>
    public partial class Launcher : UserControl
    {
        public Launcher()
        {
            InitializeComponent();

            Indicators = new ObservableCollection<ViewerIndicatorModel>();

            try
            {
                Indicators.Add(new ViewerIndicatorModel(@"a.txt"));
                Indicators.Add(new ViewerIndicatorModel(@"b.txt"));
                Indicators.Add(new ViewerIndicatorModel(@"c.txt"));
            }
            catch (ArgumentException e)
            {
                Utils.Logger.Instance.Log($"При создании дефолтных виджетов: {e.Message}", Utils.MessageType.Error);
            }

            Loaded += Launcher_Loaded;
        }

        private void Launcher_Loaded(object sender, RoutedEventArgs e)
        {
            PART_MainPanel.ItemsSource = Indicators;
        }

        /// <summary>
        /// Выбрать файл для нового виджета
        /// </summary>
        private void SelectFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();

            if (dialog.ShowDialog().Value)
            {
                Indicators.Add(new ViewerIndicatorModel(dialog.FileName));
                Utils.Logger.Instance.Log($"Добавили виджет для {dialog.FileName}", Utils.MessageType.Info);
            }
        }

        /// <summary>
        /// Список виджетов
        /// </summary>
        public ObservableCollection<ViewerIndicatorModel> Indicators { get; private set; }

        /// <summary>
        /// Закрыть все виджеты
        /// </summary>
        public void CloseAll()
        {
            foreach (var indicator in Indicators)
                indicator.CloseFile();
        }
    }
}

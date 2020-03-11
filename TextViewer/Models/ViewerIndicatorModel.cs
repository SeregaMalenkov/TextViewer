using System;
using System.Diagnostics;
using System.IO;

namespace TextViewer.Models
{
    /// <summary>
    /// Модель виджета для открытия файла
    /// </summary>
    public class ViewerIndicatorModel : BaseModel
    {
        public ViewerIndicatorModel(String filePath)
        {
            if (!File.Exists(filePath))
                throw new ArgumentException($"Файл {FilePath} не существует");

            FilePath = filePath;
            FileName = Path.GetFileName(FilePath);
        }

        #region Handlers
        /// <summary>
        /// Приложение закрылось
        /// </summary>
        private void ViewerProcess_Exited(object sender, EventArgs e)
        {
            IsOpen = false;
            ViewerName = String.Empty;

            _viewerProcess.Close();

            Utils.Logger.Instance.Log($"Закрыли {FilePath}", Utils.MessageType.Info);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Имя открываемого файла
        /// </summary>
        public String FileName
        {
            get { return _fileName; }

            private set
            {
                if (_fileName != value)
                {
                    _fileName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Имя приложения, в котором открыт файл
        /// </summary>
        public String ViewerName
        {
            get { return _viewerName; }

            private set
            {
                if (_viewerName != value)
                {
                    _viewerName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Открыт ли файл?
        /// </summary>
        public Boolean IsOpen
        {
            get { return _isOpen; }

            private set
            {
                if (_isOpen != value)
                {
                    _isOpen = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public String FilePath { get; private set; }
        #endregion

        #region Methods
        /// <summary>
        /// Открыть файл в умолчательном приложении
        /// </summary>
        public void OpenFile()
        {
            try
            {
                _viewerProcess = Process.Start(FilePath);
                _viewerProcess.EnableRaisingEvents = true;
                _viewerProcess.Exited += ViewerProcess_Exited;

                ViewerName = _viewerProcess.ProcessName;
                IsOpen = true;

                Utils.Logger.Instance.Log($"Открыли {FilePath}", Utils.MessageType.Info);
            }
            catch (Exception e)
            {
                Utils.Logger.Instance.Log($"При открытии файла {FilePath}: {e.Message}", Utils.MessageType.Error);
            }
        }

        /// <summary>
        /// Закрыть файл
        /// </summary>
        public void CloseFile()
        {
            try
            {
                _viewerProcess.CloseMainWindow();
            }
            catch (Exception e)
            {
                Utils.Logger.Instance.Log($"При закрытии файла {FilePath}: {e.Message}", Utils.MessageType.Error);
            }
        }
        #endregion

        #region Fields
        private String _fileName;
        private String _viewerName;

        private Boolean _isOpen;

        private Process _viewerProcess;
        #endregion
    }
}

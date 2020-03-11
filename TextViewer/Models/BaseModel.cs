using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TextViewer.Models
{
    /// <summary>
    /// Базовый класс модели
    /// </summary>
    public class BaseModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Извещает об изменении свойств
        /// </summary>
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

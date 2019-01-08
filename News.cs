using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NewsSheet
{
    [Serializable]
    public class News : INotifyPropertyChanged
    {
        public News()
        { }

        public event PropertyChangedEventHandler PropertyChanged;
        public void Set<T>(ref T field, T value, [System.Runtime.CompilerServices.CallerMemberName]string prop = "")
        {
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private int id;
        public int Id { get => id; set => Set(ref id, value); }

        private string nImageLink;
        public string NImageLink { get => nImageLink; set => Set(ref nImageLink, value); }

        private int nPriority;
        public int NPriority { get => nPriority; set => Set(ref nPriority, value); }

        private string nLabel;
        public string NLabel { get => nLabel; set => Set(ref nLabel, value); }

        private DateTime nDateTime;
        public DateTime NDateTime { get => nDateTime; set => Set(ref nDateTime, value); }

        private string nContent;
        public string NContent { get => nContent; set => Set(ref nContent, value); }
    }
}

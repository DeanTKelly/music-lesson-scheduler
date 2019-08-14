using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MusicLessonScheduler.ViewModel
{
    public interface INotifyPropertyChanged
    {
        event PropertyChangedEventHandler PropertyChanged;
    }
}

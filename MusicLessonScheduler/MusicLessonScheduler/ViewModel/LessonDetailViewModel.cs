using MusicLessonScheduler.Model;
using MusicLessonScheduler.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MusicLessonScheduler.ViewModel
{
    public class LessonDetailViewModel : BaseViewModel
    {
        public LessonDetailViewModel(Lesson lesson)
        {
            lessonValue = lesson;
            ShareLessonNotesCommand = new Command(async () => await ExecuteShareLessonNotesCommand());
            EditButtonCommand = new Command(async () => await ExecuteEditButtonCommand());
            DeleteButtonCommand = new Command(async () => await ExecuteDeleteButtonCommand());
        }
        private Lesson lessonValue;
        public Lesson Lesson
        {
            set
            {
                if (lessonValue != value)
                {
                    lessonValue = value;
                    OnPropertyChanged("Lesson");
                }
            }
            get
            {
                return lessonValue;
            }
        }
        public string LessonName
        {
            set
            {
                if (lessonValue.LessonName != value)
                {
                    lessonValue.LessonName = value;
                    OnPropertyChanged("LessonName");
                }
            }
            get
            {
                return lessonValue.LessonName;
            }
        }
        public string LessonDate
        {
            set
            {
                if (lessonValue.LessonDate != DateTime.Parse(value))
                {
                    lessonValue.LessonDate = DateTime.Parse(value);
                    OnPropertyChanged("LessonDate");
                }
            }
            get
            {
                return lessonValue.LessonDate.Date.ToShortDateString();
            }
        }
        public string LessonTime
        {
            set
            {
                if (lessonValue.LessonTime != value)
                {
                    lessonValue.LessonTime = value;
                    OnPropertyChanged("LessonTime");
                }
            }
            get
            {
                return lessonValue.LessonTime;
            }
        }
        public bool LessonReminder
        {
            set
            {
                if (lessonValue.LessonReminder != value)
                {
                    lessonValue.LessonReminder = value;
                    OnPropertyChanged("LessonReminder");
                }
            }
            get
            {
                return lessonValue.LessonReminder;
            }
        }
        public string LessonNotes
        {
            set
            {
                if(lessonValue.LessonNotes != value)
                {
                    lessonValue.LessonNotes = value;
                    OnPropertyChanged("LessonNotes");
                }
            }
            get
            {
                return lessonValue.LessonNotes;
            }
        }
        public Command ShareLessonNotesCommand { get; set; }
        async Task ExecuteShareLessonNotesCommand()
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = LessonNotes,
                Title = $"{LessonName} Course Notes:"
            });

        }
        public Command EditButtonCommand { get; set; }
        async Task ExecuteEditButtonCommand()
        {
            await App.Current.MainPage.Navigation.PushAsync(new EditLessonPage(this));
        }
        public Command DeleteButtonCommand { get; set; }
        async Task ExecuteDeleteButtonCommand()
        {
            await App.DB.DeleteLesson(Lesson);
            MessagingCenter.Send<LessonDetailViewModel, Lesson>(this, "DeleteLesson", Lesson);
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}

using MusicLessonScheduler.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MusicLessonScheduler.ViewModel
{
    public class EditLessonViewModel : BaseViewModel
    {
        public EditLessonViewModel(Lesson lesson)
        {
            lessonValue = lesson;
            SaveButtonCommand = new Command(async () => await ExecuteSaveButtonCommand());
            CancelButtonCommand = new Command(async () => await App.Current.MainPage.Navigation.PopAsync());
        }
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
        public List<string> LessonTimeList { get; } = new List<string> { "1:00-2:00pm", "2:00-3:00pm", "3:00-4:00pm", "4:00-5:00pm", "5:00-6:00" };
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
                if (lessonValue.LessonNotes != value)
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
        public bool preventNullValues(Lesson lesson)
        {
            return lesson.LessonName != "" && lesson.LessonTime != "";
        }
        public Command CancelButtonCommand { get; set; }
        private Lesson lessonValue;
        public Command SaveButtonCommand { get; set; }
        async Task ExecuteSaveButtonCommand()
        {
            if (preventNullValues(Lesson))
            {
                await App.DB.SaveLesson(Lesson);
                SetNotify(LessonReminder, "Reminder", $"Upcoming lesson on {LessonDate}.",
                    1, DateTime.Parse(LessonDate).AddDays(-1));
                MessagingCenter.Send<EditLessonViewModel, Lesson>(this, "EditLesson", Lesson);
                await App.Current.MainPage.Navigation.PopToRootAsync();
                await App.Current.MainPage.Navigation.PushAsync(new StudentRosterPage());
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(" ", "Please complete all fields.", "Continue");
                return;
            }
        }
    }
}

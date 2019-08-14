using MusicLessonScheduler.Model;
using MusicLessonScheduler.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MusicLessonScheduler.ViewModel
{
    public class StudentDetailViewModel : BaseViewModel
    {
        public StudentDetailViewModel(Student student)
        {
            studentValue = student;
            LessonList = new ObservableCollection<Lesson>();
            EditStudentCommand = new Command(async () => await ExecuteEditStudentCommand());
            DeleteStudentCommand = new Command(async () => await ExecuteDeleteStudentCommand());
            AddLessonCommand = new Command(async () => await ExecuteAddLessonCommand());
            PopulateLessonList();

            MessagingCenter.Subscribe<EditStudentViewModel, Student>(this, "EditStudent", (sender, info) =>
            {
                Student = info;
            });
            MessagingCenter.Subscribe<AddLessonViewModel, Lesson>
              (this, "AddLesson", (sender, obj) =>
              {
                  LessonList.Add(obj);
              });
            MessagingCenter.Subscribe<LessonDetailViewModel, Lesson>
                (this, "DeleteLesson", (sender, obj) =>
                {
                    LessonList.Remove(obj);
                });
            //MessagingCenter here
        }
        private ObservableCollection<Lesson> lessons;
        public ObservableCollection<Lesson> LessonList
        {
            set
            {
                if(lessons != value)
                {
                    lessons = value;
                    OnPropertyChanged("Lesson");
                }
            }
            get
            {
                return lessons;
            }
        }
        public Command LoadLessonsCommand { get; set; }
        async Task ExecuteLoadLessonsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                LessonList.Clear();
                var lessons = await App.DB.ShowLessons(Student);
                foreach(var lesson in lessons)
                {
                    LessonList.Add(lesson);
                }
            }
            catch (Exception exception) { }
            finally { IsBusy = false; }
        }
        private async void PopulateLessonList()
        {
            List<Lesson> lessons = await App.DB.ShowLessons(studentValue);
            LessonList.Clear();
            foreach(Lesson lesson in lessons)
            {
                LessonList.Add(lesson);
            }
        }
        public Command EditStudentCommand { get; set; }
        async Task ExecuteEditStudentCommand()
        {
            await App.Current.MainPage.Navigation.PushAsync(new EditStudentPage(this));
        }
        public Command DeleteStudentCommand { get; set; }
        async Task ExecuteDeleteStudentCommand()
        {
            await App.DB.DeleteStudent(Student);
            MessagingCenter.Send<StudentDetailViewModel, Student>(this, "DeleteStudent", Student);
            await App.Current.MainPage.Navigation.PopAsync();
        }
        public Command AddLessonCommand { get; set; }
        async Task ExecuteAddLessonCommand()
        {
            await App.Current.MainPage.Navigation.PushAsync(new AddLessonPage(Student));
        }
        private Student studentValue;
        public Student Student
        {
            set
            {
                if (studentValue != value)
                {
                    studentValue = value;
                    OnPropertyChanged("Student");
                }
            }
            get
            {
                return studentValue;
            }
        }
        public string StudentName
        {
            set
            {
                if (studentValue.StudentName != value)
                {
                    studentValue.StudentName = value;
                    OnPropertyChanged("StudentName");
                }
            }
            get
            {
                return studentValue.StudentName;
            }
        }
        public string StudentPhone
        {
            set
            {
                if (studentValue.StudentPhone != value)
                {
                    studentValue.StudentPhone = value;
                    OnPropertyChanged("StudentPhone");
                }
            }
            get
            {
                return studentValue.StudentPhone;
            }
        }
        public string StudentEmail
        {
            set
            {
                if (studentValue.StudentEmail != value)
                {
                    studentValue.StudentEmail = value;
                    OnPropertyChanged("StudentEmail");
                }
            }
            get
            {
                return studentValue.StudentEmail;
            }
        }
        public string StudentSkillLevel
        {
            set
            {
                if (studentValue.StudentSkillLevel != value)
                {
                    studentValue.StudentSkillLevel = value;
                    OnPropertyChanged("StudentSkillLevel");
                }
            }
            get
            {
                return studentValue.StudentSkillLevel;
            }
        }
        public string StudentInstrument
        {
            set
            {
                if (studentValue.StudentInstrument != value)
                {
                    studentValue.StudentInstrument = value;
                    OnPropertyChanged("StudentInstrument");
                }
            }
            get
            {
                return studentValue.StudentInstrument;
            }
        }        
    }
}

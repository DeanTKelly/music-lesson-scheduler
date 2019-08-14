using MusicLessonScheduler.Model;
using MusicLessonScheduler.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MusicLessonScheduler.View
{
    public class EditStudentViewModel : BaseViewModel
    {
        public EditStudentViewModel(Student student)
        {
            studentValue = student;
            SaveStudentCommand = new Command(async () => await ExecuteSaveStudentCommand());
            CancelButtonCommand = new Command(async () => await ExecuteCancelButtonCommand());
        }
        private Student studentValue;
        public bool preventNullValues(Student student)
        {
            return student.StudentName != "" &&
                student.StudentPhone != "" &&
                student.StudentEmail != "" &&
                student.StudentSkillLevel != "" &&
                student.StudentInstrument != "";
        }
        public Command SaveStudentCommand { get; set; }
        async Task ExecuteSaveStudentCommand()
        {
            if(preventNullValues(Student))
            {
                await App.DB.SaveStudent(Student);
                MessagingCenter.Send<EditStudentViewModel, Student>(this, "EditStudent", Student);
                await App.Current.MainPage.Navigation.PopToRootAsync();
                await App.Current.MainPage.Navigation.PushAsync(new StudentRosterPage());
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(" ", "Please complete all fields.", "Continue");
                return;
            }
        }
        public Command CancelButtonCommand { get; set; }
        async Task ExecuteCancelButtonCommand()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }
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
        public List<string> SkillLevelList { get; } = new List<string> { "Beginner", "Intermediate", "Advanced" };
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
        public List<string> InstrumentList { get; } = new List<string> { "Guitar", "Bass", "Drums", "Vocals", "Piano" };
    }
}

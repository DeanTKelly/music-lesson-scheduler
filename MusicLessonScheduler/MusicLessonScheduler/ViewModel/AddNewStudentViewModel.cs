using MusicLessonScheduler.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MusicLessonScheduler.ViewModel
{
    public class AddNewStudentViewModel : BaseViewModel
    {
        public AddNewStudentViewModel()
        {
            studentValue = new Student();
            SaveNewStudentCommand = new Command(async () => await ExecuteSaveNewStudentCommand());
            CancelNewStudentCommand = new Command(async () => await ExecuteCancelNewStudentCommand());
        }
        public Command SaveNewStudentCommand { get; set; }
        async Task ExecuteSaveNewStudentCommand()
        {
            if(preventNullValues(Student))
            {
                await App.DB.SaveStudent(Student);
                MessagingCenter.Send<AddNewStudentViewModel, Student>(this, "AddNewStudent", Student);
                await App.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(" ", "Please complete all fields.", "Continue");
                return;
            }
        }
        public bool preventNullValues(Student student)
        {
            return student.StudentName != null &&
                student.StudentPhone != null &&
                student.StudentEmail != null &&
                student.StudentSkillLevel != null &&
                student.StudentInstrument != null;
        }
        public Command CancelNewStudentCommand { get; set; }

        async Task ExecuteCancelNewStudentCommand()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }
        private Student studentValue;
        public Student Student
        {
            set
            {
                if(studentValue != value)
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

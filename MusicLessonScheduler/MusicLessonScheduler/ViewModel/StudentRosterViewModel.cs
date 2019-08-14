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
    public class StudentRosterViewModel : BaseViewModel
    {
        private ObservableCollection<Student> students;
        public ObservableCollection<Student> Students
        {
            set
            {
                if(students != value)
                {
                    students = value;
                    OnPropertyChanged("Student");
                }
            }
            get
            {
                return students;
            }
        }
        public Command LoadStudentsCommand { get; set; }
        public Command AddNewStudentCommand { get; set; }
        public StudentRosterViewModel()
        {
            students = new ObservableCollection<Student>();
            LoadStudentsCommand = new Command(async () => await ExecuteLoadStudentsCommand());
            AddNewStudentCommand = new Command(async () => await ExecuteAddNewStudentCommand());
            if(App.DB.ShowStudents().Result.Count == 0)
            {
                App.DB.EvaluationData();
            }            
            PopulateStudentRoster();

            MessagingCenter.Subscribe<AddNewStudentViewModel, Student>
                (this, "AddNewStudent", (sender, obj) =>
                {
                    students.Add(obj);
                });
            MessagingCenter.Subscribe<StudentDetailViewModel, Student>
                (this, "DeleteStudent", (sender, obj) =>
                {
                    students.Remove(obj);
                });
            //messagingcenters here
        }
        async Task ExecuteAddNewStudentCommand()
        {
            await App.Current.MainPage.Navigation.PushAsync(new AddNewStudentPage());
        }
        async Task ExecuteLoadStudentsCommand()
        {
            Students.Clear();
            var students = await App.DB.ShowStudents();
            foreach(var student in students)
            {
                Students.Add(student);
            }
        }
        public async void PopulateStudentRoster()
        {
            List<Student> students = await App.DB.ShowStudents();
            Students.Clear();
            foreach(Student student in students)
            {
                Students.Add(student);
            }
        }
    }
}

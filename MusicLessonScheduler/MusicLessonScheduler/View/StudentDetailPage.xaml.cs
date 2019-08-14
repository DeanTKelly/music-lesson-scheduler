using MusicLessonScheduler.Model;
using MusicLessonScheduler.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicLessonScheduler.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StudentDetailPage : ContentPage
	{        
        public StudentDetailPage (Student student)
		{
			InitializeComponent ();
            Student = student;
            BindingContext = viewModel = new StudentDetailViewModel(student);
		}
        StudentDetailViewModel viewModel;
        private Student studentValue;
        public Student Student
        {
            get { return studentValue; }
            set { studentValue = value; OnPropertyChanged(); }
        }
        async void LessonListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedLesson = e.SelectedItem as Lesson;
            if (selectedLesson == null)
                return;
            await Navigation.PushAsync(new LessonDetailPage(selectedLesson));

            LessonListView.SelectedItem = null;
        }
    }
}
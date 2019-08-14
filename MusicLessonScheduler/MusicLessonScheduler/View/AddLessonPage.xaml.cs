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
	public partial class AddLessonPage : ContentPage
	{
		public AddLessonPage (Student student)
		{
			InitializeComponent ();
            studentValue = student;
            BindingContext = viewModel = new AddLessonViewModel(Student);
		}
        private Student studentValue;
        AddLessonViewModel viewModel;
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
	}
}
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
	public partial class EditStudentPage : ContentPage
	{
		public EditStudentPage (StudentDetailViewModel viewModel)
		{
			InitializeComponent ();
            Student = viewModel.Student;
            BindingContext = vm = new EditStudentViewModel(Student);
		}
        public Student Student { get; set; }
        EditStudentViewModel vm;
	}
}
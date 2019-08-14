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
	public partial class EditLessonPage : ContentPage
	{
		public EditLessonPage (LessonDetailViewModel viewModel)
		{
			InitializeComponent ();
            Lesson = viewModel.Lesson;
            BindingContext = vm = new EditLessonViewModel(Lesson);
		}
        public Lesson Lesson { get; set; }
        EditLessonViewModel vm;
	}
}
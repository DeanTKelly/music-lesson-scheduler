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
	public partial class LessonDetailPage : ContentPage
	{
		public LessonDetailPage (Lesson lesson)
		{
			InitializeComponent ();
            lessonValue = lesson;
            BindingContext = viewModel = new LessonDetailViewModel(lesson);
		}
        private Lesson lessonValue;
        LessonDetailViewModel viewModel;
        public Lesson Lesson
        {
            set
            {
                if(lessonValue != value)
                {
                    lessonValue = value;
                    OnPropertyChanged();
                }
            }
            get
            {
                return lessonValue;
            }
        }
	}
}
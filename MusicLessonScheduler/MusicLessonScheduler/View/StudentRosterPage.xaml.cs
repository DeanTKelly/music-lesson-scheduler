using MusicLessonScheduler.Model;
using MusicLessonScheduler.View;
using MusicLessonScheduler.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicLessonScheduler
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StudentRosterPage : ContentPage
	{
        StudentRosterViewModel viewModel = new StudentRosterViewModel();
		public StudentRosterPage ()
		{
			InitializeComponent ();

            BindingContext = viewModel;

            StudentsListView.IsPullToRefreshEnabled = true;
            StudentsListView.SetBinding(ListView.IsRefreshingProperty, nameof(viewModel.IsBusy));
		}

        async void StudentsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var student = e.SelectedItem as Student;
            if (student == null)
                return;
            await Navigation.PushAsync(new StudentDetailPage(student));
            StudentsListView.SelectedItem = null;
        }
    }
}
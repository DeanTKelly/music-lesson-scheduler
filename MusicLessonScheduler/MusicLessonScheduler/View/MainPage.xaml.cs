using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MusicLessonScheduler
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }                
        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            bool isUserNameEmpty = string.IsNullOrEmpty(userNameEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);
            if(isUserNameEmpty || isPasswordEmpty || userNameEntry.Text != "test" || passwordEntry.Text != "test")
            {
                DisplayAlert("Error", "Invalid credentials. Please double-check your entry and try again.", "OK");
            }
            else 
            {
                Navigation.PushAsync(new StudentRosterPage());
            }
        }
    }
}

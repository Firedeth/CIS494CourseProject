using CIS494CourseProject.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static CIS494CourseProject.SQLiteDb;

namespace CIS494CourseProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        private void CreateAccountClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync( new CreateAccountPage() );
        }

        private void LoginButtonClicked(object sender, EventArgs e)
        {
            LoginData user = new LoginData();
            user.UserName = userNameInput.Text;
            user.Password = userPasswordInput.Text;
            Debug.WriteLine("Login successful? - " + LoginUser(user));
            if (Globals.isLoggedIn == false)
            {
                ErrorText.Text = "Wrong Username or Password Entered";
                ErrorText.IsVisible = true;
            } else
            {
                Navigation.PushAsync(new MainPage());
            }
        }
    }
}
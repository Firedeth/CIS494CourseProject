using CIS494CourseProject.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
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
            SHA512 myHash = SHA512.Create();
            byte[] hashValue = null;
            StringBuilder hashedPass = new StringBuilder();
            
            myHash.Initialize();
            myHash.GetHashCode();
            if (userPasswordInput.Text != null)
            {
            hashValue = myHash.ComputeHash(Encoding.UTF8.GetBytes(userPasswordInput.Text));
                foreach (var x in hashValue)
                {
                    hashedPass.Append(x).ToString();
                }
            }
            if (hashedPass != null)
            {
                user.Password = hashedPass.ToString();
            }
            Debug.WriteLine("Login Username =  " + user.UserName + " Login Password = " + user.Password);
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
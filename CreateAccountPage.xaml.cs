using CIS494CourseProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static CIS494CourseProject.SQLiteDb;
using System.Security.Cryptography;
using System.Diagnostics;

namespace CIS494CourseProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateAccountPage : ContentPage
	{
		public CreateAccountPage ()
		{
			InitializeComponent ();
            
		}

        private void CreateNewAccountClicked(object sender, EventArgs e)
        {
            LoginData user = new LoginData();
            user.UserName = CreateAccountUsername.Text;
            if (CreateAccountPassword.Text == CreateAccountPasswordTest.Text)
            {
                SHA512 myHash = SHA512.Create();
                myHash.Initialize();
                myHash.GetHashCode();
                byte[] hashValue = myHash.ComputeHash(Encoding.UTF8.GetBytes(CreateAccountPassword.Text));

                StringBuilder hashedPass = new StringBuilder();
                foreach (var x in hashValue)
                {
                    hashedPass.Append(x).ToString();
                }

                user.Password = hashedPass.ToString();
                user.Email = CreateAccountEmail.Text;
                Debug.WriteLine("Username = " + user.UserName);
                Debug.WriteLine("Hashed = " + user.Password);
                CreateUser(user);
                CreateNewAccountButton.IsVisible = false;
                CancelButton.Text = "Done";
                CreateSuccessfulLabel.IsVisible = true;
            } else
            {
                
            }
        }

        private void CancelClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
using CIS494CourseProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static CIS494CourseProject.SQLiteDb;

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
                user.Password = CreateAccountPassword.Text;
                CreateUser(user);
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
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

        public void CreateUserAccount(string username, string password)
        {
            //LoginData user = new LoginData(username, password);
            //App.database.InsertAsync(user);
        }

        private void CreateNewAccountClicked(object sender, EventArgs e)
        {
            CreateUserAccount(CreateAccountUsername.Text, CreateAccountPassword.Text);
        }
    }
}
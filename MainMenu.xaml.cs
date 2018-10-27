using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIS494CourseProject.Model;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CIS494CourseProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainMenu : ContentPage
	{
		public MainMenu ()
		{
			InitializeComponent ();
            
                WelcomeText.Text = "Logged in successfully! Welcome " + App.database.GetUserName(Globals.UserID) + "!";

        }
	}
}
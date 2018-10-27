using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;
using CIS494CourseProject.Model;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CIS494CourseProject
{
    public partial class App : Application
    {
        public static SQLiteDb database; 

        public App()
        {

        InitializeComponent();

            database = new SQLiteDb(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FoodTrackerDB.db"));
            //database.ClearLoginDatabase();
            database.ClearFoodData();
            database.Create();
            MainPage = new NavigationPage(new MainPage());

            
        }

        

        protected override void OnStart()
        {
            // Handle when your app starts
            Globals.isLoggedIn = false;
            Globals.UserID = null;
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            Globals.isLoggedIn = false;
            Globals.UserID = null;
            MainPage = new NavigationPage(new MainPage());
        }


    }
}

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CIS494CourseProject
{
    public partial class App : Application
    {
        public static SQLiteAsyncConnection database;
        public static string dbPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Database\\FoodTrackerDB.db";


        public App()
        {
            InitializeComponent();
            database = new SQLiteAsyncConnection(dbPath);
            MainPage = new NavigationPage( new MainPage() );
            
            
        }

        

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public SQLiteAsyncConnection CreateSQLiteDatabaseConnection(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            return database;
        }
    }
}

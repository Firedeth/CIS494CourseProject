﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CIS494CourseProject
{
    public partial class App : Application
    {
        static SQLiteDb database; 

        public App()
        {

        InitializeComponent();

            database = new SQLiteDb(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FoodTrackerDB.db"));
            database.Create();

            MainPage = new NavigationPage(new MainPage());

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


    }
}

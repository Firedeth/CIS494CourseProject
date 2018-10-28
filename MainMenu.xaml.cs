﻿using CIS494CourseProject.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts;
using SkiaSharp;
using Entry = Microcharts.Entry;
using System.Collections.Generic;
using static CIS494CourseProject.SQLiteDb;

namespace CIS494CourseProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu : ContentPage
    {
        public MainMenu()
        {
            InitializeComponent();

            WelcomeText.Text = "Logged in successfully! Welcome " + App.database.GetUserName(Globals.UserID) + "!";

            List<Entry> entries = new List<Entry>
            {
                new Entry(200)
                {
                    Label = "January",
                    ValueLabel = "200",
                    Color = SKColor.Parse("#266489")
                },
                new Entry(400)
                {
                    Label = "February",
                    ValueLabel = "400",
                    Color = SKColor.Parse("#68B9C0")
                },
                new Entry(-100)
                {
                    Label = "March",
                    ValueLabel = "-100",
                    Color = SKColor.Parse("#90D585")
                }
            };

            chart.Chart = new RadarChart()
            {
                Entries = entries
            };

            List<Entry> dateEntries = new List<Entry>();
            
                foreach (var trans in App.database.GetFoodTransactionsUser())
                {
                    int count = App.database.GetCountOfTransactionsOnDate(trans.DateAndTime);

                var entry = new Entry(count)
                {
                    Label = trans.DateAndTime.Month.ToString() + "\\" + trans.DateAndTime.Day.ToString() + "\\" + trans.DateAndTime.Year.ToString(),
                    ValueLabel = count.ToString(),
                    Color = SKColor.Parse("#90D585")

                };


                //var duplicate = dateEntries.Find(d => d.Label == entry.Label);
                //if (duplicate != null)
                //    {
                dateEntries.Add(entry);
                //    }
                }
            

            DateChart.Chart = new LineChart()
            {
                Entries = dateEntries
            };

            List<string> foodTransList = new List<string>();
            var foodTransUserList = App.database.GetFoodTransactionsUser();
            foreach (var ft in foodTransUserList)
            {
                foodTransList.Add(ft.DateAndTime + " - " + App.database.GetConcernLevelFromID(ft.ConcernLevelID) + " - " + App.database.GetFoodNameFromID(ft.FoodID));
            }
            RecentTransactions.ItemsSource = foodTransList;
        }

        private void LogFoodTransButtonClicked(object sender, System.EventArgs e)
        {
            Navigation.InsertPageBefore(new LogFoodTrans(), this);
            Navigation.PopAsync();
        }
    }
}
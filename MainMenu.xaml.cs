using CIS494CourseProject.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts;
using SkiaSharp;
using Entry = Microcharts.Entry;
using System.Collections.Generic;
using static CIS494CourseProject.SQLiteDb;
using System.Diagnostics;
using System.Linq;

namespace CIS494CourseProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu : ContentPage
    {
        public MainMenu()
        {
            InitializeComponent();

            WelcomeText.Text = "Logged in successfully! Welcome " + GetUserName(Globals.UserID) + "!";

            //List<Entry> entries = new List<Entry>
            //{
            //    new Entry(200)
            //    {
            //        Label = "January",
            //        ValueLabel = "200",
            //        Color = SKColor.Parse("#266489")
            //    },
            //    new Entry(400)
            //    {
            //        Label = "February",
            //        ValueLabel = "400",
            //        Color = SKColor.Parse("#68B9C0")
            //    },
            //    new Entry(-100)
            //    {
            //        Label = "March",
            //        ValueLabel = "-100",
            //        Color = SKColor.Parse("#90D585")
            //    }
            //};

            //chart.Chart = new RadarChart()
            //{
            //    Entries = entries
            //};

            List<Entry> dateEntries = new List<Entry>();

            foreach (var trans in App.database.GetFoodTransactionsUser().Select(X => X.DateAndTime.Date).Distinct())
            {
                int count = App.database.GetCountOfTransactionsOnDate(trans);

                var entry = new Entry(count)
                {
                    Label = trans.Month.ToString() + "\\" + trans.Day.ToString() + "\\" + trans.Year.ToString(),
                    ValueLabel = count.ToString(),
                    Color = SKColor.Parse("#4232EC")

                };

                dateEntries.Add(entry);
            }


            DateChart.Chart = new LineChart()
            {
                Entries = dateEntries

            };

            List<string> foodTransList = new List<string>();
            List<FoodTransaction> foodTransUserList = App.database.GetFoodTransactionsUser();
            //List<System.DateTime> dates = foodTransUserList.Select(d => d.DateAndTime.Date).Distinct().ToList();

            //Dictionary<System.DateTime, int> count = new Dictionary<System.DateTime, int>();

            //foreach (var fTrans in foodTransUserList.Select(X => X.DateAndTime).Distinct())
            //{
            //    dateEntries.Add(fTrans, foodTransUserList.Where(d => d.DateAndTime == date).Count());
            //}


            //Food Transaction display for users
            foreach (var ft in foodTransUserList)
            {
                foodTransList.Add(ft.DateAndTime + " - " + App.database.GetConcernLevelFromID(ft.ConcernLevelID) + " - " + App.database.GetFoodNameFromID(ft.FoodID));
            }
            foodTransList.Sort();
            foodTransList.Reverse();
            RecentTransactions.ItemsSource = foodTransList;
        }

        private void LogFoodTransButtonClicked(object sender, System.EventArgs e)
        {
            Navigation.InsertPageBefore(new LogFoodTrans(), this);
            Navigation.PopAsync();
        }


    }


}
using CIS494CourseProject.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts;
using SkiaSharp;
using Entry = Microcharts.Entry;
using System.Collections.Generic;

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


        }
    }
}
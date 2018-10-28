using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static CIS494CourseProject.SQLiteDb;
using CIS494CourseProject.Model;
using System.Diagnostics;

namespace CIS494CourseProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LogFoodTrans : ContentPage
	{
		public LogFoodTrans ()
		{
			InitializeComponent ();

            List<string> dataSourceFoods = new List<string>();
            foreach (string food in App.database.GetFoodNames())
            {
                dataSourceFoods.Add(food);
                
            }

            foodChoicePicker.ItemsSource = dataSourceFoods;

            reactionDatePicker.MaximumDate = DateTime.Parse(DateTime.Now.ToString());

            reactionTimePicker.Time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            concernLevelPicker.ItemsSource = App.database.GetConcernLevels();

		}

        private void submitTransactionButtonClicked(object sender, EventArgs e)
        {
            FoodTransaction foodTrans = new FoodTransaction();
            foodTrans.DateAndTime = new DateTime(reactionDatePicker.Date.Year, reactionDatePicker.Date.Month, reactionDatePicker.Date.Day, reactionTimePicker.Time.Hours, reactionTimePicker.Time.Minutes, reactionTimePicker.Time.Seconds);
            foodTrans.ConcernLevelID = App.database.GetConcernLevelFromDetails(concernLevelPicker.SelectedItem.ToString());
            foodTrans.UserID = Globals.UserID.Value;
            foodTrans.FoodID = App.database.GetFoodIDFromName(foodChoicePicker.SelectedItem.ToString());
            App.database.AddFoodTransaction(foodTrans);
            Debug.WriteLine("Added Food Transaction: || ID: " + foodTrans.FoodTransID + " -> ConcernID: " + foodTrans.ConcernLevelID + " -> On " + foodTrans.DateAndTime + " -> For User: " + foodTrans.UserID + " Food: " + App.database.GetFoodNameFromID(foodTrans.FoodID));

            Navigation.InsertPageBefore(new MainMenu(), this);
            Navigation.PopAsync();
        }

    }
}
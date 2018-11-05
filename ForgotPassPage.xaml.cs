using CIS494CourseProject.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static CIS494CourseProject.SQLiteDb;

namespace CIS494CourseProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPassPage : ContentPage
    {
        public ForgotPassPage()
        {
            InitializeComponent();
        }

        private void CheckSecAnswerClicked(object sender, EventArgs e)
        {

            long? userID = GetUserID(ForgotUserNameInput.Text);
            LoginData user = App.database.GetUserByID(userID);
            if (user != null)
            {
                if (SecurityAnswerInput.Text?.ToLower() == user.SecurityAnswer)
                {
                    Navigation.PushAsync(new ResetPassPage(userID));
                }


            }
        }

        private void CancelClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void UserNameChanged(object sender, TextChangedEventArgs e)
        {
            long? userID = GetUserID(ForgotUserNameInput.Text);
            if (userID != null)
            {
                LoginData user = App.database.GetUserByID(userID);
                if (user != null)
                {
                    SecurityQuestionLabel.Text = user.SecurityQuestion;
                }
            }

        }
    }
}
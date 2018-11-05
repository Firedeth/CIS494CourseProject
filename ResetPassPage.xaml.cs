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
    public partial class ResetPassPage : ContentPage
    {
        long? userID;
        public ResetPassPage(long? UserID)
        {
            InitializeComponent();
            userID = UserID;
        }

        private void PassResetClicked(object sender, EventArgs e)
        {

            LoginData user = App.database.GetUserByID(userID);
            if (user != null)
            {
                if (ResetPassInput1.Text == ResetPassInput2.Text)
                {
                    SHA512 myHash = SHA512.Create();
                    myHash.Initialize();
                    myHash.GetHashCode();
                    byte[] hashValue = myHash.ComputeHash(Encoding.UTF8.GetBytes(ResetPassInput1.Text));

                    StringBuilder hashedPass = new StringBuilder();
                    foreach (var x in hashValue)
                    {
                        hashedPass.Append(x).ToString();
                    }

                    user.Password = hashedPass.ToString();
                }


            }
        }

        private void CancelClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

    }
}
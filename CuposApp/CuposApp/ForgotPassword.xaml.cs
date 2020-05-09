using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CuposApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPassword : ContentPage
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        async void OnClickChangePassword(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(email_entry.Text) && !string.IsNullOrWhiteSpace(passw_entry.Text) && !string.IsNullOrWhiteSpace(cpassw_entry.Text))
            {

                try
                {
                    string dbEmail = (App.Database.GetUserByEmailAsync(email_entry.Text).Result.Email).ToString();
                    var user = new User
                    {
                        Email = email_entry.Text,
                        Password = passw_entry.Text
                    };

                    if (dbEmail == email_entry.Text)
                    {
                        //Application.Current.MainPage = new MainView(user);
                        await App.Database.UpdateUserAsync(user);
                        await DisplayAlert("Alert", "Password has been changed.", "OK");
                    }

                }
                catch (AggregateException)
                {
                    await DisplayAlert("Error", "User has not found.", "OK");
                }

            }
        }
    }
}
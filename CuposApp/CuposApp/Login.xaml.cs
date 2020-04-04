using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace CuposApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        async void OnClickLogin(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(email_entry.Text) && !string.IsNullOrWhiteSpace(passw_entry.Text))
            {
                var user = new User
                {
                    Email = email_entry.Text,
                    Password = passw_entry.Text
                };
                
                if (App.Database.GetUserByLoginAsync(user).IsFaulted)
                {
                    await Navigation.PushAsync(new MainView(user));
                    //await DisplayAlert("Alert", "Hey"+ App.Database.GetUserByLoginAsync(user).IsFaulted, "OK");
                }
                else
                {
                    await DisplayAlert("Alert", "Wrong Email or Password", "OK");
                }
            }
                
            
        }

        async void OnClickCreateAccount(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateAccount());
        }

        async void OnClickForgotPassword(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "Password forgot", "OK");
        }

        /** Lifecycle State Login entrys persistens **/
        protected override void OnAppearing()
        {
            base.OnAppearing();

            email_entry.Text = (Application.Current as App).DisplayTextEmail;
            passw_entry.Text = (Application.Current as App).DisplayTextPassw;
        }

        void OnEntryCompleted(object sender, EventArgs e)
        {
            (Application.Current as App).DisplayTextEmail = email_entry.Text;
            (Application.Current as App).DisplayTextPassw = passw_entry.Text;
        }
        /** ======================================== **/
    }
}

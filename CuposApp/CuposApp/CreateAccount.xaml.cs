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
    public partial class CreateAccount : ContentPage
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        async void OnClickSignin(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(email_entry.Text) && !string.IsNullOrWhiteSpace(passw_entry.Text))
            {
                var user = new User
                {
                    Email = email_entry.Text,
                    Password = passw_entry.Text
                };
                await App.Database.SaveUserAsync(user);

                email_entry.Text = passw_entry.Text = string.Empty;

                //await Navigation.PopAsync();
                await Navigation.PushAsync(new MainView(user));
            }
        }

    }
}
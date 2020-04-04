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
    public partial class MainView : ContentPage
    {
        User user;
        public MainView(User userLogged)
        {
            InitializeComponent();
            user = userLogged;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            usersDB.ItemsSource = await App.Database.GetAllUsersAsync();
            //User userTemp = await App.Database.GetUserByEmailAsync(user.Email);
            //userEmail.BindingContext = new {Email = "smf-mena", Password = "1234"};
            userEmail.BindingContext = await App.Database.GetUserByEmailAsync(user.Email);
        }

        async void OnClickLogout(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }
    }
}
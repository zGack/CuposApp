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
    public partial class UsersDatabse : ContentPage
    {
        public UsersDatabse()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            usersList.ItemsSource = await App.Database.GetAllUsersAsync();
        }

        

    }
}
using System;
using Xamarin.Forms;
using System.IO;

namespace CuposApp
{
    public partial class App : Application
    {
        static Database database;

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
                }
                return database;
            }
        }

        const string displayTextEmail = "displayTextEmail";
        const string displayTextPassw = "displayTextPassw";
        public string DisplayTextEmail { get; set; }
        public string DisplayTextPassw { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new Login());
        }

        protected override void OnStart()
        {
            Console.WriteLine("OnStart");

            if (Properties.ContainsKey(displayTextEmail))
            {
                DisplayTextEmail = (string)Properties[displayTextEmail];
            }

            if (Properties.ContainsKey(displayTextPassw))
            {
                DisplayTextPassw = (string)Properties[displayTextPassw];
            }
        }

        protected override void OnSleep()
        {
            Properties[displayTextEmail] = DisplayTextEmail;
            Properties[displayTextPassw] = DisplayTextPassw;
        }

        protected override void OnResume()
        {
        }
    }
}

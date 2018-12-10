using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MyJournal
{
    public partial class App : Application
    {
        //define database. This path will be different for each device
        public static string DB_PATH = string.Empty;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        //Create new constructor to request the database
        public App(string DB_Path)
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
            DB_PATH = DB_Path;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

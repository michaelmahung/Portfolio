using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CheckMeFinal
{
    public partial class App : Application
    {
        public static string SQL_PATH = string.Empty;
        public static string Default_Path = string.Empty;
        public static string Image_Path = string.Empty;
        public static string Application_Path = string.Empty;
        public static User CurrentUser = null;

        public App(string sql_path, string default_path)
        {
            InitializeComponent();

            SQL_PATH = sql_path;

            Default_Path = default_path;

            MainPage = new NavigationPage(new MainPage());
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

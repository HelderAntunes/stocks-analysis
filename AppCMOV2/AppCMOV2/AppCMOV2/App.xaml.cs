using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppCMOV2.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppCMOV2
{
    public partial class App : Application
    {
        public static string base_url = "http://192.168.1.4:3000/api/"; // 192.168.1.4

        public App()
        {
            InitializeComponent();


            MainPage = new MainPage();
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

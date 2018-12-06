using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppCMOV2.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppCMOV2
{
    public partial class App : Application
    {
        public static string base_url = "http://localhost:3000/api/stocks?company=INTC&type=monthly&startDate=20180701";

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

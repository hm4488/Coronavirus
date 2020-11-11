using System;
using System.Security.Cryptography.X509Certificates;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CovidApp
{
    public partial class App : Application
    {

        public static bool flag = true;
        public static bool otherflag = true;
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new GeneralInformationPage() );
            /*var nav = new NavigationPage
            {
                Title = "Detail"
            };
            nav.PushAsync(new GeneralInformationPage() { Title = "General" });
            nav.BarBackgroundColor = Color.MediumPurple;

            var mdp = new MasterDetailPage()
            {
                Master = new ContentPage()
                {
                    Title = "Master"
                },
                Detail = nav
            };
            MainPage = mdp;*/
            MainPage = new MainPage();
            //AppTheme appTheme = AppInfo.RequestedTheme;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

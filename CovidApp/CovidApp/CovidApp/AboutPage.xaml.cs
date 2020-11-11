using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CovidApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();

            appNameLabel.Text = $"{AppInfo.Name}";
            appVersionLabel.Text = $"{AppInfo.VersionString}" + $"{AppInfo.BuildString}";
        }
    }
}
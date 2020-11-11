using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CovidApp
{
    // Learn more about making custom C:\Users\harsh\source\repos\covid-19-project-hm4488\CovidApp\CovidApp\CovidApp\MainPage.xaml.cscode visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            masterPage.listViewMaster.ItemSelected += OnItemSelected;
            if (Device.RuntimePlatform == Device.UWP)
            {
                MasterBehavior = MasterBehavior.Popover;
            }

            
        }

       void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                BackButtonPressedEventArgs backButtonPressedEventArgs = new BackButtonPressedEventArgs();
                backButtonPressedEventArgs.Handled = false;
               Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                
               // await Detail.Navigation.PushAsync((Page)Activator.CreateInstance(item.TargetType));
                masterPage.listViewMaster.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}

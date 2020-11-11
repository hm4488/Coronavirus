using Lottie.Forms;
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
    public partial class SurvivalGuidePage : ContentPage
    {
        public SurvivalGuidePage()
        {
            InitializeComponent();
            //carouselCollectionView.ItemsSource = SurvivalGuideCollection.Guides;
           
        }
    }
}
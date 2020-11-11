using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;
using Microcharts;
using RestSharp;
using Newtonsoft.Json;

namespace CovidApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeneralInformationPage : ContentPage
    {

        public static List<CoronavirusInfoData> coronavirusDataWorldWide = new List<CoronavirusInfoData>();
        public GeneralInformationPage()
        {
            InitializeComponent();



            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var client = new RestClient("https://covid-19-data.p.rapidapi.com/totals?format=undefined");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "covid-19-data.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "54c7eaa2camsh3bfb99864b4ad3ep111186jsn385646837c47");
            IRestResponse response = client.Execute(request);

            
            var cData = JsonConvert.DeserializeObject<System.Collections.Generic.List<CoronavirusInfoData>>(response.Content);
            CoronavirusInfoData coronavirusDataInfoData = new CoronavirusInfoData(cData[0].confirmed, cData[0].recovered, cData[0].deaths);
            coronavirusDataWorldWide.Add(coronavirusDataInfoData);
           
            var entries = new[]
            {
                new Microcharts.Entry(float.Parse(cData[0].confirmed.ToString()))
                {
                    Label = "Confirmed",
                    ValueLabel = cData[0].confirmed.ToString(),
                    Color = SKColor.Parse("#FFFF00")
                    
                },

                new Microcharts.Entry(float.Parse(cData[0].recovered.ToString()))
                {
                    Label = "Recovered",
                    ValueLabel = cData[0].recovered.ToString(),
                    Color = SKColor.Parse("#7cfc00")
                },

                new Microcharts.Entry(float.Parse(cData[0].deaths.ToString()))
                {
                    Label = "Deaths",
                    ValueLabel = cData[0].deaths.ToString(),
                    Color = SKColor.Parse("#FF0000")
                }
            };


           
            var chart = new DonutChart() { Entries = entries };
            
            chartView.Chart = chart;
            
            chartView.Chart.BackgroundColor = SKColor.Parse("#00FFFFFF");

            //confirmedLabel.Text = cData[0].confirmed;
            //recoveredLabel.Text = cData[0].recovered;
            //deathsLabel.Text = cData[0].deaths;

            confirmedLabel.Text = Convert.ToDouble(cData[0].confirmed).ToString("N0");
            recoveredLabel.Text = Convert.ToDouble(cData[0].recovered).ToString("N0");
            deathsLabel.Text = Convert.ToDouble(cData[0].deaths).ToString("N0");
        }

        public class CoronavirusInfoData
        {
            public string confirmed { get; set; }
            public string recovered { get; set; }
            public string critical { get; set; }
            public string deaths { get; set; }

            public CoronavirusInfoData(string _confirmed, string _recovered, string _deaths)
            {
                confirmed = _confirmed;
                recovered = _recovered;
                deaths = _deaths;
            }
        }
    }
}
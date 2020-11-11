using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace CovidApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsPage : ContentPage
    {
        //public static List<NewsAPI> newsAPIData = new List<NewsAPI>();
         public static ObservableCollection<Value> valueData = new ObservableCollection<Value>();
        public NewsPage()
        {

            InitializeComponent();

            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();



            //carouselView.ItemsSource = valueData;

            /* for (int i = 0; i < newsData.Count; i++)
             {

                 NewsAPI newsAPI = new NewsAPI(newsData[i].date, newsData[i].img, newsData[i].title, newsData[i].content, newsData[i].source_url, newsData[i].source_name, newsData[i].category, newsData[i].keywords);

                 newsAPIData.Add(newsAPI);
             }*/

            /*collectionView.ItemsSource = valueData;
            collectionView.SelectionChanged += async (s, e) =>
            {
                Value itemSelected = e.CurrentSelection as Value;
                int number = int.Parse(itemSelected.ToString());
                await Browser.OpenAsync(valueData[number].url, new BrowserLaunchOptions
                {
                    LaunchMode = BrowserLaunchMode.SystemPreferred,
                    TitleMode = BrowserTitleMode.Show,
                    PreferredToolbarColor = Color.AliceBlue,
                    PreferredControlColor = Color.Violet
                });

                //collectionView.SelectedItem = null;
            };*/
            
                var client = new RestClient("https://microsoft-azure-bing-news-search-v1.p.rapidapi.com/search?q=Coronavirus");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "microsoft-azure-bing-news-search-v1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "54c7eaa2camsh3bfb99864b4ad3ep111186jsn385646837c47");
            IRestResponse response = client.Execute(request);

            var newsData = JsonConvert.DeserializeObject<NewsAPI>(response.Content);

            /* var client = new RestClient("https://newscafapi.p.rapidapi.com/apirapid/news/?q=Coronavirus");
             var request = new RestRequest(Method.GET);
             request.AddHeader("x-rapidapi-host", "newscafapi.p.rapidapi.com");
             request.AddHeader("x-rapidapi-key", "54c7eaa2camsh3bfb99864b4ad3ep111186jsn385646837c47");
             IRestResponse response = client.Execute(request);
             var newsData = JsonConvert.DeserializeObject<List<NewsAPI>>(response.Content);*/

            if (App.flag == true)
            {

                for (int i = 0; i < newsData.value.Count; i++)
                {

                    Value valueStuff = new Value(newsData.value[i].name, newsData.value[i].url, newsData.value[i].image, newsData.value[i].description, newsData.value[i].mentions, newsData.value[i].provider, newsData.value[i].datePublished, newsData.value[i].category, newsData.value[i].about, newsData.value[i].video);

                    valueData.Add(valueStuff);
                }
                App.flag = false;
            }

            listViewNews.ItemsSource = valueData;

            listViewNews.ItemTapped += async (s, e) =>
            {
                Value itemTapped = e.Item as Value;
                await Browser.OpenAsync(itemTapped.url, new BrowserLaunchOptions
                {
                    LaunchMode = BrowserLaunchMode.SystemPreferred,
                    TitleMode = BrowserTitleMode.Show,
                    PreferredToolbarColor = Color.MediumPurple,
                    PreferredControlColor = Color.Violet
                });

                ((ListView)s).SelectedItem = null;
            };

        }

        
    }
    /*public class NewsAPI
    {
        public DateTime date { get; set; }
        public string img { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string source_url { get; set; }
        public string source_name { get; set; }
        public string category { get; set; }
        public string keywords { get; set; }

        public NewsAPI(DateTime _date, string _img, string _title, string _content, string _source_url, string _source_name, string _category, string _keywords)
        {
            date = _date;
            img = _img;
            title = _title;
            content = _content;
            source_url = _source_url;
            source_name = _source_name;
            category = _category;
            keywords = _keywords;
        }
    }*/
    public class QueryContext
    {
        public string originalQuery { get; set; }
        public bool adultIntent { get; set; }
    }

    public class Sort
    {
        public string name { get; set; }
        public string id { get; set; }
        public bool isSelected { get; set; }
        public string url { get; set; }
    }

    public class Thumbnail
    {
        public string contentUrl { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Image
    {
        public Thumbnail thumbnail { get; set; }
    }

    public class Mention
    {
        public string name { get; set; }
    }

    public class Thumbnail2
    {
        public string contentUrl { get; set; }
    }

    public class Image2
    {
        public Thumbnail2 thumbnail { get; set; }
    }

    public class Provider
    {
        public string _type { get; set; }
        public string name { get; set; }
        public Image2 image { get; set; }
    }

    public class About
    {
        public string readLink { get; set; }
        public string name { get; set; }
    }

    public class Thumbnail3
    {
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Video
    {
        public string name { get; set; }
        public string thumbnailUrl { get; set; }
        public string embedHtml { get; set; }
        public bool allowHttpsEmbed { get; set; }
        public Thumbnail3 thumbnail { get; set; }
    }

    public class Value
    {
        public string name { get; set; }
        public string url { get; set; }
        public Image image { get; set; }
        public string description { get; set; }
        public List<Mention> mentions { get; set; }
        public List<Provider> provider { get; set; }
        public DateTime datePublished { get; set; }
        public string category { get; set; }
        public List<About> about { get; set; }
        public Video video { get; set; }

        public Value(string _name, string _url, Image _image, string _description, List<Mention> _mentions, List<Provider> _provider, DateTime _datePublished, string _category, List<About> _about, Video _video)
        {
            name = _name;
            url = _url;
            image = _image;
            description = _description;
            mentions = _mentions;
            provider = _provider;
            datePublished = _datePublished;
            category = _category;
            about = _about;
            video = _video;
        }

    }

    public class NewsAPI
    {
        public string type { get; set; }
        public string readLink { get; set; }
        public QueryContext queryContext { get; set; }
        public int totalEstimatedMatches { get; set; }
        public List<Sort> sort { get; set; }
        public List<Value> value { get; set; }

        public NewsAPI(List<Value> values)
        {
            //Value newValue = new Value();
            value = values;
            //newValue.Add(newValue);




        }


    }
}
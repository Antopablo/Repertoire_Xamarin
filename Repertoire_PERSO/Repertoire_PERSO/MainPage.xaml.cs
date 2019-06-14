using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Repertoire_PERSO.modele;

namespace Repertoire_PERSO
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public IList<Contact> ListeContact { get; private set; }
        public const string APITwitter = "https://api.twitter.com/1.1/statuses/user_timeline.json";
        public const string Twitter_KEY = "mnKaIsXI3WfOL1XjwAFVVr1OM";
        public const string Twitter_KEY_SECRET = "zQ9LIRZJmPEoNkdTu2iveilGXYZLb2jjZnrOqklY33F9K4qwDj";
        public const string OpenWeatherMapEndpoint = "https://api.openweathermap.org/data/2.5/weather";
        public const string OpenWeatherMapAPIKey = "9813f94d8ac56780465d6a3503a30a53";
        RestService _restService;

        public MainPage()
        {
            InitializeComponent();

            ListeContact = new List<Contact>();
            _restService = new RestService();
        }

        

        private void OrderByName(ListView L)
        {
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            

            ListeView.ItemsSource = await App.Database.GetContactsAsync();
            ListeView.HasUnevenRows = true;
        }

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Ajout_Contact
            {
                BindingContext = new Contact()
            });
        }

        async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new Afficher_Details((Contact)ListeView.SelectedItem));
        }

        
    }
}

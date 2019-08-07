using Repertoire_PERSO.modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceTutorial;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Repertoire_PERSO
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Afficher_Details : ContentPage
    {
        Contact cont;
        RestService _restService;

        public Afficher_Details(Contact C)
        {
            InitializeComponent();
            cont = C;
            Nom.Text = cont.nom;
            prenom.Text = cont.prenom;
            tel.Text = cont.numero;
            mail.Text = cont.mail;
            ville.Text = cont.ville;
            adresse.Text = cont.rue;
            _restService = new RestService();
        }

        async void Supprimer_Contact_Click(object sender, EventArgs e)
        {
            bool response = await DisplayAlert("Suppression", "Supprimer ce contact?", "Oui", "Non");
            if (response)
            {
                await App.Database.DeleteContactAsync(cont);
                Bouton_SupprimerContact.IsVisible = false;
                Bouton_ModifierContact.IsVisible = false;
                OnAppearing();
                await Navigation.PopAsync();
            }
        }

        async void Modifier_Contact_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page_modifer(cont));
        }

        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?q={ville.Text}";
            requestUri += "&units=metric"; // or units=metric
            requestUri += $"&APPID={MainPage.OpenWeatherMapAPIKey}";
            return requestUri;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (!string.IsNullOrWhiteSpace(ville.Text))
            {
                WeatherDATA weatherData = await _restService.GetWeatherDataAsync(GenerateRequestUri(MainPage.OpenWeatherMapEndpoint));
                BindingContext = weatherData;
            }
        }
    }
}
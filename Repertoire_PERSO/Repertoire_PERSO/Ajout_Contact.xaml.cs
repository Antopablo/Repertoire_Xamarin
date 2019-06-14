using Repertoire_PERSO.modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Repertoire_PERSO
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ajout_Contact : ContentPage
    {
        public Ajout_Contact()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var contact = (Contact)BindingContext;
            await App.Database.SaveContactAsync(contact);
            await Navigation.PopAsync();
        }
    }
}
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
            if (contact.nom == null && contact.prenom == null)
            {
                _ = DisplayAlert("Alert", "Vous devez saisir un nom", "OK");
            }
            else
            {
                if (contact.numero == null || !IsNumeric(contact.numero))
                {
                    _ = DisplayAlert("Alert", "Vous devez saisir un numéro valide", "OK");
                }
                else
                {
                    await App.Database.SaveContactAsync(contact);
                    await Navigation.PopAsync();

                }
            }
        }

        private bool IsNumeric (string s)
        {
            int r;
            if (int.TryParse(s, out r))
            {
                return true;
            }
            else
            {
                if (s[0] == '+')
                {
                    s = s.Substring(1, s.Length);
                    IsNumeric(s);
                }
                return false;
            }
        }
    }
}
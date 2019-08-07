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
            if (contact.numero == null)
            {
            _ = DisplayAlert("Alert", "Vous devez un numéro valide", "OK");
            } else
            {
                if (IsNumeric(contact.numero))
                {
                    if (contact.nom == null && contact.prenom == null)
                    {
                        _ = DisplayAlert("Alert", "Vous devez un nom", "OK");
                    }
                    else
                    {
                        await App.Database.SaveContactAsync(contact);
                        await Navigation.PopAsync();
                    }
                } else
                {
                    _ = DisplayAlert("Alert", "Vous devez un numéro valide", "OK");
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
                return false;
            }
        }
    }
}
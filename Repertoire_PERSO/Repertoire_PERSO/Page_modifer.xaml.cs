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
    public partial class Page_modifer : ContentPage
    {
        public Contact contact { get; set; }
        public Page_modifer(Contact C)
        {
            InitializeComponent();
            contact = C;
            Nom.Text = contact.nom;
            prenom.Text = contact.prenom;
            tel.Text = contact.numero;
            mail.Text = contact.mail;
            Pseudo_twitter.Text = contact.PseudoTwitter;
            ville.Text = contact.ville;
            adresse.Text = contact.rue;
        }

        async void Modify_Clicked(object sender, EventArgs e)
        {
            contact.nom = Nom.Text;
            contact.prenom = prenom.Text;
            contact.numero = tel.Text;
            contact.mail = mail.Text;
            contact.PseudoTwitter = Pseudo_twitter.Text;
            contact.ville = ville.Text;
            contact.rue = adresse.Text;
            await App.Database.SaveContactAsync(contact);
            await Navigation.PopToRootAsync();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Repertoire_PERSO.modele
{
    public class Contact
    {
        public Contact()
        {
            ImageUrl = "img_xamarin.jpg";
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string mail { get; set; }
        public string numero { get; set; }
        public string ImageUrl { get; set; }
        public string PseudoTwitter { get; set; }
        public string rue { get; set; }
        public string ville { get; set; }



        public override string ToString()
        {
            return nom + " " + prenom;
        }
    }
}

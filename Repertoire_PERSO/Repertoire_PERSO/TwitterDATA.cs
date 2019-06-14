using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Repertoire_PERSO
{
    class TwitterDATA
    {
        [JsonProperty("name")]
        public string Auteur { get; set; }

        [JsonProperty("text")]
        public string Texte { get; set; }

        [JsonProperty("created_at")]
        public string Date { get; set; }
    }
}

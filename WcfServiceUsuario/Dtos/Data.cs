using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WcfServiceUsuario.Dtos
{
    public class Data
    {
        [JsonPropertyName("fullName")]
        public string FullName { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("idUser")]
        public int IdUser { get; set; }

        [JsonPropertyName("idRole")]
        public int IdRole { get; set; }
    }
}

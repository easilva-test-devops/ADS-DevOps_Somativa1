using Newtonsoft.Json;

namespace SiteArtesanato.Models
{
    public class Endereco
    {
        [JsonProperty("logradouro")]
        public string Logradouro { get; set; } = string.Empty;
        [JsonProperty("bairro")]
        public string Bairro { get; set; } = string.Empty;
        [JsonProperty("localidade")]
        public string Cidade { get; set; } = string.Empty;
        [JsonProperty("uf")]
        public string Estado { get; set; } = string.Empty;
    }
}

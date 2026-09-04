using Newtonsoft.Json;
using RestSharp;
using SiteArtesanato.Models;

namespace SiteArtesanato.Helpers
{
    public class ViaCep
    {
        private static string baseURL = "https://viacep.com.br/ws/";
        internal static async Task<Endereco> BuscarEndereco(string cep)
        {
            try
            {
                var client = new RestClient(baseURL + $"{cep}/json/");
                var request = new RestRequest();
                RestResponse response = await client.GetAsync(request);
                Endereco endereco = JsonConvert.DeserializeObject<Endereco>(response.Content);
                return endereco;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}

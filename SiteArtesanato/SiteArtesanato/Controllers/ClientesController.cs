using Microsoft.AspNetCore.Mvc;
using SiteArtesanato.Helpers;
using SiteArtesanato.Models;

namespace SiteArtesanato.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> PreencheEndereco(string cep)
        {
            Endereco endereco = await ViaCep.BuscarEndereco(cep);
            return new JsonResult(new { IsCreated = true, Logradouro = endereco.Logradouro, Bairro = endereco.Bairro, Cidade = endereco.Cidade, Estado = endereco.Estado});
        }
    }
}

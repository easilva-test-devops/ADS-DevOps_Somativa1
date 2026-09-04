using Microsoft.AspNetCore.Mvc;
using SiteArtesanato.DAO;
using SiteArtesanato.Models;

namespace SiteArtesanato.Controllers
{
    public class ModelosController : Controller
    {
        private readonly ProdutosDAO _produtosDAO;
        public ModelosController(ProdutosDAO produtosDAO)
        {
            _produtosDAO = produtosDAO;
        }
        public IActionResult Index()
        {
            List<Produto> listaProdutos = _produtosDAO.BuscarListaProdutos();
            return View(listaProdutos);
        }
    }
}

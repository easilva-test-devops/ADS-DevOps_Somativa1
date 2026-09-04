using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiteArtesanato.DAO;
using SiteArtesanato.DTO;
using SiteArtesanato.Models;
using System.Collections.Generic;

namespace SiteArtesanato.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly ProdutosDAO _produtosDAO;
        private readonly CarrinhosDAO _carrinhosDAO;

        public CarrinhoController(ProdutosDAO produtosDAO, CarrinhosDAO carrinhosDAO)
        {
            _produtosDAO = produtosDAO;
            _carrinhosDAO = carrinhosDAO;
        }
        public IActionResult Index()
        {
            string userId = HttpContext.Session.GetString("userId");
            Carrinho carrinho = new Carrinho();
            Dictionary<int, ItemCarrinhoDTO> itensCarrinhoDTO = new Dictionary<int, ItemCarrinhoDTO>();
            if (!string.IsNullOrEmpty(userId))
            {
                carrinho = _carrinhosDAO.BuscarCarrinhoPorUserId(userId);
                List<ItemCarrinho> itensLista = new List<ItemCarrinho>();
                itensLista = _carrinhosDAO.BuscarItensCarrinho(carrinho.CarrinhoId);
                foreach (var item in itensLista)
                {
                    ItemCarrinhoDTO itemCarrinho = new ItemCarrinhoDTO();
                    itemCarrinho.CarrinhoId = item.CarrinhoId;
                    itemCarrinho.Produto = _produtosDAO.BuscarProdutoPorId(item.ProdutoId);
                    if (itensCarrinhoDTO.TryGetValue(item.ProdutoId, out ItemCarrinhoDTO produto))
                    {
                        produto.Quantidade = produto.Quantidade + 1;
                        itensCarrinhoDTO[item.ProdutoId] = produto;
                    }
                    else
                    {
                        itemCarrinho.Quantidade = 1;
                        itensCarrinhoDTO.Add(item.ProdutoId, itemCarrinho);
                    }
                }
            }
            return View(itensCarrinhoDTO);
        }

        public JsonResult AdicionarItemCarrinho(int produtoId)
        {

            Produto produto = new Produto();
            produto = _produtosDAO.BuscarProdutoPorId(produtoId);

            string userId = HttpContext.Session.GetString("userId");
            if (string.IsNullOrEmpty(userId))
            {
                userId = Guid.NewGuid().ToString();
                HttpContext.Session.SetString("userId", userId);
            }
            string carrinhoId = HttpContext.Session.GetString("carrinhoId");
            if (string.IsNullOrEmpty(carrinhoId))
            {
                Carrinho carrinho = new Carrinho();
                carrinho.UserId = userId;
                carrinho.CarrinhoId = Guid.NewGuid();
                _carrinhosDAO.CriarCarrinho(carrinho);
                carrinhoId = carrinho.CarrinhoId.ToString();
                HttpContext.Session.SetString("carrinhoId", carrinhoId);
            }

            ItemCarrinho itemCarrinho = new ItemCarrinho();
            itemCarrinho.CarrinhoId = carrinhoId;
            itemCarrinho.ProdutoId = produtoId;

            _carrinhosDAO.AdicionarProdutoCarrinho(itemCarrinho);

            //return RedirectToAction("Index", "Modelos");
            return new JsonResult(new { IsCreated = true });
        }
        public JsonResult RemoverItemCarrinho(int produtoId, string carrinhoId)
        {
            _carrinhosDAO.RemoverItemCarrinho(produtoId, carrinhoId);

            return new JsonResult(new { IsCreated = true });
        }

        public JsonResult AlterarQuantidadeItem(int produtoId, string carrinhoId, bool aumentarQuantidade)
        {
            if (!aumentarQuantidade)
            {
                _carrinhosDAO.DiminuirQuantidade(produtoId, carrinhoId);
            }
            else
            {
                AdicionarItemCarrinho(produtoId);
            }
                return new JsonResult(new { IsCreated = true });
        }


    }
}

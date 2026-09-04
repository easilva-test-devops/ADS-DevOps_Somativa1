using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using SiteArtesanato.Data;
using SiteArtesanato.Models;

namespace SiteArtesanato.DAO
{
    public class CarrinhosDAO
    {
        private readonly ApplicationDbContext _context;
        public CarrinhosDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        internal void AdicionarProdutoCarrinho(Carrinho carrinho)
        {
            try
            {
                //Carrinho carrinhoOld = BuscarCarrinhoPorUserId(carrinho.UserId);
                //if (carrinhoOld != null)
                //{
                //    //carrinhoOld.Produtos.AddRange(carrinho.Produtos);
                //    _context.Entry(carrinhoOld).State = EntityState.Modified;
                //}
                //else
                //{
                //    _context.Carrinhos.Add(carrinho);
                //}
                //_context.Carrinhos.Add(carrinho);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal void AdicionarProdutoCarrinho(ItemCarrinho itemCarrinho)
        {
            try
            {
                _context.ItensCarrinho.Add(itemCarrinho);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        internal void AtualizarProdutoCarrinho(Carrinho carrinho)
        {
            try
            {
                //Carrinho carrinhoOld = BuscarCarrinhoPorUserId(carrinho.UserId);
                //if (carrinhoOld != null)
                //{
                //    //carrinhoOld.Produtos = carrinho.Produtos;
                //    _context.Entry(carrinhoOld).State = EntityState.Modified;
                //}
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal Carrinho BuscarCarrinhoPorUserId(string userId)
        {
            try
            {
                return _context.Carrinhos.FirstOrDefault(x => x.UserId.Equals(userId));

            }
            catch (Exception)
            {
                return null;
            }
        }

        internal List<ItemCarrinho> BuscarItensCarrinho(Guid carrinhoId)
        {
            try
            {
                return _context.ItensCarrinho.Where(x => x.CarrinhoId.Equals(carrinhoId.ToString())).ToList();

            }
            catch (Exception)
            {
                return null;
            }
        }

        internal void CriarCarrinho(Carrinho carrinho)
        {
            try
            {
                _context.Carrinhos.Add(carrinho);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal void DiminuirQuantidade(int produtoId, string carrinhoId)
        {
            try
            {
                long itemId = _context.ItensCarrinho.Where(x => x.ProdutoId == produtoId && x.CarrinhoId.Equals(carrinhoId)).ToList().Last().ItemCarrinhoId;
                _context.ItensCarrinho.Where(x => x.ItemCarrinhoId == itemId).ExecuteDelete();
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal void RemoverItemCarrinho(int produtoId, string carrinhoId)
        {
            try
            {
                _context.ItensCarrinho.Where(x=>x.ProdutoId == produtoId && x.CarrinhoId.Equals(carrinhoId)).ExecuteDelete();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

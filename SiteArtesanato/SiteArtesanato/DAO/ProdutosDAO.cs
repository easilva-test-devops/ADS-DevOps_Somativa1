using SiteArtesanato.Data;
using SiteArtesanato.Models;

namespace SiteArtesanato.DAO
{
    public class ProdutosDAO
    {
        private readonly ApplicationDbContext _context;

        public ProdutosDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Produto> BuscarListaProdutos()
        {
            List<Produto> listaProdutos = new List<Produto>();
            listaProdutos = _context.Produtos.ToList();
            return listaProdutos;
        }

        public Produto BuscarProdutoPorId(int produtoid)
        {
            Produto produto = new Produto();
            produto = _context.Produtos.FirstOrDefault(x=>x.ProdutoId == produtoid);
            return produto;
        } 

        public void AdicionarProdutos (Produto produto)
        {
            try
            {
                _context.Produtos.Add(produto); 
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

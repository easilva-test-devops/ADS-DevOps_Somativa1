
using SiteArtesanato.Models;

namespace SiteArtesanato.DTO
{
    public class ItemCarrinhoDTO
    {
        public string CarrinhoId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; } 

    }
}

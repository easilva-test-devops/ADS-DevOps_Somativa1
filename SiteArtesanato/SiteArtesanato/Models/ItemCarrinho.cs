using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteArtesanato.Models
{
    [Table("ItensCarrinho")]
    public class ItemCarrinho
    {
        [Key]
        public long ItemCarrinhoId { get; set; }
        public string? CarrinhoId { get; set; }
        public int ProdutoId { get; set; }
        public bool Status { get; set; } = true;

    }
}

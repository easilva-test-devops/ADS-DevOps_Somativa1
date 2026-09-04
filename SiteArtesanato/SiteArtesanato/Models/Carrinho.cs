using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteArtesanato.Models
{
    [Table("Carrinhos")] 
    public class Carrinho
    {
        [Key]
        public Guid CarrinhoId { get; set; }
        public string UserId { get; set; }
        public DateTime DataCarrinho { get; set; } = DateTime.Now;        
        public bool Status { get; set; } = true;

    }
}

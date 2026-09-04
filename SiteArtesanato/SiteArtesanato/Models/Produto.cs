using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteArtesanato.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public int ValorProduto { get; set; }
        public string ImagemProduto { get; set; }


    }
}

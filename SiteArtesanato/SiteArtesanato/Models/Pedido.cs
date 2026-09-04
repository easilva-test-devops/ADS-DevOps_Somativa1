using SiteArtesanato.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteArtesanato.Models
{
    [Table("Pedidos")]
    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; }
        public DateTime DataPedido { get; set; } = DateTime.Now;
        public Cliente Cliente { get; set; }
        public StatusPedido StatusPedido{ get; set; }
        public bool Status { get; set; } = true;
    }
}

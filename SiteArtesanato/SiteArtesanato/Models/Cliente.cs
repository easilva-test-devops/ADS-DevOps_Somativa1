using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteArtesanato.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [ScaffoldColumn(false)]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(50, ErrorMessage = "Max.50 caracteres")]
        [Display(Name = "*Nome: ")]
        public string NomeCliente { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",ApplyFormatInEditMode = true)]
        [Display(Name = "*Data Nascimento: ")]
        public DateTime Nascimento { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "*CPF: ")]
        public string CpfCliente { get; set; }        

        public string EmailCliente { get; set; }        
        public string CEP { get; set; }       
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        [ScaffoldColumn(false)]
        public bool Status { get; set; } = true;




    }
}

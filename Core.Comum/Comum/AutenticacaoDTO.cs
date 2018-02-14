using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Comum.Comum
{
    [Table("Autenticaao")]
    public class AutenticacaoDTO
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Nome do usu�rio � obrigat�rio")]
        [StringLength(80)]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Senha � obrigat�rio")]
        [StringLength(80)]
        public string Senha { get; set; }
    }
}
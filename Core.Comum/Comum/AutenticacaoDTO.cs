using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Comum.Comum
{
    [Table("Autenticaao")]
    public class AutenticacaoDTO
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Nome do usuário é obrigatório")]
        [StringLength(80)]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório")]
        [StringLength(80)]
        public string Senha { get; set; }
    }
}
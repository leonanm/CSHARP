using System.ComponentModel.DataAnnotations;

namespace ProjetoFinalAPI.Models
{
    public class Publisher
    {
        [Key] // Chave primária
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da editora é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome da editora deve ter no máximo 100 caracteres.")]
        public string Name { get; set; }

        [StringLength(250, ErrorMessage = "O endereço deve ter no máximo 250 caracteres.")]
        public string Address { get; set; }
    }
}

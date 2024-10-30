using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinalAPI.Models
{
    public class Book
    {
        [Key] // Chave primária
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "O ID do autor é obrigatório.")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "O ID da editora é obrigatório.")]
        public int PublisherId { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }

        [StringLength(20, ErrorMessage = "O ISBN deve ter no máximo 20 caracteres.")]
        public string ISBN { get; set; }

        // Propriedades de navegação
        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeiculosSwooshAPI.Models
{  
    [Table("Modelo")]
    public class Modelo
    {
        [Key]
        public int Id { get; set; }

    
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo Nome deve ter no máximo 50 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo MarcaId é obrigatório.")]
        public int MarcaId { get; set; }
        [ForeignKey("MarcaId")]
        public Marca Marca { get; set; }// Usado para criar a relação entre Modelo e Marca assim possicionando o nome da marca no modelo
    }
}
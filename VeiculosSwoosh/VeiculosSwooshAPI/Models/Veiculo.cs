using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeiculosSwooshAPI.Models
{
    [Table("Veiculo")]
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public short anoFabricacao { get; set; }

        [Required]
        public short anoModelo { get; set; }

        [Required]
        [Column(TypeName = "numeric(10,2)")]    
        public decimal Valor { get; set; }

        [StringLength(7)]
        public string Placa { get; set; }


        public int ModeloId { get; set; }
        [ForeignKey("ModeloId")]
        public Modelo Modelo { get; set; }

        [Required]
        public int CorId { get; set; }
        [ForeignKey("CorId")]
        public Cor Cor { get; set; }
        
    }
}
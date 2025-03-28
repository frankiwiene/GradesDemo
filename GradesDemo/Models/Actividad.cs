using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradesDemo.Models
{

    [Table("Activity")]   //Relacionamos la tabla Activity con nuestro modelo 
    public class Actividad
    {
        public int Id { get; set; }
        [ForeignKey("Subject")]  // Relación con Subject 
        public int? SubjectId { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; }
        [Range(0, 100, ErrorMessage = "Valores entre 0 y 100")]
        public decimal Grade { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        // Virtual permite Lazy Loading: Solo se carga explicitamente
        public virtual Subject? Subject { get; set; }
    }
}


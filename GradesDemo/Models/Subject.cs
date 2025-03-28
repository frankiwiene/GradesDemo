using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace GradesDemo.Models
{
    public class Subject
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100)]
        public string Name { get; set; }
        //Relacion 1 a muchos "un subject puede tener muchas actividades". 
        public virtual ICollection<Actividad> Activities { get; set; }


    }
}

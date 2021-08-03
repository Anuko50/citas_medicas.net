using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace citas_medicas.net.Models
{
    [Table("Diagnostico")]
    public class Diagnostico
    {
        [Key]
        public long Id { get; set; }
        public string ValoracionEspecialista { get; set; }
        public string Enfermedad { get; set; }
        public long IdCita { get; set; }
    }
}

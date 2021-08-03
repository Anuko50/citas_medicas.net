using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace citas_medicas.net.Models
{
    [Table("Cita")]
    public class Cita
    {
        [Key]
        public long Id { get; set; }
        public DateTime FechaHora { get; set; }
        public int atribute11 { get; set; }
        public string MotivoCita { get; set; }

        public Diagnostico Diagnostico { get; set; }
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }
    }
}

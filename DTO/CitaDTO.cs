using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citas_medicas.net.DTO
{
    public class CitaDTO
    {
        public long Id { get; set; }
        //la fecha y la hora me interesa mandarla como un string
        //me ahorro jaleo
        //public DateTime FechaHora { get; set; }
        public string FechaHora { get; set; }
        //Este atributo? no sirve para nada, pero está en la especificación
        //public int atribute11 { get; set; }
        public string MotivoCita { get; set; }

        //Sus Id's.
        public long Diagnostico { get; set; }
        public long Medico { get; set; }
        public long Paciente { get; set; }
    }
}

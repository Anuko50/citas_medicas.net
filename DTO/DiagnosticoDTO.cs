using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citas_medicas.net.DTO
{
    public class DiagnosticoDTO
    {
        public long Id { get; set; }
        public string ValoracionEspecialista { get; set; }
        public string Enfermedad { get; set; }
        
        public long IdCita { get; set; }
    }
}

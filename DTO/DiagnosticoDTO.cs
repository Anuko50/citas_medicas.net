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

        /*
         * ¿Por qué no pongo la ID de la cita a la que va asociada?
         * Porque Cita ya contiene el ID del diagnostico al que va asociado, y al ser unidireccional, no me 
         * hace falta más.
         */    
   }
}

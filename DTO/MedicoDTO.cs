using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citas_medicas.net.DTO
{
    public class MedicoDTO
    {
        //de nuevo, como paciente
        public long Id { get; set; }
        public string User { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Clave { get; set; }
        public string NumColegiado { get; set; }

        //de nuevo, una colección de id's
        public ICollection<long> Pacientes { get; set; }
    }
}

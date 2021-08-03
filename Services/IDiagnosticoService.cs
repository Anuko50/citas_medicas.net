using citas_medicas.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citas_medicas.net.Services
{
    interface IDiagnosticoService
    {
        public Diagnostico Create(Diagnostico d);
        public Diagnostico FindById(long id);
        public ICollection<Diagnostico> FindAll();
        public bool DeleteById(long id);
        /* no le añado una cita por logica secuencial:
         * voy al medico y primero pido una cita. Despues de esta cita? se crea un diagnostico.
         * */
    }
}

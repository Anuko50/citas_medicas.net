using citas_medicas.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citas_medicas.net.Services
{
    public interface ICitaService
    {
        public Cita Create(Cita c, long idMedico, long idPaciente);
        public Cita FindById(long id);
        public ICollection<Cita> FindAll();
        public bool DeleteById(long id);

        //¿Por qué no? porque es obligatorio en la creación
        //public bool AddMedico(long id, long idMedico);
        //public bool AddPaciente(long id, long idPaciente);

        //sin embargo, como he puesto en IDiagnosticoService, por logica secuencial, esto debe ser así.
        public bool AddDiagnostico(long id, long idDiagnostico);
    }
}

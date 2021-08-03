using citas_medicas.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citas_medicas.net.Services
{
    public interface IPacienteService
    {
        public Paciente Create(Paciente p);
        public Paciente FindById(long id);
        public ICollection<Paciente> FindAll();
        public bool DeleteById(long id);

        /*
         * Un paciente tiene a un medico asociado, never forget
         * Y tanto el medico como el paciente van a tener que poder loggearse en la pag
         */
        public bool AddMedico(long id, long idMedico);
        public bool Login(string user, string clave);
    }
}

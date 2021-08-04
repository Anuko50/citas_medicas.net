using citas_medicas.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citas_medicas.net.Services
{
    public interface IMedicoService
    {
        public Medico Create(Medico m);
        public Medico FindById(long id);
        public ICollection<Medico> FindAll();
        public bool DeleteById(long id);
        public string AddPaciente(long id, long idPaciente);
        public bool Login(string user, string clave);
    }
}

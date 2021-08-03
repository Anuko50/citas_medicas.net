using citas_medicas.net.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citas_medicas.net.Services
{
    public class MedicoService : IMedicoService
    {

        private Context context;

        public MedicoService(Context c) 
        {
            context = c;
        }


        public Medico Create(Medico m)
        {
            if (m is not null) {
                context.Medico.Add(m);
                context.SaveChanges();
                return m;
            }
            return null;
        }

        public Medico FindById(long id) => context.Medico.Find(id);


        public bool AddPaciente(long id, long idPaciente)
        {
            Medico m = FindById(id);
            Paciente p = context.Paciente.Find(id);

            if ((m is not null) && (p is not null)) {
                if (!p.Medicos.Contains(m)) 
                    p.Medicos.Add(m);

                if (!m.Pacientes.Contains(p))
                    m.Pacientes.Add(p);

                return true;
            }

            return false;
        }


        public bool DeleteById(long id)
        {
            Medico m = FindById(id);
            if (m is not null) {
                context.Medico.Remove(m);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public ICollection<Medico> FindAll() => context.Medico.Include(m => m.Pacientes).ToList();


        public bool Login(string user, string clave)
        {
            Medico m = context.Medico.Where(m => m.User == user && m.Clave == clave).First();
            if (m is not null)
                return true;
            return false;
        }
    }
}

using citas_medicas.net.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citas_medicas.net.Services
{
    public class PacienteService : IPacienteService
    {
        private Context context;
        public PacienteService(Context c)
        {
            context = c;
        }

        public Paciente Create(Paciente p)
        {
            if (p is not null) {
                context.Paciente.Add(p);
                context.SaveChanges();
                return p;
            }
            return null;
        }

        public Paciente FindById(long id) => context.Paciente.Find(id);

        public bool AddMedico(long id, long idMedico)
        {
            Paciente p = FindById(id);
            Medico m = context.Medico.Find(idMedico);

            if ((m is not null) && (p is not null))
            {
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
            Paciente p = FindById(id);
            if (p is not null) {
                context.Paciente.Remove(p);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public ICollection<Paciente> FindAll() => context.Paciente.Include(p => p.Medicos).ToList();


        public bool Login(string user, string clave) {
            Paciente p = context.Paciente.Where(p => p.User == user && p.Clave == clave).First();
            if (p is not null)
                return true;
            return false;
        }
    }
}

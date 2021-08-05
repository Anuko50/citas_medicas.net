using citas_medicas.net.Models;
using citas_medicas.net.Repository;
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
        private IRepositorio<Paciente> repo;
        private IRepositorio<Medico> repoMedico;

        public PacienteService(Context c)
        {
            context = c;
            repo = new RepositorioPaciente<Paciente>(context);
            repoMedico = new RepositorioMedico<Medico>(context);
        }

        public Paciente Create(Paciente p)
        {
            if (p is not null) {
                repo.Agregar(p);
                return p;
            }
            return null;
        }

        public Paciente FindById(long id) => repo.ObtenerPorId(id);//context.Paciente.Find(id);


        //TODO:
        public string AddMedico(long id, long idMedico)
        {
            Medico m = repoMedico.ObtenerPorId(idMedico);
            Paciente p = FindById(id);

            if ((m is not null) && (p is not null))
            {
                if ((!p.Medicos.Contains(m)) && (!m.Pacientes.Contains(p)))
                {
                    p.Medicos.Add(m);
                    m.Pacientes.Add(p);
                    repo.Actualizar(p);
                    repoMedico.Actualizar(m);

                    return "se ha añadido el medico correctamente.";
                }

                return "este medico o este paciente ya se tienen añadidos el uno al otro en su lista";
            }

            if ((m is null) && (p is null))
                return "ni el paciente ni el medico existen.";
            if (m is null)
                return "el medico no existe";
            if (p is null)
                return "el paciente no existe";
            return "no entiendo nada";
        }

        public bool DeleteById(long id) => repo.Eliminar(id);
      

        public IEnumerable<Paciente> FindAll() => context.Paciente.Include(p => p.Medicos).ToList();

        //TODO:
        public bool Login(string user, string clave) {
            Paciente p = context.Paciente.Where(p => p.User == user && p.Clave == clave).First();
            if (p is not null)
                return true;
            return false;
        }
    }
}

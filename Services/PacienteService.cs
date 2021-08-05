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
            Paciente p = FindById(id);
            Medico m = repoMedico.ObtenerPorId(idMedico);
            int cont = 0;

            if ((m is not null) && (p is not null))
            {
                if (!p.Medicos.Contains(m)) {
                    p.Medicos.Add(m);
                    repo.Actualizar(p);
                    cont += 2;
                }

                if (p.Medicos.Contains(m))
                    return "El medico ya esta en la lista de medicos del paciente";

                if (!m.Pacientes.Contains(p)) {
                    m.Pacientes.Add(p);
                    repoMedico.Actualizar(m);
                    cont += 1;
                }

                if (m.Pacientes.Contains(p))
                    return "El paciente ya está en la lista de pacientes del medico.";

                if (cont == 1)
                {
                    return "Solo se ha añadido el medico al paciente.";
                }
                else if (cont == 2) 
                {
                    return "Solo se ha añadido el paciente al medico";
                }else if (cont == 3)
                {
                    return "Se ha añadido correctamente.";
                }
                //context.SaveChanges();
                return "Ya se tienen contenidos ambos.";
            }
            return "O el medico o el paciente no existe.";
        }

        public bool DeleteById(long id) => repo.Eliminar(id);
      

        public IEnumerable<Paciente> FindAll() => repo.ObtenerAll();

        //TODO:
        public bool Login(string user, string clave) {
            Paciente p = context.Paciente.Where(p => p.User == user && p.Clave == clave).First();
            if (p is not null)
                return true;
            return false;
        }
    }
}

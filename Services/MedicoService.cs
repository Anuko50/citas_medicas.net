using citas_medicas.net.Models;
using citas_medicas.net.Repository;
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
        private IRepositorio<Medico> repo;
        private IRepositorio<Paciente> repoPaciente;

        public MedicoService(Context c) 
        {
            context = c;
            repo = new RepositorioMedico<Medico>(context);
            repoPaciente = new RepositorioPaciente<Paciente>(context);

        }


        public Medico Create(Medico m)
        {
            if (m is not null) {
                repo.Agregar(m);
                return m;
            }
            return null;
        }

        public Medico FindById(long id) => repo.ObtenerPorId(id);


        public string AddPaciente(long id, long idPaciente)
        {
            Medico m = FindById(id);
            Paciente p = repoPaciente.ObtenerPorId(idPaciente);

            if ((m is not null) && (p is not null)) {
                if ((!p.Medicos.Contains(m)) && (!m.Pacientes.Contains(p))) {
                    p.Medicos.Add(m);
                    repoPaciente.Actualizar(p);
                    m.Pacientes.Add(p);
                    repo.Actualizar(m);

                    return "se ha añadido el paciente correctamente.";
                }

                return "este medico o este paciente ya se tienen añadidos el uno al otro en su lista";
            }

            #region comprobaciones
            if ((m is null) && (p is null))
                return "ni el paciente ni el medico existen.";
            if (m is null)
                return "el medico no existe";
            if (p is null)
                return "el paciente no existe";
            return "no entiendo nada";
            #endregion

        }


        public bool DeleteById(long id) => repo.Eliminar(id);
        

        public ICollection<Medico> FindAll() => context.Medico.Include(m => m.Pacientes).ToList();


        //TODO:
        public bool Login(string user, string clave)
        {
            Medico m = context.Medico.Where(m => m.User == user && m.Clave == clave).First();
            if (m is not null)
                return true;
            return false;
        }
    }
}

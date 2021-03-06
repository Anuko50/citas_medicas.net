using citas_medicas.net.Models;
using citas_medicas.net.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citas_medicas.net.Services
{
    public class CitaService:ICitaService
    {
        private Context context;
        private RepositorioCita<Cita> repo;

        public CitaService(Context c) {
            context = c;
            repo = new RepositorioCita<Cita>(context);
        }


        public Cita Create(Cita c, long idMedico, long idPaciente)
        {
            IRepositorio<Medico> repoMedico = new RepositorioMedico<Medico>(context);
            IRepositorio<Paciente> repoPaciente = new RepositorioPaciente<Paciente>(context);
           
            if (c is not null) {
                c.Medico = repoMedico.ObtenerPorId(idMedico);
                c.Paciente = repoPaciente.ObtenerPorId(idPaciente);
                //c.Diagnostico = repoDiagnostico.ObtenerPorId(idDiagnostico);
                repo.Agregar(c);
                return c;
            }
            return null;
        }

        public Cita FindById(long id) => repo.FindById(id);

        public bool DeleteById(long id) {
            IRepositorio<Diagnostico> repoDiagnostico = new RepositorioDiagnostico<Diagnostico>(context);
            Cita c = this.FindById(id);
            repoDiagnostico.Eliminar(c.Diagnostico.Id);
           return  repo.Eliminar(id);

        } 

        public ICollection<Cita> FindAll() => repo.FindAll();

        public bool AddDiagnostico(long id, long idDiagnostico)
        {
            IRepositorio<Diagnostico> repoDiagnostico = new RepositorioDiagnostico<Diagnostico>(context);

            Diagnostico d = repoDiagnostico.ObtenerPorId(idDiagnostico);
            Cita c = FindById(id);

            if ((d is not null) && (c is not null)) { 
                if(c.Diagnostico != null){
                    //la cita ya tiene un diagnostico asociado.
                    return false;
                }
                if (d.IdCita != 0.0) {
                    //el diagnostico tiene una cita asociada.
                    return false;
                }
                d.IdCita = c.Id;
                c.Diagnostico = d;
                repo.Actualizar(c);
                repoDiagnostico.Actualizar(d);
                return true;
            }
            return false;
        }

        public void Update(long id, DateTime fecha, string motivoCita) {
            Cita citaVieja = repo.ObtenerPorId(id);
            citaVieja.FechaHora = fecha;
            citaVieja.MotivoCita =motivoCita;
            repo.Actualizar(citaVieja);
        }

    }
}

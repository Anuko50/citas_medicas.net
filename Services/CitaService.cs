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

        public CitaService(Context c) {
            context = c;
        }


        /*
         * ARREGLAR
         */
        public Cita Create(Cita c, long idMedico, long idPaciente)
        {
            if (c is not null) {
                c.Medico = context.Medico.Find(idMedico);
                c.Paciente = context.Paciente.Find(idPaciente);
                context.Cita.Add(c);
                context.SaveChanges();
                return c;
            }
            return null;
        }

        public Cita FindById(long id) => context.Cita.Find(id);

        public bool DeleteById(long id)
        {
            Cita c = FindById(id);
            if (c is not null) {
                context.Cita.Remove(c);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public ICollection<Cita> FindAll() => context.Cita.Include(c => c.Medico).Include(c => c.Paciente).Include(c => c.Diagnostico).ToList();


        public bool AddDiagnostico(long id, long idDiagnostico)
        {
            Diagnostico d = context.Diagnostico.Find(idDiagnostico);
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
                context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}

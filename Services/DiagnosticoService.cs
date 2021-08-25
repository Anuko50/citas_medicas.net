using citas_medicas.net.Models;
using citas_medicas.net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citas_medicas.net.Services
{
    public class DiagnosticoService:IDiagnosticoService
    {
        private Context context;
        private RepositorioDiagnostico<Diagnostico> repo;
        private RepositorioCita<Cita> repoCitas;

        public DiagnosticoService(Context c) 
        {
            context = c;
            repo = new RepositorioDiagnostico<Diagnostico>(context);
            repoCitas = new RepositorioCita<Cita>(context);
        }

        public Diagnostico Create(Diagnostico d)
        {
            if (d is not null) {
                Cita citaAsociada = repoCitas.FindById(d.IdCita);
                if ( citaAsociada is not null) {
                    if (citaAsociada.Diagnostico is null) {
                        repo.Agregar(d);
                        citaAsociada.Diagnostico = d;
                        repoCitas.Actualizar(citaAsociada);
                        return d;
                    }
                }
            }
            return null;
        }

        public Diagnostico FindById(long id) =>repo.ObtenerPorId(id);

        public bool DeleteById(long id) => repo.Eliminar(id);

        public ICollection<Diagnostico> FindAll() => repo.FindAll();

    }
}

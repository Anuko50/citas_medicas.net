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
        private IRepositorio<Diagnostico> repo;

        public DiagnosticoService(Context c) 
        {
            context = c;
            repo = new RepositorioDiagnostico<Diagnostico>(context);  
        }

        public Diagnostico Create(Diagnostico d)
        {
            if (d is not null) {
                repo.Agregar(d);
                return d;
            }
            return null;
        }

        public Diagnostico FindById(long id) =>repo.ObtenerPorId(id);

        public bool DeleteById(long id) => repo.Eliminar(id);

        public ICollection<Diagnostico> FindAll() => context.Diagnostico.ToList();

    }
}

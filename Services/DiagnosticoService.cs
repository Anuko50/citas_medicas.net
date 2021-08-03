using citas_medicas.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citas_medicas.net.Services
{
    public class DiagnosticoService:IDiagnosticoService
    {
        private Context context;

        public DiagnosticoService(Context c) {
            context = c;
        }

        public Diagnostico Create(Diagnostico d)
        {
            if (d is not null) {
                context.Diagnostico.Add(d);
                context.SaveChanges();
                return d;
            }
            return null;
        }

        public Diagnostico FindById(long id) => context.Diagnostico.Find(id);

        public bool DeleteById(long id) {
            Diagnostico d = FindById(id);
            if (d is not null) {
                context.Diagnostico.Remove(d);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public ICollection<Diagnostico> FindAll() => context.Diagnostico.ToList();

    }
}

using citas_medicas.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citas_medicas.net.Repository
{
    public class RepositorioDiagnostico<T> : IRepositorio<T> where T : Diagnostico
    {
        private Context context;

        public RepositorioDiagnostico(Context c)
        {
            context = c;
        }

        public void Actualizar(T e)
        {
            context.Set<T>().Update(e);
            context.SaveChanges();
        }

        public void Agregar(T e)
        {
            context.Set<T>().Add(e);
            context.SaveChanges();
        }

        public bool Eliminar(long id)
        {
            T e = ObtenerPorId(id);
            if (e is not null)
            {
                context.Set<T>().Remove(e);
                context.SaveChanges();
                return true;
            }
            return false;

        }
        public T ObtenerPorId(long id) => context.Set<T>().FirstOrDefault(x => x.Id == id);

        public ICollection<Diagnostico> FindAll() => context.Diagnostico.ToList();

    }
}

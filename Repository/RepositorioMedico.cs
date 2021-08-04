using citas_medicas.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citas_medicas.net.Repository
{
    public class RepositorioMedico<T> : IRepositorio<T> where T : Medico
    {
        private Context context;

        public RepositorioMedico(Context c)
        {
            context = c;
        }

        public void Actualizar(T e)
        {
            context.Set<T>().Update(e);
            //Es que literal que solo salvo los cambios xd
            context.SaveChanges();
        }

        public void Agregar(T e)
        {
            context.Set<T>().Add(e);
            context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            T e = ObtenerPorId(id);
            context.Set<T>().Remove(e);
            context.SaveChanges();
        }

        public IEnumerable<T> ObtenerAll()
        {
            return context.Set<T>().ToList();
        }

        public T ObtenerPorId(int id) => context.Set<T>().FirstOrDefault(x => x.Id == id);
    }
}

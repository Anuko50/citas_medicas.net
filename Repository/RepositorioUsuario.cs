using citas_medicas.net.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citas_medicas.net.Repository
{
    public class RepositorioUsuario<T> : IRepositorio<T> where T : Usuario, new()
    {
        private Context context;

        public RepositorioUsuario(Context c) 
        {
            context = c;
        }

        public void Actualizar(T e)
        {
            context.Usuario.Update(e);
            //Es que literal que solo salvo los cambios xd
           context.SaveChanges();
        }

        public void Agregar(T e)
        {
            context.Usuario.Add(e);
            context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            T e = ObtenerPorId(id);
            context.Usuario.Remove(e);
            context.SaveChanges();
        }

        public T ObtenerPorId(int id) => context.Set<T>().FirstOrDefault(x => x.Id == id);
      
    }
}

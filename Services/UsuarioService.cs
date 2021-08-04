using citas_medicas.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citas_medicas.net.Services
{
    public class UsuarioService : IUsuarioService
    {
        private Context context;

        //constructor; necesito el contexto de los datos.
        public UsuarioService(Context c)
        {
            context = c;
        }

        //función lambda; cojo a los usuarios directamente buscándolos  por su ID único.
        public Usuario FindById(long id) => context.Usuario.Find(id);

        //si el usuario no es null, lo añado y devuelvo este;
        //si es null, devuelvo null sin hacer nada
        public Usuario Create(Usuario u)
        {
            if (u is not null) {
                context.Usuario.Add(u);
                context.SaveChanges();
                return u;
            }
            return null;
        }

        //si el usuario existe, lo borro y retorno true
        //si no existe, retorno false
        public bool DeleteById(long id)
        {
            Usuario u = FindById(id);
            if (u is not null) {
                context.Usuario.Remove(u);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        //Hago una función Lambda; cojo todos los usuarios que haya en el contexto de los datos.
        public ICollection<Usuario> FindAll() => context.Usuario.ToList();

        public void Update(long id, Usuario u)
        {
            //no modifica ni el id ni el nombre de usuario (user)
            u.Id = id;
            context.Usuario.Update(u);
            context.SaveChanges();
        }

        //solo comprobar si existe.
        public Usuario login(string username, string clave)
        {
            Usuario u = context.Usuario.Where(u => u.User == username && u.Clave == clave).First();
            if (u is not null)
                return u;
            return null;
        }
    }
}

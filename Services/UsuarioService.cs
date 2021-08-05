﻿using citas_medicas.net.Models;
using citas_medicas.net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citas_medicas.net.Services
{
    public class UsuarioService : IUsuarioService
    {
        private Context context;
        private IRepositorio<Usuario> repo;

        //constructor; necesito el contexto de los datos.
        public UsuarioService(Context c)
        {
            context = c;
            repo = new RepositorioUsuario<Usuario>(context);
        }

        //función lambda; cojo a los usuarios directamente buscándolos  por su ID único.
        public Usuario FindById(long id) => repo.ObtenerPorId(id);  //context.Usuario.Find(id);

        //si el usuario no es null, lo añado y devuelvo este;
        //si es null, devuelvo null sin hacer nada
        public Usuario Create(Usuario u)
        {
            if (u is not null) {
                repo.Agregar(u);
                return u;
            }
            return null;
        }

        //si el usuario existe, lo borro y retorno true
        //si no existe, retorno false
        public bool DeleteById(long id) => repo.Eliminar(id);
        

        //Hago una función Lambda; cojo todos los usuarios que haya en el contexto de los datos.
        public IEnumerable<Usuario> FindAll() => context.Usuario.ToList();

        public void Update( Usuario u)
        {
            repo.Actualizar( u);
            //no modifica ni el id ni el nombre de usuario (user)
            /*
            u.Id = id;
            context.Usuario.Update(u);
            context.SaveChanges();
            */
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

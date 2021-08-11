using citas_medicas.net.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citas_medicas.net.Repository
{
    public class RepositorioPaciente<T> : IRepositorio<T> where T : Paciente
    {
        private Context context;

        public RepositorioPaciente(Context c)
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
        public IEnumerable<Paciente> findAll() => context.Paciente.Include(p => p.Medicos).ToList();
        public T ObtenerPorId(long id) => context.Set<T>().FirstOrDefault(x => x.Id == id);
        public Paciente FindById(long id) => context.Paciente.Include(p => p.Medicos).FirstOrDefault(p => p.Id == id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citas_medicas.net.Repository
{
    public interface IRepositorio<T>
    {
        /*
         * Funciones CRUD que van a compartir el que use esta interfaz.
         */
        public void Agregar(T entidad);
        public bool Eliminar(long id);
        public void Actualizar(T entidad);
        public T ObtenerPorId(long id);
        public IEnumerable<T> ObtenerAll();

    }
}

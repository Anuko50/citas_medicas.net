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
        void Agregar(T entidad);
        void Eliminar(int id);
        void Actualizar(T entidad);
        T ObtenerPorId(int id);
    }
}

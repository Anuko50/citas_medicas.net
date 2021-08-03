using citas_medicas.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citas_medicas.net.Services
{
    /*
     * Creo una interfaz con los métodos que voy a aplicar para
     * desligar la implementación, por convenio, y para tratar la inyección de dependencias.
     */
    public interface IUsuarioService
    {
        //METODOS CRUD: Create; Read; Update; Delete
        //Se updatea en memoria, osea que no es necesario.
        //Create:
        public Usuario Create(Usuario user);
        //Read:
        public Usuario FindById(long id);
        public ICollection<Usuario> FindAll();
        //Delete:
        public bool DeleteById(long id);
    }
}

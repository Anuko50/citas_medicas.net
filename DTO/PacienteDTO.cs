using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citas_medicas.net.DTO
{
    public class PacienteDTO
    {
        /*
         * ¿De aquí qué me interesa? Pos todo los atributos de usuario (porque un paciente es un usuario)
         * y los suyos propios. Pa tenerlo todo a manica.
         */
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Nss { get; set; }
        public string NumTarjeta { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        // OJO!! me cojo una colección de ID's de medicos, nada de objetos de clase. 
        public ICollection<long> Medicos { get; set; }
    }
}

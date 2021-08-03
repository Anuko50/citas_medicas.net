using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citas_medicas.net.DTO
{
    /*
     * Un DTO es un "Data Transfer Object", básicamente este tipo de clases representa
     * qué voy a enviar por la red. 
     * De un vistazo voy a crear DTO's de todos las clases del modelo y voy a crear un DTO
     * para la relación paciente-medico. No pongo cita-diagnostico porque es innecesario; 
     * a ambos les asocio el id del otro y listo.
     */
    public class UsuarioDTO
    {
        //En el caso de usuario me interesa que se pueda enviar todo; la clase es sencilla no tiene referencias
        //a otros objetos y todos sus atributos van a ser útiles en la app.
        public long Id { get; set; }
        public string User { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Clave { get; set; }

        //User y clave, a pesar de que lo voy a meter en el Login, me interesa a la hora de crear un user,
        //cambiar su clave, etc.
    }
}

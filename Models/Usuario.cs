using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace citas_medicas.net.Models
{
    public class Usuario
    {
        [Key]
        public long Id { get; set; }
        public string User { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Clave { get; set; }
    }
}


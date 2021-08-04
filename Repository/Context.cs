using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using citas_medicas.net.DTO;

namespace citas_medicas.net.Models
{
    public class Context:DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        #region tablas
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Cita> Cita { get; set; }
        public DbSet<Diagnostico> Diagnostico { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasAlternateKey(u => u.User)
                .HasName("User");
        }


        public DbSet<citas_medicas.net.DTO.CitaDTO> CitaDTO { get; set; }
    }
}

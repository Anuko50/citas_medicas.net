﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using citas_medicas.net.Models;

namespace citas_medicas.net.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210803060836_initialCreate")]
    partial class initialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MedicoPaciente", b =>
                {
                    b.Property<long>("MedicosId")
                        .HasColumnType("bigint");

                    b.Property<long>("PacientesId")
                        .HasColumnType("bigint");

                    b.HasKey("MedicosId", "PacientesId");

                    b.HasIndex("PacientesId");

                    b.ToTable("MedicoPaciente");
                });

            modelBuilder.Entity("citas_medicas.net.Models.Cita", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("DiagnosticoId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<long?>("MedicoId")
                        .HasColumnType("bigint");

                    b.Property<string>("MotivoCita")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PacienteId")
                        .HasColumnType("bigint");

                    b.Property<int>("atribute11")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DiagnosticoId");

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Cita");
                });

            modelBuilder.Entity("citas_medicas.net.Models.Diagnostico", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Enfermedad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("IdCita")
                        .HasColumnType("bigint");

                    b.Property<string>("ValoracionEspecialista")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Diagnostico");
                });

            modelBuilder.Entity("citas_medicas.net.Models.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Clave")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasAlternateKey("User")
                        .HasName("User");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("citas_medicas.net.Models.Medico", b =>
                {
                    b.HasBaseType("citas_medicas.net.Models.Usuario");

                    b.Property<string>("NumColegiado")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Medico");
                });

            modelBuilder.Entity("citas_medicas.net.Models.Paciente", b =>
                {
                    b.HasBaseType("citas_medicas.net.Models.Usuario");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nss")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumTarjeta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("MedicoPaciente", b =>
                {
                    b.HasOne("citas_medicas.net.Models.Medico", null)
                        .WithMany()
                        .HasForeignKey("MedicosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("citas_medicas.net.Models.Paciente", null)
                        .WithMany()
                        .HasForeignKey("PacientesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("citas_medicas.net.Models.Cita", b =>
                {
                    b.HasOne("citas_medicas.net.Models.Diagnostico", "Diagnostico")
                        .WithMany()
                        .HasForeignKey("DiagnosticoId");

                    b.HasOne("citas_medicas.net.Models.Medico", "Medico")
                        .WithMany()
                        .HasForeignKey("MedicoId");

                    b.HasOne("citas_medicas.net.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId");

                    b.Navigation("Diagnostico");

                    b.Navigation("Medico");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("citas_medicas.net.Models.Medico", b =>
                {
                    b.HasOne("citas_medicas.net.Models.Usuario", null)
                        .WithOne()
                        .HasForeignKey("citas_medicas.net.Models.Medico", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("citas_medicas.net.Models.Paciente", b =>
                {
                    b.HasOne("citas_medicas.net.Models.Usuario", null)
                        .WithOne()
                        .HasForeignKey("citas_medicas.net.Models.Paciente", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

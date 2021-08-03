using AutoMapper;
using citas_medicas.net.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citas_medicas.net.Models
{
    public class Mappeando : Profile
    {
        /*
         * Clase que necesito porque asocio los DTO por ID's, no por objetos completos.
         */

        public Mappeando()
        {
            //mappeo del derecho:

            //primero los directos:
            CreateMap<Usuario, UsuarioDTO>();

            CreateMap<Diagnostico, DiagnosticoDTO>();

            //luego los que tienen colecciones:
            CreateMap<Paciente, PacienteDTO>()
                .ForMember(dto => dto.Medicos, o => o.MapFrom(pac => pac.Medicos.Select(m => m.Id).ToList()));

            CreateMap<Medico, MedicoDTO>()
                .ForMember(dto => dto.Pacientes, o => o.MapFrom(med => med.Pacientes.Select(p => p.Id).ToList()));

            CreateMap<Cita, CitaDTO>()
                .ForMember(dto => dto.FechaHora, o => o.MapFrom(cita => cita.FechaHora.ToString("yyyy-MM-dd HH:mm:ss")))
                .ForMember(dto => dto.Medico, o => o.MapFrom(cita => cita.Medico.Id))
                .ForMember(dto => dto.Paciente, o => o.MapFrom(cita => cita.Paciente.Id))
                .ForMember(dto => dto.Diagnostico, o => o.MapFrom(cita => cita.Diagnostico.Id));

            

            //mappeo del revés:

            //Primero los directos:
            CreateMap<UsuarioDTO, Usuario>();

            CreateMap<DiagnosticoDTO, Diagnostico>();

            //los que tienen colecciones:
            CreateMap<PacienteDTO, Paciente>()
                .ForMember(pac => pac.Medicos, o => o.MapFrom(dto => new List<Medico>()));

            CreateMap<MedicoDTO, Medico>()
                .ForMember(med => med.Pacientes, o => o.MapFrom(dto => new List<Paciente>()));

            CreateMap<CitaDTO, Cita>()
                .ForMember(cita => cita.FechaHora, o => o.MapFrom(dto => DateTime.ParseExact(dto.FechaHora, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)))
                .ForMember(cita => cita.Medico, o => o.Ignore())
                .ForMember(cita => cita.Paciente, o => o.Ignore())
                .ForMember(cita => cita.Diagnostico, o => o.Ignore());


           
        }
    }
}

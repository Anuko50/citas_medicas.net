using AutoMapper;
using citas_medicas.net.DTO;
using citas_medicas.net.Models;
using citas_medicas.net.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace citas_medicas.net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        public IMapper mapper;
        public IDiagnosticoService DService;
        public ICitaService CService;

        public CitaController(IMapper im, IDiagnosticoService id, ICitaService ic)
        {
            mapper = im;
            DService = id;
            CService = ic;
        }

        // GET: api/<CitaController>
        [HttpGet]
        public IEnumerable<CitaDTO> Get()
        {
            ICollection<CitaDTO> citas = new List<CitaDTO>();
            foreach (Cita c in CService.FindAll())
            {
                CitaDTO dto = mapper.Map<CitaDTO>(c);
                citas.Add(dto);
            }
            return citas;
        }

        // GET api/<CitaController>/5
        [HttpGet("{id}")]
        public CitaDTO Get(int id)
        {
            Cita c = CService.FindById(id);
            CitaDTO dto = mapper.Map<CitaDTO>(c);
            return dto;
        }

        // POST api/<CitaController>
        [HttpPost]
        public string Post(CitaDTO dto, long idMedico, long idPaciente)
        {
            Cita c = mapper.Map<Cita>(dto);
            Cita result = CService.Create(c, idMedico, idPaciente);
            if (result is not null)
                return "La cita se ha creado correctamente";
            return "La cita no ha sido creada";
        }

        // PUT api/<CitaController>/5
        [HttpPut("{id}")]
        public string Put(int idCita, int idDiagnostico)
        {
            //put diagnostico
            if (CService.AddDiagnostico(idCita, idDiagnostico))
                return "Se ha actualizado la cita y el diagnostico.";
            return "Este diagnostico ya tiene cita asociada, esta cita tiene diagnostico asociado o alguna de las id's es incorrecta.";
        }


        [HttpPut]
        public string Put(CitaDTO dto)
        {
            //SOLO ACTUALIZO LOS ATRIBUTOS BASICOS.
            Cita c = mapper.Map<Cita>(dto);
            //DateTime fechaMapped = DateTime.ParseExact(fecha, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            CService.Update(c.Id, c.FechaHora, c.MotivoCita);
            return ("La fecha introducida ha sido: "+ c.FechaHora + " y el motivo es: "+ c.MotivoCita);
        }

        // DELETE api/<CitaController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            if (CService.DeleteById(id))
                return "se ha eliminado la cita correctamente";
            return "no se ha podido eliminar";

        }
    }
}

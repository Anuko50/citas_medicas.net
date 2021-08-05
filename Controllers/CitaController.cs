using AutoMapper;
using citas_medicas.net.DTO;
using citas_medicas.net.Models;
using citas_medicas.net.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public Cita Get(int id)
        {
            Cita c = CService.FindById(id);
            CitaDTO dto = mapper.Map<CitaDTO>(c);
            return c;
        }

        // POST api/<CitaController>
        [HttpPost]
        public void Post(CitaDTO dto, long idMedico, long idPaciente)
        {
            Cita c = mapper.Map<Cita>(dto);
            CService.Create(c, idMedico, idPaciente);
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

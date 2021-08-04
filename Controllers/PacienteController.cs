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
    public class PacienteController : ControllerBase
    {
        public IMapper mapper;
        public IPacienteService PService;
        public IMedicoService MService;

        public PacienteController(IMapper im, IPacienteService ip, IMedicoService ime)
        {
            mapper = im;
            PService = ip;
            MService = ime;
        }

        [Route("GetAll")]
        // GET: ALL api/<PacienteController>
        [HttpGet]
        public ICollection<PacienteDTO> Get()
        {
            ICollection<PacienteDTO> pacientes = new List<PacienteDTO>();
            foreach (Paciente p in PService.FindAll())
            {
                PacienteDTO dto = mapper.Map<PacienteDTO>(p);
                pacientes.Add(dto);
        }
            return pacientes;
        }

        // GET api/<PacienteController>/5
        [HttpGet("{id}")]
        public PacienteDTO Get(long id)
        {
            Paciente p = PService.FindById(id);
            if (p is not null)
            {
                PacienteDTO dto = mapper.Map<PacienteDTO>(p);
                return dto;
            }
            return null;
        }

        // POST api/<PacienteController>
        [HttpPost]
        public void Post([FromBody] PacienteDTO dto)
        {
            Paciente p = mapper.Map<Paciente>(dto);
            PService.Create(p);
        }

        // PUT api/<PacienteController>/5
        [HttpPut("{id}")]
        public string Put(long id, [FromBody] long idMedico)
        {
            if (PService.AddMedico(id, idMedico))
                return "El medico ha sido añadido.";
            return "Ha ocurrido un error al añadir al médico.";
        }

        // DELETE api/<PacienteController>/5
        [HttpDelete("{id}")]
        public string Delete(long id)
        {
            bool borrao = PService.DeleteById(id);
            if (borrao)
                return "El paciente ha sido eliminado con exito";
            return "oh no; el paciente que has intentado borrar no existía :/";
        }


        /*
         * NOTA: no voy a meter el Login cuando esta en usuario. Preguntar por esto. Lo tengo preparadito en los servicios,
         * pero lo veo inutil hacerlo tres veces. Creo que con el login de User basta.
         */
    }
}

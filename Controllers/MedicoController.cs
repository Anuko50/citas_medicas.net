using AutoMapper;
using citas_medicas.net.DTO;
using citas_medicas.net.Models;
using citas_medicas.net.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace citas_medicas.net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {

        public IMapper mapper;
        public IPacienteService PService;
        public IMedicoService MService;

        public MedicoController(IMapper im, IPacienteService ip, IMedicoService ime)
        {
            mapper = im;
            PService = ip;
            MService = ime;
        }

        // GET: api/<MedicoController>
        [HttpGet]
        public ICollection<MedicoDTO> Get()
        {
            ICollection<MedicoDTO> medicos = new List<MedicoDTO>();
            foreach (Medico m in MService.FindAll())
            {
                MedicoDTO dto = mapper.Map<MedicoDTO>(m);
                medicos.Add(dto);
            }
            return medicos;
        }

        // GET api/<MedicoController>/5
        [HttpGet("{id}")]
        public MedicoDTO Get(int id)
        {
            Medico m = MService.FindById(id);
            if (m is not null)
            {
                MedicoDTO dto = mapper.Map<MedicoDTO>(m);
                return dto;
            }
            return null;
        }

        // POST api/<MedicoController>
        [HttpPost]
        public void Post([FromBody] MedicoDTO dto)
        {
            Medico m = mapper.Map<Medico>(dto);
            MService.Create(m);
        }

        // PUT api/<PacienteController>/5
        [HttpPut("{id}")]
        public string Put(long id,  long idPaciente)
        {
            return MService.AddPaciente(id, idPaciente);
        }


        // DELETE api/<MedicoController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            bool borrao = MService.DeleteById(id);
            if (borrao)
                return "El medico ha sido eliminado con exito";
            return "oh no; el medico que has intentado borrar no existía :/";
        }
    }
}

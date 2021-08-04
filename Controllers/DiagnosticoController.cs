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
    public class DiagnosticoController : ControllerBase
    {
        public IMapper mapper;
        public IDiagnosticoService DService;

        public DiagnosticoController(IMapper im, IDiagnosticoService id)
        {
            mapper = im;
            DService = id;
        }

        // GET: api/<DiagnosticoController>
        [HttpGet]
        public IEnumerable<DiagnosticoDTO> Get()
        {
            ICollection<DiagnosticoDTO> diagnosticos = new List<DiagnosticoDTO>();
            foreach (Diagnostico d in DService.FindAll())
            {
                DiagnosticoDTO dto = mapper.Map<DiagnosticoDTO>(d);
                diagnosticos.Add(dto);
            }
            return diagnosticos;
        }

        // GET api/<DiagnosticoController>/5
        [HttpGet("{id}")]
        public DiagnosticoDTO Get(long id)
        {
            Diagnostico d = DService.FindById(id);
            if (d is not null)
            {
                DiagnosticoDTO dto = mapper.Map<DiagnosticoDTO>(d);
                return dto;
            }
            return null;
        }

        // POST api/<DiagnosticoController>
        [HttpPost]
        public void Post([FromBody] DiagnosticoDTO dto)
        {
            Diagnostico d = mapper.Map<Diagnostico>(dto);
            DService.Create(d);
        }

        /*
        // PUT api/<DiagnosticoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        */

        // DELETE api/<DiagnosticoController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            if (DService.DeleteById(id))
                return "Se ha eliminado correctamente";
            return "No se ha podido eliminar, lo más seguro es que no exista.";
        }
    }
}

using AutoMapper;
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

        public PacienteController(IMapper im, IPacienteService ip)
        {
            mapper = im;
            PService = ip;
        }

        [Route("GetAll")]
        // GET: ALL api/<PacienteController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PacienteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PacienteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PacienteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PacienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

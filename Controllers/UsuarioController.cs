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
    public class UsuarioController : ControllerBase
    {
        public IMapper mapper;
        public IUsuarioService UService;
        
        public UsuarioController(IMapper im, IUsuarioService iu)
        {
            mapper = im;
            UService = iu;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public void Post([FromBody] UsuarioDTO dto)
        {
            Usuario u = mapper.Map<Usuario>(dto);
            //acceder al servicio
            UService.Create(u);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

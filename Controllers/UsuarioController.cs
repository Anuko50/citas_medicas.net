using AutoMapper;
using citas_medicas.net.DTO;
using citas_medicas.net.Models;
using citas_medicas.net.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

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

        // GET ALL: api/<UsuarioController>
        [HttpGet]
        public ICollection<Usuario> Get()
        {
            return UService.FindAll();
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public Usuario Get(long id)
        {
            Usuario u = UService.FindById(id);
            if (u is not null)
            {
                return u;
            }
            return null;
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
        public void Put(long id, [FromBody] UsuarioDTO dto)
        {
            Usuario u = mapper.Map<Usuario>(dto);
            UService.Update(id, u);
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public string Delete(long id)
        {
            bool borrao = UService.DeleteById(id);
            if (borrao)
                return "El usuario ha sido eliminado con exito";
            return "oh no; el usuario que has intentado borrar no existía :/"; 
        }
    }
}

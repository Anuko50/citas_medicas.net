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

        [Route("GetAll")]
        // GET ALL: api/<UsuarioController>
        //funciona con swagger
        [HttpGet]
        public ICollection<UsuarioDTO> Get()
        {
            ICollection<UsuarioDTO> users = new List<UsuarioDTO>();
<<<<<<< HEAD
            foreach (Usuario u in UService.FindAll())
            {
=======
            foreach (Usuario u in UService.FindAll()) {
>>>>>>> aaef56da4a0c5ac699f0c8c2ec2aca282029f862
                UsuarioDTO dto = mapper.Map<UsuarioDTO>(u);
                users.Add(dto);
            }
            return users;
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public UsuarioDTO Get(long id)
        {
            Usuario u = UService.FindById(id);
            if (u is not null)
            {
                UsuarioDTO dto = mapper.Map<UsuarioDTO>(u);
                return dto;
            }
            return null;
        }

        /*
         * PARA LA VERSION FINAL: creo que esto no debería existir. En plan deberían crearse 
         * pacientes o medicos, no usuarios sin fuste. Creo que esto debería ser una clase abstracta.
         */
        // POST api/<UsuarioController>
        [HttpPost]
        public void Post([FromBody] UsuarioDTO dto)
        {
            Usuario u = mapper.Map<Usuario>(dto);
            //acceder al servicio
            UService.Create(u);
        }

        [Route("login")]
        [HttpPost]
        public UsuarioDTO Login([FromBody] string user, string clave) {
            Usuario u = UService.login(user, clave);
            if (u is not null) {
                UsuarioDTO dto = mapper.Map<UsuarioDTO>(u);
                return dto;
            }
            return null;
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

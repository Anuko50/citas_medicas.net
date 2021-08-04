using AutoMapper;
<<<<<<< HEAD
using citas_medicas.net.DTO;
using citas_medicas.net.Models;
=======
>>>>>>> aaef56da4a0c5ac699f0c8c2ec2aca282029f862
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
<<<<<<< HEAD
        public IMedicoService MService;

        public PacienteController(IMapper im, IPacienteService ip, IMedicoService ime)
        {
            mapper = im;
            PService = ip;
            MService = ime;
        }

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
=======

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
>>>>>>> aaef56da4a0c5ac699f0c8c2ec2aca282029f862
        }

        // GET api/<PacienteController>/5
        [HttpGet("{id}")]
<<<<<<< HEAD
        public PacienteDTO Get(long id)
        {
            Paciente p = PService.FindById(id);
            if (p is not null)
            {
                PacienteDTO dto = mapper.Map<PacienteDTO>(p);
                return dto;
            }
            return null;
=======
        public string Get(int id)
        {
            return "value";
>>>>>>> aaef56da4a0c5ac699f0c8c2ec2aca282029f862
        }

        // POST api/<PacienteController>
        [HttpPost]
<<<<<<< HEAD
        public void Post([FromBody] PacienteDTO dto)
        {
            Paciente p = mapper.Map<Paciente>(dto);
            PService.Create(p);
=======
        public void Post([FromBody] string value)
        {
>>>>>>> aaef56da4a0c5ac699f0c8c2ec2aca282029f862
        }

        // PUT api/<PacienteController>/5
        [HttpPut("{id}")]
<<<<<<< HEAD
        public string Put(long id, [FromBody] long idMedico)
        {
            if (PService.AddMedico(id, idMedico))
                return "El medico ha sido añadido.";
            return "Ha ocurrido un error al añadir al médico.";
=======
        public void Put(int id, [FromBody] string value)
        {
>>>>>>> aaef56da4a0c5ac699f0c8c2ec2aca282029f862
        }

        // DELETE api/<PacienteController>/5
        [HttpDelete("{id}")]
<<<<<<< HEAD
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
=======
        public void Delete(int id)
        {
        }
>>>>>>> aaef56da4a0c5ac699f0c8c2ec2aca282029f862
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myApi.Models;
using myData.DTO;
using myData.Repositories;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private Logger _log;
        private MapperConfiguration config;

        public PersonController()
        {
             _log = LogManager.GetCurrentClassLogger();
            config = new MapperConfiguration(cfg =>
           cfg.CreateMap<PersonDTO, PersonModel>()
       );
        }

        // GET: api/<PersonController>
        [HttpGet]
        public List<PersonModel> Get()
        {
            var personsDTO =  new PersonRepository(_log).GetPersons();

            var mapper = new Mapper(config);
            var person = mapper.Map<List<PersonModel>>(personsDTO);

            return person;
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public PersonModel Get(int id)
        {
            var personDTO  =  new PersonRepository(_log).GetPerson(id);

            var mapper = new Mapper(config);
            var person = mapper.Map<PersonModel>(personDTO);

            return person;

        }

        // POST api/<PersonController>
        [HttpPost]
        public void Post([FromBody] PersonModel value)
        {
            var mapper = new Mapper(config);
            var personDTO = mapper.Map<PersonDTO>(value);
            new PersonRepository(_log).SavePerson(personDTO);
        }

    }
}

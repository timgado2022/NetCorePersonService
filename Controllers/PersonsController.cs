using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
 
using PersonService.Data;
using PersonService.Dtos;
using PersonService.Models;
 

namespace PersonService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonRepo _repository;
        private readonly IMapper _mapper;


        public PersonsController(
            IPersonRepo repository, 
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        [HttpGet]
        public ActionResult<IEnumerable<PersonReadDto>> GetPersons()
        {
            Console.WriteLine("--> Getting Persons....");

            var PersonItem = _repository.GetAllPersons();

            return Ok(_mapper.Map<IEnumerable<PersonReadDto>>(PersonItem));
        }

        [HttpGet("{id}", Name = "GetPersonById")]
        public ActionResult<PersonReadDto> GetPersonById(int id)
        {
            var PersonItem = _repository.GetPersonById(id);
            if (PersonItem != null)
            {
                return Ok(_mapper.Map<PersonReadDto>(PersonItem));
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<PersonReadDto>> CreatePerson(PersonCreateDto PersonCreateDto)
        {
            var PersonModel = _mapper.Map<Person>(PersonCreateDto);
            _repository.CreatePerson(PersonModel);
            _repository.SaveChanges();

            var PersonReadDto = _mapper.Map<PersonReadDto>(PersonModel);



            return CreatedAtRoute(nameof(GetPersonById), new { Id = PersonReadDto.Id}, PersonReadDto);
        }
    }
}
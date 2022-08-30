using AutoMapper;
using PersonService.Dtos;
using PersonService.Models;

namespace PersonService.Profiles
{
    public class PersonsProfile : Profile
    {
        public PersonsProfile()
        {
            // Source -> Target
            CreateMap<Person, PersonReadDto>();
            CreateMap<PersonCreateDto, Person>();
        }
    }
}
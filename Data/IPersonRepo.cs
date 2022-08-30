using System.Collections.Generic;
using PersonService.Models;

namespace PersonService.Data
{
    public interface IPersonRepo
    {
        bool SaveChanges();

        IEnumerable<Person> GetAllPersons();
        Person GetPersonById(int id);
        void CreatePerson(Person plat);
    }
}
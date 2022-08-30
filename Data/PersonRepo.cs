using System;
using System.Collections.Generic;
using System.Linq;
using PersonService.Models;

namespace PersonService.Data
{
    public class PersonRepo : IPersonRepo
    {
        private readonly AppDbContext _context;

        public PersonRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreatePerson(Person plat)
        {
            if(plat == null)
            {
                throw new ArgumentNullException(nameof(plat));
            }

            _context.Persons.Add(plat);
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return _context.Persons.ToList();
        }

        public Person GetPersonById(int id)
        {
            return _context.Persons.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
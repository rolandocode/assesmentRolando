using myData.DTO;
using myData.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myData.Repositories
{
    public class PersonRepository : IPersonRepository
    {

        private Logger _log;

        public PersonRepository(Logger log)
        {
            _log = log;
        }


        private List<PersonDTO> PersonDataMemory = new List<PersonDTO>() { new PersonDTO { Id = 1,  Name = "Jonh Doe", Email ="doej@test.com"}, 
            new PersonDTO { Id = 2, Name = "Jane Doe", Email ="doeja@test,com"}, new PersonDTO { Id = 3, Name = "Tom Smith", Email ="tom.smith@test.com" } };

        public PersonDTO GetPerson(int id)
        {
            try
            {
                _log.Info("Calling Person by id");
                return PersonDataMemory.FirstOrDefault(f => f.Id == id);
            }
            catch (Exception ex)
            {
                _log.Error("Exception in GetPerson by id method: " + ex.Message);
                throw new Exception("An internal error has occur " + ex.Message);
            }
            
        }

        public List<PersonDTO> GetPersons()
        {
            try
            {
                _log.Info("Calling Person list");
                return this.PersonDataMemory;
            }
            catch (Exception ex)
            {
                _log.Error("Exception in GetPerson list method: " + ex.Message);
                throw new Exception("An internal error has occur " + ex.Message);
            }
        }

        public void SavePerson(PersonDTO personDTO)
        {
            try
            {
                _log.Info("Adding person to list");
                this.PersonDataMemory.Add(personDTO);
            }
            catch (Exception ex)
            {
                _log.Error("Exception in add person method: " + ex.Message);
                throw new Exception("An internal error has occur " + ex.Message);
            }
        }
    }
}

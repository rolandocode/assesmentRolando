using myData.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace myData.Interfaces
{
    interface IPersonRepository
    {
        List<PersonDTO> GetPersons();

        PersonDTO GetPerson(int id);

        void SavePerson(PersonDTO personDTO);
    }
}

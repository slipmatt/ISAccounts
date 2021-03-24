using ISAccounts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAccounts.Interfaces
{
    public interface IPersonsService
    {
        ResponseModel<List<PersonsModel>> CreatePerson(PersonsModel model);
        ResponseModel<List<PersonsModel>> UpdatePerson(PersonsModel model);
        ResponseModel<List<PersonsModel>> GetPersonByCode(int code);
        ResponseModel<List<PersonsModel>> GetAllPeople();
        ResponseModel<List<PersonsModel>> SearchPeople(PersonSearchModel searchModel);
        ResponseModel<List<PersonsModel>> DeletePerson(int code);
    }
}

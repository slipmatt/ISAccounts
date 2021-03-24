using ISAccounts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAccounts.Interfaces
{
    public interface IPersonsRepository<T>
    {
        ResponseModel<List<T>> CreatePerson(PersonsModel model);
        ResponseModel<List<T>> UpdatePerson(PersonsModel model);
        ResponseModel<List<T>> GetPersonByCode(int code);
        ResponseModel<List<T>> GetAllPeople();
        ResponseModel<List<T>> SearchPeople(PersonSearchModel searchModel);
        ResponseModel<List<T>> DeletePerson(int code);
        bool DoesIdNumberExist(string idNumber);
        bool DoesUserHaveAnActiveAccount(int code);
    }
}

using ISAccounts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAccounts.Interfaces
{
    public interface IAccountsRepository<T>
    {
        ResponseModel<List<T>> CreateAccount(AccountsModel model);
        ResponseModel<List<T>> GetAccountByPersonCode(int person_code);
        ResponseModel<List<T>> GetAccountByCode(int code);
        ResponseModel<List<T>> AdjustAccountBalance(int account_code, decimal amount);
        ResponseModel<List<T>> CloseAccountByCode(int code);
        bool DoesAccountNoExist(string accountNo);
        bool IsAccountActive(int code);
    }
}

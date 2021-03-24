using ISAccounts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAccounts.Interfaces
{
    public interface IAccountsService
    {
        ResponseModel<List<AccountsModel>> CreateAccount(AccountsModel model);
        ResponseModel<List<AccountsModel>> GetAccountByPersonCode(int person_code);
        ResponseModel<List<AccountsModel>> GetAccountByCode(int code);
        ResponseModel<List<AccountsModel>> CloseAccountByCode(int code);
    }
}

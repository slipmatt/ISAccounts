using ISAccounts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAccounts.Interfaces
{
    public interface ITransactionsRepository<T>
    {
        ResponseModel<List<T>> CreateTransaction(TransactionsModel model);
        ResponseModel<List<T>> GetTransactionsByAccountCode(int account_code);
        ResponseModel<List<T>> GetTransactionByCode(int code);
    }
}

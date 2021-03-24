using ISAccounts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAccounts.Interfaces
{
    public interface ITransactionsService
    {
        ResponseModel<List<TransactionsModel>> CreateTransaction(TransactionsModel model);
        ResponseModel<List<TransactionsModel>> GetTransactionsByAccountCode(int account_code);
        ResponseModel<List<TransactionsModel>> GetTransactionByCode(int code);
    }
}

using AutoMapper;
using ISAccounts.Data;
using ISAccounts.Data.Entities;
using ISAccounts.Interfaces;
using ISAccounts.Models;
using ISAccounts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAccounts.Services
{
    public class TransactionsService: ITransactionsService
    {
        ITransactionsRepository<TransactionsModel> _repo;
        IAccountsRepository<AccountsModel> _accountsRepo;
        private readonly IMapper _mapper;
        private IDateTimeHelper _dateTimeHelper;


        public TransactionsService(ApplicationDbContext context, IMapper mapper, ITransactionsRepository<TransactionsModel> repo, IAccountsRepository<AccountsModel> accountsRepo, IDateTimeHelper dateTimeHelper)
        {
            _repo = repo;
            _mapper = mapper;
            _accountsRepo = accountsRepo;
            _dateTimeHelper = dateTimeHelper;
        }

        public ResponseModel<List<TransactionsModel>> CreateTransaction(TransactionsModel model)
        {

            if (_dateTimeHelper.GetDateTimeNow()<model.TransactionDate)
            {
                return FailResponse(1, "TransactionDate cannot be greater than the current date");
            }
            if (model.Amount==0)
            {
                return FailResponse(2, "Amount cannot be 0");
            }
            var accountActive = _accountsRepo.IsAccountActive(model.AccountCode);
            if (!accountActive)
            {
                return FailResponse(3, "Cannot post transactions to a closed account");
            }

            _accountsRepo.AdjustAccountBalance(model.AccountCode, model.Amount);

            return _repo.CreateTransaction(model);
        }

        public ResponseModel<List<TransactionsModel>> GetTransactionByCode(int code)
        {
            return _repo.GetTransactionByCode(code);
        }

        public ResponseModel<List<TransactionsModel>> GetTransactionsByAccountCode(int account_code)
        {
            return _repo.GetTransactionsByAccountCode(account_code);
        }

        private ResponseModel<List<TransactionsModel>> FailResponse(int code = 0, string friendlyMessage = "", string technicalMessage = "")
        {
            return new ResponseModel<List<TransactionsModel>>
            {
                IsSuccess = false,
                Code = code,
                UserInterfaceMessage = friendlyMessage,
                TechnicalMessage = technicalMessage
            };
        }
    }
}

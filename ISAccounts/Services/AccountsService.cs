using AutoMapper;
using ISAccounts.Data;
using ISAccounts.Data.Entities;
using ISAccounts.Interfaces;
using ISAccounts.Models;
using ISAccounts.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAccounts.Services
{
    public class AccountsService :IAccountsService
    {
        IAccountsRepository<AccountsModel> _repo;
        private readonly IMapper _mapper;

        public AccountsService(ApplicationDbContext context, IMapper mapper, IAccountsRepository<AccountsModel> repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public ResponseModel<List<AccountsModel>> CreateAccount(AccountsModel model)
        {
            if (_repo.DoesAccountNoExist(model.AccountNumber))
                return FailResponse(2, "Account Number exists");

            return _repo.CreateAccount(model);
        }

        public ResponseModel<List<AccountsModel>> GetAccountByPersonCode(int person_code)
        {
            return _repo.GetAccountByPersonCode(person_code);
        }

        public ResponseModel<List<AccountsModel>> GetAccountByCode(int code)
        {
            return _repo.GetAccountByCode(code);
        }

        public ResponseModel<List<AccountsModel>> CloseAccountByCode(int code)
        {
            return _repo.CloseAccountByCode(code);
        }

        private ResponseModel<List<AccountsModel>> FailResponse(int code = 0, string friendlyMessage = "", string technicalMessage = "")
        {
            return new ResponseModel<List<AccountsModel>>
            {
                IsSuccess = false,
                Code = code,
                UserInterfaceMessage = friendlyMessage,
                TechnicalMessage = technicalMessage
            };
        }
    }
}

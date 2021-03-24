using AutoMapper;
using ISAccounts.Data;
using ISAccounts.Data.Entities;
using ISAccounts.Interfaces;
using ISAccounts.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAccounts.Repositories
{
    public class AccountsRepository<T> : BaseRepository<List<T>>, IAccountsRepository<T>
    {
        ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AccountsRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ResponseModel<List<T>> CreateAccount(AccountsModel model)
        {
            try
            {
                var accountEntity = _mapper.Map<AccountsModel, AccountsEntity>(model);
                _context.Account.Add(accountEntity);
                _context.SaveChanges();
                return SuccessResponse(0, "Saved successfully", "");
            }
            catch (Exception ex)
            {
                return FailResponse(1, "Error updating record", ex.GetBaseException().ToString());
            }
        }

        public ResponseModel<List<T>> GetAccountByPersonCode(int person_code)
        {
            try
            {
                var accountsEntityList = _context.Account.FromSqlRaw($"EXECUTE dbo.GetAllAccountsByPerson @Person_Code={person_code}").ToList();
                var accountsModelList = _mapper.Map<List<AccountsEntity>, List<T>>(accountsEntityList);
                var response = SuccessResponseWithObject(accountsModelList);
                return response;
            }
            catch (Exception ex)
            {
                return FailResponse(1, "Error Returning Records", ex.GetBaseException().ToString());
            }
        }

        public ResponseModel<List<T>> GetAccountByCode(int code)
        {
            try
            {
                var accountsEntityList = _context.Account.FromSqlInterpolated($"EXECUTE dbo.GetAllAccountsByCode {code}").ToList();
                var accountsModelList = _mapper.Map<List<AccountsEntity>, List<T>>(accountsEntityList);
                var response = SuccessResponseWithObject(accountsModelList);
                return response;
            }
            catch (Exception ex)
            {
                return FailResponse(1, "Error Returning Records", ex.GetBaseException().ToString());
            }
        }

        public ResponseModel<List<T>> CloseAccountByCode(int code)
        {
            try
            {
                var entity = _context.Account.Where(i => i.Code == code && i.Active).FirstOrDefault();
                if (entity == null)
                {
                    return FailResponse(2, "Account does not exist");
                }
                if (entity.Balance != 0)
                {
                    return FailResponse(2, "Acccount has a balance, cannot deactivate");
                }

                entity.Active = false;
                _context.SaveChanges();
                return SuccessResponse(0, "Account closed successfully", "");
            }
            catch (Exception ex)
            {
                return FailResponse(1, "Error updating record", ex.GetBaseException().ToString());
            }
        }

        public bool DoesAccountNoExist(string accountNo)
        {
            return _context.Account.Any(i => i.AccountNumber == accountNo);
        }

        public bool IsAccountActive(int code)
        {
            return _context.Account.FirstOrDefault(i => i.Code == code).Active;
        }

        public ResponseModel<List<T>> AdjustAccountBalance(int account_code, decimal amount)
        {
            try
            {
                var accountEntity = _context.Account.Where(i => i.Code == account_code).FirstOrDefault();
                accountEntity.Balance += amount;
                _context.SaveChanges();
                return SuccessResponse(0, "Balance updated successfully", "");
            }
            catch (Exception ex)
            {
                return FailResponse(1, "Error updating record", ex.GetBaseException().ToString());
            }
        }
    }
}

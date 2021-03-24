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
    public class TransactionsRepository<T> : BaseRepository<List<T>>, ITransactionsRepository<T>
    {
        ApplicationDbContext _context;
        private readonly IMapper _mapper;


        public TransactionsRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ResponseModel<List<T>> CreateTransaction(TransactionsModel model)
        {
            try
            {
                var transactionEntity = _mapper.Map<TransactionsModel, TransactionsEntity>(model);

                    _context.Transaction.Add(transactionEntity);
                    _context.SaveChanges();
                    return SuccessResponse(0, "Saved successfully", "");
            }
            catch (Exception ex)
            {
                return FailResponse(1, "Error updating record", ex.GetBaseException().ToString());
            }
        }

        public ResponseModel<List<T>> GetTransactionByCode(int code)
        {
            try
            {
                var transactionsEntityList = _context.Transaction.FromSqlInterpolated($"EXECUTE dbo.GetTransactionByCode {code}").ToList();
                var transactionsModelList = _mapper.Map<List<TransactionsEntity>, List<T>>(transactionsEntityList);
                var response = SuccessResponseWithObject(transactionsModelList);
                return response;
            }
            catch (Exception ex)
            {
                return FailResponse(1, "Error Returning Records", ex.GetBaseException().ToString());
            }
        }

        public ResponseModel<List<T>> GetTransactionsByAccountCode(int account_code)
        {
            try
            {
                var transactionsEntityList = _context.Transaction.FromSqlInterpolated($"EXECUTE dbo.GetTransactionsByAccountCode {account_code}").ToList();
                var transactionsModelList = _mapper.Map<List<TransactionsEntity>, List<T>>(transactionsEntityList);
                var response = SuccessResponseWithObject(transactionsModelList);
                return response;
            }
            catch (Exception ex)
            {
                return FailResponse(1, "Error Returning Records", ex.GetBaseException().ToString());
            }
        }
    }
}

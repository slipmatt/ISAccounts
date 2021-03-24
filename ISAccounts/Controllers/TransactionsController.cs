using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using ISAccounts.Interfaces;
using ISAccounts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ISTransactions.Controllers
{
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        ITransactionsService _Transactionservice;
        private readonly NLog.Logger _logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public TransactionsController(ITransactionsService Transactionservice)
        {
            _Transactionservice = Transactionservice;
            _logger.Debug("NLog injected into TransactionsController");
        }

        /// <summary>
        /// Adds a Transaction to the db
        /// </summary>
        [HttpPost("Transactions/CreateTransaction")]
        public ResponseModel<List<TransactionsModel>> CreateTransaction(TransactionsModel model)
        {
            _logger.Debug($"CreateTransaction with payload: {JsonConvert.SerializeObject(model)}");
            return _Transactionservice.CreateTransaction(model);
        }

        /// <summary>
        /// Gets a Transaction from the db using transaction code
        /// </summary>
        [HttpGet("Transactions/GetTransactionByCode/{id}")]
        public ResponseModel<List<TransactionsModel>> GetTransactionByCode(int id)
        {
            _logger.Debug($"GetTransactionByCode with code: {id}");
            return _Transactionservice.GetTransactionByCode(id);
        }

        /// <summary>
        /// Gets Transactions from the db using account code
        /// </summary>
        [HttpGet("Transactions/GetTransactionsByAccountCode/{id}")]
        public ResponseModel<List<TransactionsModel>> GetTransactionsByAccountCode(int id)
        {
            _logger.Debug($"GetTransactionsByAccountCode with code: {id}");
            return _Transactionservice.GetTransactionsByAccountCode(id);
        }
    }
}

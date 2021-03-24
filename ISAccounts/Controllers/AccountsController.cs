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

namespace ISAccounts.Controllers
{
    [ApiController]
    public class AccountsController : ControllerBase
    {
        IAccountsService _accountservice;
        private readonly NLog.Logger _logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public AccountsController(IAccountsService Accountservice)
        {
            _accountservice = Accountservice;
            _logger.Debug("NLog injected into AccountsController");
        }

        /// <summary>
        /// Adds an Account to the db
        /// </summary>
        [HttpPost("Accounts/CreateAccount")]
        public ResponseModel<List<AccountsModel>> CreateAccount(AccountsModel model)
        {
            _logger.Debug($"CreateAccount with payload: {JsonConvert.SerializeObject(model)}");
            return _accountservice.CreateAccount(model);
        }

        /// <summary>
        /// Gets an Account from the db using person code
        /// </summary>
        [HttpGet("Accounts/GetAccountByPersonCode/{id}")]
        public ResponseModel<List<AccountsModel>> GetAccountByPersonCode(int id)
        {
            _logger.Debug($"GetAccountByPersonCode with code: {id}");
            return _accountservice.GetAccountByPersonCode(id);
        }

        /// <summary>
        /// Gets an Account from the db using account code
        /// </summary>
        [HttpGet("Accounts/GetAccountByCode/{id}")]
        public ResponseModel<List<AccountsModel>> GetAccountByCode(int id)
        {
            _logger.Debug($"GetAccountByCode with code: {id}");
            return _accountservice.GetAccountByCode(id);
        }

        /// <summary>
        /// Closes an Account from the db using account code
        /// </summary>
        [HttpGet("Accounts/CloseAccountByCode/{id}")]
        public ResponseModel<List<AccountsModel>> CloseAccountByCode(int id)
        {
            _logger.Debug($"CloseAccountByCode with code: {id}");
            return _accountservice.CloseAccountByCode(id);
        }
    }
}

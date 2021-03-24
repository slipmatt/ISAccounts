using ISAccounts.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ISAccounts.Interfaces;
using ISAccounts.Repositories;
using System.Linq;
using ISAccounts.Tests.Builders;
using ISAccounts.Data;
using Microsoft.EntityFrameworkCore;
using ISAccounts.Services;

namespace ISAccounts.Tests.Tests
{
    [TestFixture]
    public class AccountTests : BaseTests<IAccountsRepository<AccountsModel>>
    {
        public IAccountsService _service;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationDbContext(options);

            _repos = new AccountsRepository<AccountsModel>(_context, _mapper);
            _service = new AccountsService(_context, _mapper, _repos);

            PrefillRepo();
            _repos = new AccountsRepository<AccountsModel>(_context, _mapper);
        }

        [TestCase]
        public void AccountTests_AddAccount()
        {
            //Arrange
            var person_code = 1;
            var model = new AccountsBuilder()
                .WithRandomProps()
                    .WithPersonCode(person_code)
                    .WithActive(true)
                .Build();

            //Act
            _service.CreateAccount(model);

            //Assert
            Assert.IsTrue(_context.Account.Any(i => i.Code == model.Code));
        }

        [TestCase]
        public void AccountTests_RejectAddAccountWithDuplicateAccountNumber()
        {
            //Arrange

            var person_code = 1;
            var model = new AccountsBuilder()
                .WithRandomProps()
                    .WithPersonCode(person_code)
                    .WithAccountNumber("100133")
                .Build();

            //Act
            _service.CreateAccount(model);

            //Assert
            Assert.IsTrue(_context.Account.Count(i => i.AccountNumber == "100133") == 1);
        }

        [TestCase]
        public void AccountTests_CloseAccountWithZeroBalance()
        {
            //Arrange

            //Act
            _service.CloseAccountByCode(4);

            //Assert
            Assert.IsTrue(_context.Account.Count(i => i.Code==4 && !i.Active) == 1);
        }

        [TestCase]
        public void AccountTests_RejectCloseAccountWithoutZeroBalance()
        {
            //Arrange

            //Act
            _service.CloseAccountByCode(5);

            //Assert
            Assert.IsTrue(_context.Account.Count(i => i.Code == 5 && i.Active) == 1);
        }

    }
}

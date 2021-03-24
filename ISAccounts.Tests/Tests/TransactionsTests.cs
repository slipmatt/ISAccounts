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
using Moq;
using ISAccounts.Services;

namespace ISAccounts.Tests.Tests
{
    [TestFixture]
    public class TransactionsTests : BaseTests<ITransactionsRepository<TransactionsModel>>
    {
        public ITransactionsService _service;
        Mock<IDateTimeHelper> _dateTimeHelper;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationDbContext(options);
            _repos = new TransactionsRepository<TransactionsModel>(_context, _mapper);
            var _accountrepos = new AccountsRepository<AccountsModel>(_context, _mapper);
            _dateTimeHelper = new Mock<IDateTimeHelper>();
            var fakeDate = DateTime.Parse("2021/03/21");
            _dateTimeHelper.Setup(o => o.GetDateTimeNow()).Returns(fakeDate);

            _service = new TransactionsService(_context, _mapper, _repos, _accountrepos, _dateTimeHelper.Object);
            _repos = new TransactionsRepository<TransactionsModel>(_context, _mapper);
            PrefillRepo();
        }

        [TestCase(101, 5, 50, 100)]
        [TestCase(102, 8, -45, 5)]
        public void TransactionTests_AddTransaction(int code,int accountCode, decimal transactionAmount, decimal expectedTotal)
        {
            //Arrange
            var model = new TransactionsBuilder()
                .WithRandomProps()
                    .WithCode(code)
                    .WithAccountCode(5)
                    .WithAmount(transactionAmount)
                    .WithCaptureDate(DateTime.Parse("2020/01/01"))
                    .WithTransactionDate(DateTime.Parse("2020/01/01"))
                .Build();

            //Act
            _service.CreateTransaction(model);

            //Assert
            Assert.IsTrue(_context.Transaction.Any(i => i.Code == model.Code));

            Assert.IsTrue(_context.Account.Where(i => i.Code == model.AccountCode).FirstOrDefault().Balance == expectedTotal);
        }

        [TestCase]
        public void TransactionTests_RejectTransactionInFuture()
        {
            //Arrange
            var model = new TransactionsBuilder()
                .WithRandomProps()
                    .WithCode(100)
                    .WithAccountCode(5)
                    .WithAmount(50)
                    .WithCaptureDate(DateTime.Parse("2020/01/01"))
                    .WithTransactionDate(DateTime.Parse("2023/01/01"))
                .Build();

            //Act
            _service.CreateTransaction(model);

            //Assert
            Assert.IsTrue(_context.Transaction.Count(i => i.Code == model.Code)==0);

            Assert.IsTrue(_context.Account.Where(i => i.Code == model.AccountCode).FirstOrDefault().Balance == 50);
        }

        //[TestCase]
        //public void AccountTests_RejectAddAccountWithDuplicateAccountNumber()
        //{
        //    //Arrange

        //    var person_code = 1;
        //    var model = new TransactionsBuilder()
        //        .WithRandomProps()
        //            .WithPersonCode(person_code)
        //            .WithAccountNumber("100133")
        //        .Build();

        //    //Act
        //    _repos.CreateTransactionsByPersonCode(model);

        //    //Assert
        //    Assert.IsTrue(_context.Account.Count(i => i.AccountNumber == "100133") == 1);
        //}

        //[TestCase]
        //public void AccountTests_CloseAccountWithZeroBalance()
        //{
        //    //Arrange

        //    //Act
        //    _repos.CloseAccountByCode(4);

        //    //Assert
        //    Assert.IsTrue(_context.Account.Count(i => i.Code==4 && !i.Active) == 1);
        //}

        //[TestCase]
        //public void AccountTests_RejectCloseAccountWithoutZeroBalance()
        //{
        //    //Arrange

        //    //Act
        //    _repos.CloseAccountByCode(5);

        //    //Assert
        //    Assert.IsTrue(_context.Account.Count(i => i.Code == 5 && i.Active) == 1);
        //}

    }
}

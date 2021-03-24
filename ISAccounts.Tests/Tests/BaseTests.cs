using AutoMapper;
using ISAccounts.Data;
using ISAccounts.Data.Entities;
using ISAccounts.Helpers;
using ISAccounts.Interfaces;
using ISAccounts.Mappings;
using ISAccounts.Models;
using ISAccounts.Repositories;
using ISAccounts.Tests.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISAccounts.Tests.Tests
{
    public class BaseTests<T>
    {
        public ApplicationDbContext _context;
        public IMapper _mapper;
        public T _repos;

        public BaseTests()
        {
            var services = new ServiceCollection();


            services.AddSingleton<IDateTimeHelper, DateTimeHelper>();
            services.AddScoped(typeof(IPersonsRepository<>), typeof(PersonsRepository<>));
            services.AddScoped(typeof(IAccountsRepository<>), typeof(AccountsRepository<>));
            services.AddScoped(typeof(ITransactionsRepository<>), typeof(TransactionsRepository<>));
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMappingProfile());
            });
            _mapper = mappingConfig.CreateMapper();
            services.AddSingleton(_mapper);
        }

        public void PrefillRepo()
        {
            FillPeople();
            FillAccounts();
            FillTransactions();
        }

        private void FillPeople()
        {
            {
                var model = new List<PersonsModel>
                {
                    new PersonsBuilder()
                    .WithRandomProps()
                    .WithCode(1)
                    .WithName("TestUser1")
                    .WithSurname("TestUserSurname1")
                    .WithIdNumber("82XX0106100XX")
                    .Build(),
                    new PersonsBuilder()
                    .WithRandomProps()
                    .WithCode(2)
                    .WithName("TestUser2")
                    .WithSurname("TestUserSurname2")
                    .WithIdNumber("83XX0106100XX")
                    .Build(),
                    new PersonsBuilder()
                    .WithRandomProps()
                    .WithCode(3)
                    .WithName("TestUser3")
                    .WithSurname("TestUserSurname3")
                    .WithIdNumber("84XX0106100XX")
                    .Build(),
                };
                var mappedEntities = _mapper.Map<List<PersonsModel>, List<PersonsEntity>>(model);

                if (_context.Person.CountAsync().Result > 0)
                {
                    _context.Person.RemoveRange(mappedEntities);
                    _context.SaveChanges();
                }
                _context.Person.AddRange(mappedEntities);
                _context.SaveChanges();
            }
        }
        private void FillAccounts()
        {
            var model = new List<AccountsModel>
                {
                    new AccountsBuilder()
                    .WithRandomProps()
                    .WithCode(1)
                    .WithPersonCode(1)
                    .WithAccountNumber("100132")
                    .Build(),
                    new AccountsBuilder()
                    .WithRandomProps()
                    .WithCode(2)
                    .WithPersonCode(2)
                    .Build(),
                    new AccountsBuilder()
                    .WithRandomProps()
                    .WithCode(3)
                    .WithAccountNumber("100133")
                    .WithPersonCode(2)
                    .Build(),
                    new AccountsBuilder()
                    .WithRandomProps()
                    .WithCode(4)
                    .WithAccountNumber("100138")
                    .WithActive(true)
                    .WithPersonCode(3)
                    .WithBalance(0)
                    .Build(),
                    new AccountsBuilder()
                    .WithRandomProps()
                    .WithCode(5)
                    .WithAccountNumber("100139")
                    .WithActive(true)
                    .WithPersonCode(3)
                    .WithBalance(50)
                    .Build(),
                    new AccountsBuilder()
                    .WithRandomProps()
                    .WithCode(6)
                    .WithAccountNumber("100140")
                    .WithActive(false)
                    .WithPersonCode(3)
                    .WithBalance(0)
                    .Build(),
                    new AccountsBuilder()
                    .WithRandomProps()
                    .WithCode(8)
                    .WithAccountNumber("100141")
                    .WithActive(true)
                    .WithPersonCode(3)
                    .WithBalance(50)
                    .Build(),

                };

            var mappedEntities = _mapper.Map<List<AccountsModel>, List<AccountsEntity>>(model);

            if (_context.Account.CountAsync().Result > 0)
            {
                _context.Account.RemoveRange(mappedEntities);
                _context.SaveChanges();
            }
            _context.Account.AddRange(mappedEntities);
            _context.SaveChanges();
        }
        private void FillTransactions()
        {
            var model = new List<TransactionsModel>
                {
                    new TransactionsBuilder()
                    .WithRandomProps()
                    .WithCode(1)
                    .WithAccountCode(5)
                    .WithAmount(50)
                    .WithCaptureDate(DateTime.Parse("2020/01/01"))
                    .WithTransactionDate(DateTime.Parse("2020/01/01"))
                    .Build()
                };

            var mappedEntities = _mapper.Map<List<TransactionsModel>, List<TransactionsEntity>>(model);

            if (_context.Transaction.CountAsync().Result > 0)
            {
                _context.Transaction.RemoveRange(mappedEntities);
                _context.SaveChanges();
            }
            _context.Transaction.AddRange(mappedEntities);
            _context.SaveChanges();
        }
    }
}

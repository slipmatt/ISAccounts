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
    public class PersonTests : BaseTests<IPersonsRepository<PersonsModel>>
    {
        public IPersonsService _service;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationDbContext(options);
            _repos = new PersonsRepository<PersonsModel>(_context,_mapper);
            _service = new PersonsService(_context, _mapper, _repos);
            PrefillRepo();
        }

        [TestCase]
        public void PersonTests_AddPerson()
        {
            //Arrange

            var model = new PersonsBuilder()
                .WithRandomProps()
                .WithCode(4)
                .WithName("TestCaseUserAddTest")
                .WithSurname("TestCaseSurNameAddTest")
                .WithIdNumber("82xx0751xxxxx")
                .WithActive(true)
                .Build();

            //Act
            _service.CreatePerson(model);

            //Assert
            Assert.IsTrue(_context.Person.Any(i => i.IdNumber == "82xx0751xxxxx"));
        }

        [TestCase]
        public void PersonTests_RejectAddPersonWithDuplicateIDNumber()
        {
            //Arrange

            var model = new PersonsBuilder()
                .WithRandomProps()
                .WithName("TestCaseUserAddTest")
                .WithSurname("TestCaseSurNameAddTest")
                .WithIdNumber("82XX0106100XX")
                .Build();

            //Act
            _service.CreatePerson(model);

            //Assert
            Assert.IsTrue(_context.Person.Count(i => i.IdNumber == "82XX0106100XX") == 1);
        }

        [TestCase]
        public void PersonTests_ReturnAllPeople()
        {
            //Arrange

            //Act
            var returnedRecord = _service.GetAllPeople();

            //Assert
            Assert.IsTrue(_context.Person.Count() == 3);
        }


        [TestCase("82XX0106100XX", null, null, 1)]
        [TestCase("82XX0106100XF", null, null, 0)]
        [TestCase("82XX0106100XX", "TestUserSurname2", null, 2)]
        [TestCase(null, null, "100133", 1)]
        public void PersonTests_ReturnSearchedPeople(string idNumber, string surname, string accountNo, int expectedResult)
        {
            //Arrange
            var searchModel = new PersonSearchModel
            {
                IdNumber = idNumber,
                Surname = surname,
                AccountNumber = accountNo
            };
            //Act
            var returnedRecord = _service.SearchPeople(searchModel);

            //Assert
            Assert.IsTrue(returnedRecord.ReturnObject.Count() == expectedResult);
        }
    }
}

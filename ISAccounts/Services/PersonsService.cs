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

namespace ISAccounts.Services
{
    public class PersonsService : IPersonsService
    {
        IPersonsRepository<PersonsModel> _repo;
        private readonly IMapper _mapper;

        public PersonsService(ApplicationDbContext context, IMapper mapper, IPersonsRepository<PersonsModel> repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public ResponseModel<List<PersonsModel>> CreatePerson(PersonsModel model)
        {
            if (_repo.DoesIdNumberExist(model.IdNumber))
                return FailResponse(2, "ID Number exists");
            return _repo.CreatePerson(model);
        }

        public ResponseModel<List<PersonsModel>> GetAllPeople()
        {
            return _repo.GetAllPeople();
        }

        public ResponseModel<List<PersonsModel>> GetPersonByCode(int code)
        {
            return _repo.GetPersonByCode(code);
        }

        public ResponseModel<List<PersonsModel>> SearchPeople(PersonSearchModel searchModel)
        {
            return _repo.SearchPeople(searchModel);

        }

        public ResponseModel<List<PersonsModel>> UpdatePerson(PersonsModel model)
        {
            return _repo.UpdatePerson(model);
        }

        public ResponseModel<List<PersonsModel>> DeletePerson(int code)
        {
            if (_repo.DoesUserHaveAnActiveAccount(code))
            {
                return FailResponse(2, "Person has an active account, cannot deactivate");
            }
            return _repo.DeletePerson(code);
        }

        private ResponseModel<List<PersonsModel>> FailResponse(int code = 0, string friendlyMessage = "", string technicalMessage = "")
        {
            return new ResponseModel<List<PersonsModel>>
            {
                IsSuccess = false,
                Code = code,
                UserInterfaceMessage = friendlyMessage,
                TechnicalMessage = technicalMessage
            };
        }
    }
}

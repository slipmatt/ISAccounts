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
    public class PersonsRepository<T> : BaseRepository<List<T>>, IPersonsRepository<T>
    {
        ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PersonsRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ResponseModel<List<T>> CreatePerson(PersonsModel model)
        {
            try
            {
                var personEntity = _mapper.Map<PersonsModel, PersonsEntity>(model);
                _context.Person.Add(personEntity);
                _context.SaveChanges();
                return SuccessResponse(0, "Saved successfully", "");
            }
            catch (Exception ex)
            {
                return FailResponse(1, "Error updating record", ex.GetBaseException().ToString());
            }
        }

        public ResponseModel<List<T>> GetAllPeople()
        {
            try
            {
                var personsEntityList = _context.Person.FromSqlInterpolated($"EXECUTE dbo.GetAllPeople").ToList();
                var personsModelList = _mapper.Map<List<PersonsEntity>, List<T>>(personsEntityList);
                var response = SuccessResponseWithObject(personsModelList);
                return response;
            }
            catch (Exception ex)
            {
                return FailResponse(1, "Error Returning Records", ex.GetBaseException().ToString());
            }
        }

        public ResponseModel<List<T>> GetPersonByCode(int code)
        {
            try
            {
                var personsEntityList = _context.Person.Where(i => i.Code == code).ToList();
                var personsModelList = _mapper.Map<List<PersonsEntity>, List<T>>(personsEntityList);
                var response = SuccessResponseWithObject(personsModelList);
                return response;
            }
            catch (Exception ex)
            {
                return FailResponse(1, "Error Returning Records", ex.GetBaseException().ToString());
            }
        }

        public ResponseModel<List<T>> SearchPeople(PersonSearchModel searchModel)
        {
            try
            {
                var personsEntityList = new List<PersonsEntity>();
                if (searchModel.AccountNumber != null)
                {
                    var personCode = _context.Account.Where(i => i.AccountNumber.Contains(searchModel.AccountNumber)).Select(i => i.PersonCode).ToList();
                    personsEntityList.AddRange(_context.Person.Where(i => personCode.Contains(i.Code)).ToList());
                }
                if (searchModel.IdNumber != null)
                {
                    personsEntityList.AddRange(_context.Person.Where(i => i.IdNumber.Contains(searchModel.IdNumber)).ToList());
                }
                if (searchModel.Surname != null)
                {
                    personsEntityList.AddRange(_context.Person.Where(i => i.Surname.Contains(searchModel.Surname)).ToList());
                }
                var personsModelList = _mapper.Map<List<PersonsEntity>, List<T>>(personsEntityList);
                var response = SuccessResponseWithObject(personsModelList);
                return response;
            }
            catch (Exception ex)
            {
                return FailResponse(1, "Error Returning Records", ex.GetBaseException().ToString());
            }

        }

        public ResponseModel<List<T>> UpdatePerson(PersonsModel model)
        {
            try
            {
                var entity = _context.Person.Where(i => i.Code == model.Code).FirstOrDefault();
                if (entity == null)
                {
                    var response = new ResponseModel<List<T>>();
                    response.IsSuccess = false;
                    response.UserInterfaceMessage = "Person does not exist";
                    return response;
                }
                entity.Name = model.Name;
                entity.Surname = model.Surname;
                entity.IdNumber = model.IdNumber;
                entity.Active = model.Active;
                _context.SaveChanges();
                return SuccessResponse(0, "Updated successfully", "");
            }
            catch (Exception ex)
            {
                return FailResponse(1, "Error updating record", ex.GetBaseException().ToString());
            }
        }

        public ResponseModel<List<T>> DeletePerson(int code)
        {
            try
            {
                var entity = _context.Person.Where(i => i.Code == code).FirstOrDefault();
                if (entity == null)
                {
                    return FailResponse(2, "Person does not exist");
                }

                entity.Active = false;
                _context.SaveChanges();
                return SuccessResponse(0, "Person deactivated successfully", "");
            }
            catch (Exception ex)
            {
                return FailResponse(1, "Error updating record", ex.GetBaseException().ToString());
            }
        }

        public bool DoesIdNumberExist(string idNumber)
        {
            return _context.Person.Any(i => i.IdNumber == idNumber);
        }

        public bool DoesUserHaveAnActiveAccount(int code)
        {
            return _context.Account.Any(i => i.PersonCode == code && i.Active);
        }
    }
}

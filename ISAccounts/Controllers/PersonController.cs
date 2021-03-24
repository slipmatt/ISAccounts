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
    public class PersonController : ControllerBase
    {
        IPersonsService _personService;
        private readonly NLog.Logger _logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public PersonController(IPersonsService personService)
        {
            _personService = personService;
            _logger.Debug("NLog injected into PersonController");
        }

        /// <summary>
        /// Adds a person to the db
        /// </summary>
        [HttpPost("Person/CreatePerson")]
        public ResponseModel<List<PersonsModel>> CreatePerson(PersonsModel model)
        {
            _logger.Debug($"CreatePerson with payload: {JsonConvert.SerializeObject(model)}");
            return _personService.CreatePerson(model);
        }

        /// <summary>
        /// Gets all people from the db
        /// </summary>
        [HttpGet("Person/GetAllPeople")]
        public ResponseModel<List<PersonsModel>> GetAllPeople()
        {
            _logger.Debug($"GetAllPeople controller call");
            return _personService.GetAllPeople();
        }

        /// <summary>
        /// Gets a person from the db by code
        /// </summary>
        [HttpGet("Person/GetPersonByCode/{id}")]
        public ResponseModel<List<PersonsModel>> GetPersonByCode(int id)
        {
            _logger.Debug($"GetPersonByCode controller call with id: {id}");
            return _personService.GetPersonByCode(id);
        }

        /// <summary>
        /// Gets a person from the db by code
        /// </summary>
        [HttpPost("Person/SearchPeople")]
        public ResponseModel<List<PersonsModel>> SearchPeople(PersonSearchModel searchModel)
        {
            _logger.Debug($"SearchPeople with payload: {JsonConvert.SerializeObject(searchModel)}");
            return _personService.SearchPeople(searchModel);
        }

        /// <summary>
        /// Updates a person from the db
        /// </summary>
        [HttpPost("Person/UpdatePerson")]
        public ResponseModel<List<PersonsModel>> UpdatePerson(PersonsModel model)
        {
            _logger.Debug($"UpdatePerson with payload: {JsonConvert.SerializeObject(model)}");
            return _personService.UpdatePerson(model);
        }

        /// <summary>
        /// Deactivates a person from the db
        /// </summary>
        [HttpGet("Person/DeletePerson/{id}")]
        public ResponseModel<List<PersonsModel>> DeletePerson(int id)
        {
            _logger.Debug($"DeletePerson with code: {id}");
            return _personService.DeletePerson(id);
        }
    }
}

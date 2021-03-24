using AutoMapper;
using ISAccounts.Data.Entities;
using ISAccounts.Interfaces;
using ISAccounts.Models;
using ISAccounts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAccounts.Mappings
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<PersonsEntity, PersonsModel>().ReverseMap();
            CreateMap<AccountsEntity, AccountsModel>().ReverseMap();
            CreateMap<TransactionsEntity, TransactionsModel>().ReverseMap();
        }
    }
}

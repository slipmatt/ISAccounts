using ISAccounts.Models;
using PeanutButter.RandomGenerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISAccounts.Tests.Builders
{
    public class PersonsBuilder : GenericBuilder<PersonsBuilder, PersonsModel>
    {
        public PersonsBuilder WithCode(int value)
        {
            return WithProp(x => x.Code = value);
        }

        public PersonsBuilder WithName(string value)
        {
            return WithProp(x => x.Name = value);
        }

        public PersonsBuilder WithSurname(string value)
        {
            return WithProp(x => x.Surname = value);
        }

        public PersonsBuilder WithIdNumber(string value)
        {
            return WithProp(x => x.IdNumber = value);
        }

        public PersonsBuilder WithActive(bool value)
        {
            return WithProp(x => x.Active = value);
        }
    }
}
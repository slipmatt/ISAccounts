using ISAccounts.Models;
using PeanutButter.RandomGenerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISAccounts.Tests.Builders
{
    public class AccountsBuilder : GenericBuilder<AccountsBuilder, AccountsModel>
    {
        public AccountsBuilder WithCode(int value)
        {
            return WithProp(x => x.Code = value);
        }

        public AccountsBuilder WithPersonCode(int value)
        {
            return WithProp(x => x.PersonCode = value);
        }

        public AccountsBuilder WithAccountNumber(string value)
        {
            return WithProp(x => x.AccountNumber = value);
        }

        public AccountsBuilder WithBalance(decimal value)
        {
            return WithProp(x => x.Balance = value);
        }


        public AccountsBuilder WithActive(bool value)
        {
            return WithProp(x => x.Active = value);
        }

    }
}
using ISAccounts.Models;
using PeanutButter.RandomGenerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISAccounts.Tests.Builders
{
    public class TransactionsBuilder : GenericBuilder<TransactionsBuilder, TransactionsModel>
    {
        public TransactionsBuilder WithCode(int value)
        {
            return WithProp(x => x.Code = value);
        }

        public TransactionsBuilder WithAccountCode(int value)
        {
            return WithProp(x => x.AccountCode = value);
        }

        public TransactionsBuilder WithTransactionDate(DateTime value)
        {
            return WithProp(x => x.TransactionDate = value);
        }

        public TransactionsBuilder WithCaptureDate(DateTime value)
        {
            return WithProp(x => x.CaptureDate = value);
        }

        public TransactionsBuilder WithAmount(decimal value)
        {
            return WithProp(x => x.Amount = value);
        }

        public TransactionsBuilder WithDescription(string value)
        {
            return WithProp(x => x.Description = value);
        }

    }
}
using ISAccounts.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAccounts.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<PersonsEntity> Person { get; set; }
        public virtual DbSet<AccountsEntity> Account { get; set; }
        public virtual DbSet<TransactionsEntity> Transaction { get; set; }
    }
}

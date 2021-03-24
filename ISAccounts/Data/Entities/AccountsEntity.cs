using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISAccounts.Data.Entities
{
    [Table("Accounts")]
    public class AccountsEntity
    {
        [Key]
        [Required]
        [Column("code")]
        public int Code { get; set; }

        [Required]
        [Column("person_code")]
        public int PersonCode { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("account_number")]
        public string AccountNumber { get; set; }

        [Required]
        [Column("outstanding_balance")]
        public decimal Balance { get; set; }

        [Required]
        [Column("Active")]
        public bool Active { get; set; }
    }
}

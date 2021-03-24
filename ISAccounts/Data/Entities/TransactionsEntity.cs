using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISAccounts.Data.Entities
{
    [Table("Transactions")]
    public class TransactionsEntity
    {
        [Key]
        [Required]
        [Column("code")]
        public int Code { get; set; }

        [Required]
        [Column("account_code")]
        public int AccountCode { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("transaction_date", TypeName = "DateTime")]
        public DateTime TransactionDate { get; set; }

        [Required]
        [Column("capture_date", TypeName = "DateTime")]
        public DateTime CaptureDate { get; set; }

        [Required]
        [Column("amount")]
        public decimal Amount { get; set; }

        [Required]
        [Column("description")]
        public string Description { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISAccounts.Models
{
    public class TransactionsModel
    {
        [Key]
        [Required]
        public int Code { get; set; }

        [Required]
        public int AccountCode { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public DateTime CaptureDate { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string Description { get; set; }

    }
}

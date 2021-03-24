using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISAccounts.Models
{
    [Table("Accounts")]
    public class AccountsModel
    {
        [Key]
        [Required]
        public int Code { get; set; }

        [Required]
        public int PersonCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string AccountNumber { get; set; }

        [Required]
        public decimal Balance { get; set; }

        [Required]
        public bool Active { get; set; }
    }
}

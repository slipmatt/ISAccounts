using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISAccounts.Models
{
    public class PersonSearchModel
    {
        public string IdNumber { get; set; }

        public string Surname { get; set; }

        public string AccountNumber { get; set; }
    }
}

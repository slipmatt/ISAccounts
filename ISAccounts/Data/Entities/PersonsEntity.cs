using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISAccounts.Data.Entities
{
    [Table("Persons")]
    public class PersonsEntity
    {
        [Key]
        [Required]
        [Column("code")]
        public int Code { get; set; }

        [MaxLength(50)]
        [Column("name")]
        public string Name { get; set; }

        [MaxLength(50)]
        [Column("surname")]
        public string Surname { get; set; }

        [Required]
        [Column("id_number")]
        [MaxLength(50)]
        public string IdNumber { get; set; }

        [Required]
        [Column("Active")]
        public bool Active { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Debit_Credit.Models
{
    public class AmountTkClass
    {
        [Key]
        public int amountId { get; set; }

        [Column("NVARCHAR(50)")]
        public string amountTk { get; set; }
    }
}

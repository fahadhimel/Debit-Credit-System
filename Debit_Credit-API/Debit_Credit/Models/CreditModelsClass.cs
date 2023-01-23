using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Debit_Credit.Models
{
    public class CreditModelsClass
    {
        [Key]
        public int CreditID { get; set; }

        [Column(TypeName = "NVARCHAR(100)")]
        public string CreditTK { get; set; }

        [Column(TypeName = "NVARCHAR(100)")]
        public string CreditDate { get; set; }

        [Column(TypeName = "NVARCHAR(100)")]
        public string CreditTime { get; set; }
    }
}

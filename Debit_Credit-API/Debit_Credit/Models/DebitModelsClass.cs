using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Debit_Credit.Models
{
    public class DebitModelsClass
    {
        [Key]
        public int DebitID { get; set; }

        [Column(TypeName ="NVARCHAR(100)")]
        public string DebitTK { get; set; }

        [Column(TypeName ="NVARCHAR(100)")]
        public string DebitDate { get; set; }

        [Column(TypeName = "NVARCHAR(100)")]
        public string DebitTime { get; set; }
    }
}

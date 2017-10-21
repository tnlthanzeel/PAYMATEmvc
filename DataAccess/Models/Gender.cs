using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    [Table("Gender", Schema = "Lookup")]
    public class Gender
    {
        [Key]
        public int GenderId { get; set; }
        public string GenderType { get; set; }

    }
}

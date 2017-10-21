using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    [Table("Customer", Schema = "Models")]
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public string CustomerFirstName { get; set; }

        [Required]
        public string CustomerLastName { get; set; }

        [Required]
        public string CustomerPassword { get; set; }

        [Required]
        public long CustomerCardNo { get; set; }

        [Required]
        public string CustomerEmailAddress { get; set; }

        [Required]
        public int GenderID { get; set; }

        public Gender Gender { get; set; }


        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime? EditedOn { get; set; }

        public int Status { get; set; }




    }
}

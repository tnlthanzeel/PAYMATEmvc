﻿using Common.Enumarations;
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

        public Guid CustomerGuid { get; set; }

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
        public GenderEnum Gender { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime? EditedOn { get; set; }

        public int Status { get; set; }

        public bool EmailConfirmed { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string ProfilePicUrl { get; set; }
    }
}

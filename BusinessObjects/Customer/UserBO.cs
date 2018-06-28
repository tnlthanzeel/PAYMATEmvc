using BusinessObjects.Customer;
using Common.Enumarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class UserBO : CommonBo
    {
        public int CustomerId { get; set; }

        public Guid CustomerGuid { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public string CustomerPassword { get; set; }

        public string ConfirmPassword { get; set; }

        public long CustomerCardNo { get; set; }

        public string CustomerEmailAddress { get; set; }

        public GenderEnum Gender { get; set; }

        public int Status { get; set; }

        public bool EmailConfirmed { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string ProfilePicUrl { get; set; }

        public string CustomerFullName
        {
            get
            {
                return (CustomerFirstName + " " + CustomerLastName);
            }
        }
    }
}
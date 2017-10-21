using BusinessObjects.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class CustomerBO : CommonBo
    {
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public string CustomerPassword { get; set; }

        public string ConfirmPassword { get; set; }

        public long? CustomerCardNo { get; set; }

        public string CustomerEmailAddress { get; set; }

        public int GenderID { get; set; }
    }
}
using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIServices.LookupServices
{
    public class GenderLookupService
    {
        private readonly PaymateDB _GenderLookup;

        public GenderLookupService(PaymateDB genderLookup)
        {
            _GenderLookup = genderLookup;
        }


       


    }
}

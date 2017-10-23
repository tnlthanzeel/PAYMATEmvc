using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIServices.LookupServices
{
    public class GenderLookupService
    {
        private readonly PaymateDB _GenderLookup;

        public GenderLookupService()
        {
            _GenderLookup = new PaymateDB();
        }


        public IEnumerable<Gender> GetGender()
        {

            var Genders = _GenderLookup.Gender.AsNoTracking().ToList();
            return Genders;

        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RepositoryBase
    {
        private readonly PaymateDB _paymateDB;

        public RepositoryBase(PaymateDB paymateDB)
        {
            _paymateDB = paymateDB;
        }

        public PaymateDB CreateContext()
        {
            return _paymateDB;
        }
    }
}

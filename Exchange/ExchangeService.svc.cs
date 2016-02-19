using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Exchange
{
    public class ExchangeService : IExchange
    {
        public Account GetAccountDetails(int Account)
        {
            throw new NotImplementedException();
        }


        public void SetRequest(Account account)
        {
            throw new NotImplementedException();
        }
    }
}

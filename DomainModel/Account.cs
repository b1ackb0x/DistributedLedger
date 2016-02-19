using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
   public class Account
    {
        public int ID { get; set; }
        public string HolderName { get; set; }
        public double TransferAmount { get; set; }
        public double  TotalAmount { get; set; }

    }
}

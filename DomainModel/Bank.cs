using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Bank
    {
        public int ID { get; set; }
        public string Name{ get; set; }
        public List<Account>  Accounts { get; set; }
    }
}

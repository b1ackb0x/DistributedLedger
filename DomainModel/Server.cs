using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Server
    {
        public int ID { get; set; }
        public List<Minor> Minors { get; set; }
    }
}

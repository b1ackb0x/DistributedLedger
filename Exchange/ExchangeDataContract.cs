using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Runtime;
using System.Runtime.Serialization;

namespace Exchange
{
    [DataContract]
    public class Account
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public double Amount { get; set; }
    }
}
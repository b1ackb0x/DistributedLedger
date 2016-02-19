using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Transaction
    {
        public Guid ID { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public double Amount { get; set; }
        public Account SenderAccount { get; set; }
        public Account ReceiverAccount { get; set; }

        public Byte[] EncryptedTransaction
        {
            get
            {
                return ConvertObjectToByteArray(this);
            }
        }

        private byte[] ConvertObjectToByteArray(object obj)
        {
            if (obj == null) return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream()) { bf.Serialize(ms, obj); return ms.ToArray(); }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class EncryptedTransaction
    {
        public Byte[] TransactionBytes
        {
            get
            {
                return ConvertObjectToByteArray(Transaction);
            }
        }
        public Transaction Transaction { get; set; }

        private byte[] ConvertObjectToByteArray(object obj)
        {
            if (obj == null) return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream()) { bf.Serialize(ms, obj); return ms.ToArray(); }
        }

    }
}

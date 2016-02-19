using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Exchange
{
    [ServiceContract(CallbackContract = typeof(IExchangeCallBacks))]
    public interface IExchange
    {
        [OperationContract(IsOneWay = true)]
        void RegisterClient(string clientName);

        [OperationContract(IsOneWay = true)]     
        void SetTransaction(ExchangeRequest objTransaction);

        [OperationContract(IsOneWay = true)]
        BlockChain GetBlockChain();
    }


    [DataContract()]
    public class ExchangeRequest
    {
        [DataMember]
        public string ClientName { get; set; }

        [DataMember]
        public Transaction Trans { get; set; }
    }

    public interface IExchangeCallBacks
    {
        [OperationContract(IsOneWay = true)]
        void BroadcastTransectionToClient(ExchangeRequest exchangeRequest);
    }
}

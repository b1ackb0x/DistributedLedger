using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DomainModel;

namespace Exchange
{
     [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ExchangeService : IExchange
    {
        private static Dictionary<string, IExchangeCallBacks> clients =
            new Dictionary<string, IExchangeCallBacks>();

        private static object locker = new object();

         private DispatcherService.DispatcherClient client;

        public void RegisterClient(string clientName)
        {
            if (clientName != null && clientName != "")
            {
                try
                {
                    IExchangeCallBacks callback =
                        OperationContext.Current.GetCallbackChannel<IExchangeCallBacks>();
                    lock (locker)
                    {
                        //remove the old client
                        if (clients.Keys.Contains(clientName))
                            clients.Remove(clientName);
                        clients.Add(clientName, callback);
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }


        public void SetTransaction(int senderAccountId, int receiverAccountId, int amt)
        {
            try
            {
                if (client == null)
                {
                    client = new DispatcherService.DispatcherClient();
                }
                
                client.SetTransaction(senderAccountId, receiverAccountId, amt);
            
            }
            catch(Exception)
            {
                
                throw;
            }
            /*
             lock (locker)
            {
                var inactiveClients = new List<string>();
                foreach (var client in clients)
                {
                    if (client.Key != exchangeRequest.ClientName)
                    {
                        try
                        {
                            client.Value.BroadcastTransectionToClient(exchangeRequest);
                        }
                        catch (Exception ex)
                        {
                            inactiveClients.Add(client.Key);
                        }
                    }
                }

                if (inactiveClients.Count > 0)
                {
                    foreach (var client in inactiveClients)
                    {
                        clients.Remove(client);
                    }
                }
            }
             */
        }

        public BlockChainContract GetBlockChain()
        {
            if (client == null)
            {
                client = new DispatcherService.DispatcherClient();
            }
            
            List<Block> bc = client.GetBlockChain().ToList();
            return new BlockChainContract {Blocks = bc};
        }
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DomainModel;
using Process;

namespace Dispatcher
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class DispatcherService : IDispatcher
    {
       //private ExchangeService.ExchangeClient _client;

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        //public void HandleBroadcast(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var eventData = (ExchangeService.ExchangeRequest)sender;
        //       //TODO---- 
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        //public static void Configure(ServiceConfiguration config)
        //{
        //    RegisterClient();
        //}

        //private static void RegisterClient()
        //{
        //    if ((this._client != null))
        //    {
        //        this._client.Abort();
        //        this._client = null;
        //    }

        //    ExchangeService.cb = new ExchangeCallback();
        //    cb.SetHandler(this.HandleBroadcast);

        //    System.ServiceModel.InstanceContext context =
        //        new System.ServiceModel.InstanceContext(cb);
        //    this._client =
        //        new BroadcastorService.BroadcastorServiceClient(context);

        //    this._client.RegisterClient(this.txtClientName.Text);
        //}

        public void SetTransaction(DomainModel.Transaction transaction)
        {
                Process.HandleSetCase obj = new HandleSetCase(transaction.SenderAccount, transaction.ReceiverAccount, transaction.Amount);   
                obj.SetBlockChain();
        }

        public BlockChain GetBlockChain()
        {
            return Process.BlockChainManager.GetBlockChain();
        }
    }

    //public class ExchangeCallback : IExchangeCallback
    //{
        
    //    private System.Threading.SynchronizationContext syncContext =
    //        AsyncOperationManager.SynchronizationContext;

    //    private EventHandler _broadcastorCallBackHandler;
    //    public void SetHandler(EventHandler handler)
    //    {
    //        this._broadcastorCallBackHandler = handler;
    //    }

    //    public void BroadcastTransectionToClient(ExchangeRequest request)
    //    {
    //        syncContext.Post(new System.Threading.SendOrPostCallback(OnBroadcast),
    //               request);
    //    }

    //    private void OnBroadcast(object eventData)
    //    {
    //        this._broadcastorCallBackHandler.Invoke(eventData, null);
    //    }
    //}
}

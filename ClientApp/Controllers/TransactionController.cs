using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientApp.ExchangeService;
using ClientApp.Models;
using DomainModel;

namespace ClientApp.Controllers
{
    public class TransactionController : Controller
    {
        private ExchangeService.ExchangeClient _client;
        public ActionResult Index()
        {
            ensureClient();
            ViewData["BlockChain"] = _client.GetBlockChain().Blocks;

            return View();
        }

        [HttpPost]
        public ActionResult Send(TransactionModel t)
        {
            //TransactionModel obj = new TransactionModel();
            //obj.SenderAccountNo = Convert.ToInt32(User.Identity.Name);

            ensureClient();
            ExchangeRequest request = new ExchangeRequest();
            request.ClientName = "Test";
            request.Trans = new Transaction();
            request.Trans.SenderAccount = new Account { ID = t.SenderAccountNo };
            request.Trans.ReceiverAccount = new Account { ID = t.ReceiverAccountNo };
            request.Trans.Amount = t.Amount;
            request.Trans.TimeStamp = DateTimeOffset.Now;
            _client.SetTransaction(request);

            return RedirectToAction("Index");
        }

        private void ensureClient()
        {
            if (_client == null)
            {
                ExchangeCallback cb = new ExchangeCallback();
                cb.SetHandler(this.HandleBroadcast);

                System.ServiceModel.InstanceContext context =
                    new System.ServiceModel.InstanceContext(cb);
            
                _client = new ExchangeClient(context);
            }
        }

        public void HandleBroadcast(object sender, EventArgs e)
        {
            try
            {
                var eventData = (ExchangeService.ExchangeRequest)sender;
                //TODO---- 
            }
            catch (Exception ex)
            {
            }
        }

    }

    public class ExchangeCallback : IExchangeCallback
    {

        private System.Threading.SynchronizationContext syncContext =
            AsyncOperationManager.SynchronizationContext;

        private EventHandler _broadcastorCallBackHandler;
        public void SetHandler(EventHandler handler)
        {
            this._broadcastorCallBackHandler = handler;
        }

        public void BroadcastTransectionToClient(ExchangeRequest request)
        {
            syncContext.Post(new System.Threading.SendOrPostCallback(OnBroadcast),
                   request);
        }

        private void OnBroadcast(object eventData)
        {
            this._broadcastorCallBackHandler.Invoke(eventData, null);
        }
    }
}

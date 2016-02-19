using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class TransactionController : Controller
    {
        //
        // GET: /Transaction/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Send(TransactionModel t) 
        {
            TransactionModel obj = new TransactionModel();
            obj.SenderAccountNo = Convert.ToInt32(User.Identity.Name);
            return View(obj);
        }


    }
}

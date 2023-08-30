using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace WebhookCallback.Controllers
{
    public class WebhookController : Controller
    {
        
        private static List<string> _dataReceived = new List<string>();

        [HttpPost]
        public string ReceiveWebhook()
        {
            using (var reader = new StreamReader(Request.InputStream))
            {
                var json = reader.ReadToEnd();
                _dataReceived.Add(json);
                return json;
            }
        }

        public ActionResult Index()
        {
            return View(_dataReceived);
        }

        public PartialViewResult GetReceivedData()
        {
            return PartialView("_DataReceived", _dataReceived);
        }
    }

}
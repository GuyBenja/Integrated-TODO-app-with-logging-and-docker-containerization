using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using log4net;

namespace AspWebApiServer.Controllers
{
    public class Health : Controller
    {
        private static RequestLogger logger ;

        // Get: Health
        [HttpGet]
        [Route("/todo/health")]
        public ActionResult<string> CheckHealth()
        {
            logger = new RequestLogger("/todo/health", "GET");
            var stopwatch = Stopwatch.StartNew();
            var requestNumber = Guid.NewGuid().ToString();
            var duration = stopwatch.ElapsedMilliseconds;

            logger.LogRequest(duration);

            string message = "OK";
            return Ok(message);
        }
    }
}

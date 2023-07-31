using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using log4net.Repository;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AspWebApiServer.Controllers
{
    public class LogController : Controller
    {
        private RequestLogger requestLogger;

        [HttpGet]
        [Route("/logs/level")]
        public ActionResult<string> GetLogLevel([FromQuery(Name ="logger-name")] string logName)
        {
            requestLogger = new RequestLogger("/logs/level", "GET");
            var stopwatch = Stopwatch.StartNew();
            Response response = null;
            int statusCode = 400;

            if (logName != "request-logger" && logName != "todo-logger")
            {
                statusCode = 404;
                response=new Response("", $"Error: no such logger with the name  {logName}");
            }
            else if (logName == "request-logger")
            {
                statusCode = 200;
                response=new Response(ToDoListController.requestLogger.GetCurrentLogLevel(), "");
            }
            else if (logName == "todo-logger")
            {
                statusCode = 200;
                response = new Response(ToDoListController.todoLogger.GetCurrentLogLevel(), "");
            }

            var duration = stopwatch.ElapsedMilliseconds;
            requestLogger.LogRequest(duration);

            return StatusCode(statusCode, JsonConvert.SerializeObject(response));
        }

        [HttpPut]
        [Route("/logs/level")]
        public ActionResult<string> SetLogLevel([FromQuery(Name ="logger-name")] string loggerName,[FromQuery(Name = "logger-level")] string requestLevel)
        {
            Response response = null;
            int statusCode = 400;
            bool isSetSucceeded;
            requestLogger = new RequestLogger("/logs/level", "PUT");
            var stopwatch = Stopwatch.StartNew();

            if (loggerName != "request-logger" && loggerName != "todo-logger")
            {
                statusCode = 404;
                response = new Response("", $"Error: no such logger with the name  {loggerName}");
            }
            else if (loggerName == "request-logger")
            {
                isSetSucceeded = ToDoListController.requestLogger.SetLogLevel(requestLevel);
                if (isSetSucceeded)
                {
                    statusCode = 200;
                    response = new Response(ToDoListController.requestLogger.GetCurrentLogLevel(), "");
                }
                else
                {
                    statusCode = 400;
                    response = new Response("", $"Error: you can not set this log level: {requestLevel}");
                }
            }
            else if (loggerName == "todo-logger")
            {
                isSetSucceeded = ToDoListController.todoLogger.SetLogLevel(requestLevel);
                if (isSetSucceeded)
                {
                    statusCode = 200;
                    response = new Response(ToDoListController.todoLogger.GetCurrentLogLevel(), "");
                }
                else
                {
                    statusCode = 400;
                    response = new Response("", $"Error: you can not set this log level: {requestLevel}");
                }
            }

            var duration = stopwatch.ElapsedMilliseconds;
            requestLogger.LogRequest(duration);

            return StatusCode(statusCode, JsonConvert.SerializeObject(response));
        }
    }
}

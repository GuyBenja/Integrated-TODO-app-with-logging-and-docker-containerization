using System;
using log4net;
using log4net.Core;
using log4net.Repository;

namespace AspWebApiServer
{
    public class RequestLogger
    {
        private readonly ILog _logger;
        private readonly string _resourceName;
        private readonly string _httpVerb;
        public static int _requestNumber=0;

        public RequestLogger(string resourceName, string httpVerb)
        {
            _resourceName = resourceName;
            _httpVerb = httpVerb;
            _logger = LogManager.GetLogger("request-logger");
        }
        public void LogRequest(long duration)
        {
            _requestNumber++;
            log4net.GlobalContext.Properties["request-number"] = _requestNumber;
            var message = $"Incoming request | #{_requestNumber} | resource: {_resourceName} | HTTP Verb {_httpVerb}";
            _logger.Info(message);
            _logger.Debug($"request #{_requestNumber} duration: {duration}ms");
        }
        public string GetCurrentLogLevel()
        {
            ILoggerRepository repository = _logger.Logger.Repository;
            return repository.Threshold.ToString().ToUpper();
        }
        public bool SetLogLevel(string stringLevel)
        {
            Level newLevel = null;
            switch (stringLevel.ToUpper())
            {
                case "INFO":
                    newLevel = Level.Info;
                    break;
                case "DEBUG":
                    newLevel = Level.Debug;
                    break;
                case "ERROR":
                    newLevel = Level.Error;
                    break;
                default:
                    return false;
            }

            var loggerImpl = _logger.Logger as log4net.Repository.Hierarchy.Logger;
            if (loggerImpl != null)
            {
                loggerImpl.Level = newLevel;
                return true;
            }

            return false;
        }

    }
}

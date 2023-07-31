using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using log4net.Core;
using log4net.Repository;

namespace AspWebApiServer
{

    public class TodoLogger
    {
        private readonly ILog _logger;
        public TodoLogger()
        {
            _logger = LogManager.GetLogger("todo-logger");
        }
        public Level GetCurrentLogLevel()
        {
            ILoggerRepository repository = _logger.Logger.Repository;
            return repository.Threshold;
        }
        public bool SetLogLevel(string stringLevel)
        {
            Level newLevel = null;
            switch (stringLevel.ToUpper())
            {
                case "DEBUG":
                    newLevel = Level.Debug;
                    break;
                case "INFO":
                    newLevel = Level.Info;
                    break;
                case "WARN":
                    newLevel = Level.Warn;
                    break;
                case "ERROR":
                    newLevel = Level.Error;
                    break;
                case "FATAL":
                    newLevel = Level.Fatal;
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
        public void LogCreateNewTodo(string newTodoTitle, int totalExistingTodos, int newTodoId)
        {
            _logger.Info($"Creating new TODO with Title [{newTodoTitle}]");
            _logger.Debug($"Currently there are {totalExistingTodos} TODOs in the system. New TODO will be assigned with id {newTodoId}");
        }
        public void LogGetTodoCount(string state, int totalTodosReturned)
        {
            _logger.Info($"Total TODOs count for state {state} is {totalTodosReturned}");
        }
        public void LogGetTodoData(string filter, string sorting, int totalTodosInSystem, int totalReturnedTodos)
        {
            _logger.Info($"Extracting todos content. Filter: {filter} | Sorting by: {sorting}");
            _logger.Debug($"There are a total of {totalTodosInSystem} todos in the system. The result holds {totalReturnedTodos} todos");
        }
        public void LogUpdateTodoStatus(int todoId, string requestedState, string oldState, string newState,bool fError)
        {
            _logger.Info($"Update TODO id [{todoId}] state to {requestedState}");
            if(fError==false)
            {
            _logger.Debug($"Todo id [{todoId}] state change: {oldState} --> {newState}");
            }
        }
        public void LogDeleteTodo(int todoId, int totalRemainingTodos)
        {
            _logger.Info($"Removing todo id {todoId}");
            _logger.Debug($"After removing todo id [{todoId}] there are {totalRemainingTodos} TODOs in the system");
        }
        public void LogError(string errorMessage)
        {
            _logger.Error($"{errorMessage}");
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspWebApiServer
{
    public class Response
    {
        public object result        { get; set; }
        public string errorMessage  { get; set; }
        public Response(object _result, string _errorMessage)
        {
            result = _result;
            errorMessage = _errorMessage;
        }
        public Response()
        {
            result = "";
            errorMessage = "";
        }
    }
}

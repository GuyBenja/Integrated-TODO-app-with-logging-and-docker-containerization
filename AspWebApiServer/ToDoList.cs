using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspWebApiServer
{
    public class ToDoList
    {
        public List<ToDoItem> list { get; set; }
        public ToDoList()
        {
            list = new List<ToDoItem>();
        }
    }
}

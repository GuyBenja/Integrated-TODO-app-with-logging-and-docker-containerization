using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspWebApiServer
{

        public enum Status { PENDING, LATE, DONE }
    public class ToDoItem
    {
        public static int nextId = 1;

        public static string[] statusStr = { "PENDING", "LATE", "DONE" };
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public long dueDate { get; set; }
        public Status statusIndex { get; set; }
        public string status { get; set; }
        public ToDoItem(string _title, string _content, long _dueDate)
        {
            id = nextId;
            title = _title;
            content = _content;
            dueDate = _dueDate;
            statusIndex = Status.PENDING;
            status = statusStr[((int)statusIndex)];
            nextId++;
        }
    }
}

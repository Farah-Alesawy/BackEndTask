using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    internal class Task
    {
        public string title;
        public string description;
        public bool status;

        public Task(string title, string description)
        {
            this.title = title;
            this.description = description;
            status = false;
        }
    }
}

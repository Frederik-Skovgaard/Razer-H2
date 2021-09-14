using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Razer_H2.Modul
{
    public enum Priority { Low, Normal, High }

    public class ToDo : IToDo
    {
        //ToDo class felt
        public Guid ID { get; set; }

        public DateTime CreatedTime { get; set; }

        public string TaskDescription { get; set; }

        public Priority Priority { get; set; }

        public bool IsCompleted { get; set; }

        public ToDo()
        {
            ID = Guid.NewGuid();
            Priority = Priority.Normal;
            IsCompleted = false;
            CreatedTime = DateTime.UtcNow;
            TaskDescription = "";
        }
    }
}

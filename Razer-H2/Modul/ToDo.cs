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
        public int Todo_ID { get; set; }

        public DateTime CreatedTime { get; set; }

        public string TaskDescription { get; set; }

        public int Priority { get; set; }

        public bool IsCompleted { get; set; }

        public ToDo()
        {

        }
        public ToDo(int todo_id, int priority, bool iscompleted, DateTime createTime, string taskDescription )
        {
            Todo_ID = todo_id;
            Priority = priority;
            IsCompleted = iscompleted;
            CreatedTime = createTime;
            TaskDescription = taskDescription;
        }
    }
}

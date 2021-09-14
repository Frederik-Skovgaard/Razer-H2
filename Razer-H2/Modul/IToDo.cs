using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razer_H2.Modul
{
    public interface IToDo
    {
        Guid ID { get; set; }

        DateTime CreatedTime { get; set; }

        string TaskDescription { get; set; }

        Priority Priority { get; set; }

        bool IsCompleted { get; set; }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Razer_H2.Modul
{
    public enum Priority { Normal, Low, High}

    public class ToDo
    {
        //ToDo class felt
        public Guid ID { get; set; }

        public DateTime CreatedTime { get; set; }

        public string TaskDescription { get; set; }

        public Priority Priority { get; set; }

        public bool IsCompleted { get; set; }



        /// <summary>
        /// Constructor for making a ToDo item
        /// </summary>
        /// <param name="desc"></param>
        /// <param name="check"></param>
        /// <param name="_priority"></param>
        public ToDo(string desc)
        {
            ID = Guid.NewGuid();
            Priority = Priority.Normal;

            CreatedTime = DateTime.Now;
            TaskDescription = desc;
            IsCompleted = false;
        }
    }
}

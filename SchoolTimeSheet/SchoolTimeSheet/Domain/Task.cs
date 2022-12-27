﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeSheet.Domain
{
    internal class Task
    {
        public string Name { get; set; }
        public TaskType Type { get; set; }
        public DateOnly EndDate { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}

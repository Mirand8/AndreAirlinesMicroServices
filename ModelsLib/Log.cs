﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLib
{
    public class Log
    {
        public string Id { get; set; }
        public User User { get; set; }
        public string InitialEntity { get; set; }
        public string FinalEntity { get; set; }
        public string Operation { get; set; }
        public DateTime Date { get; set; }
    }
}

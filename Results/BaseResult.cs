﻿using EpochHive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpochHive.Results
{
    public class BaseResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
    }
}

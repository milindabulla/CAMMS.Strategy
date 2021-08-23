﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMMS.Strategy.Application
{
    public class CacheSettings
    {
        public string Uri { get; set; }
        public int SlidingExpirationInMin { get; set; }
        public int AbsoluteExpirationInMin { get; set; }
        public bool BypassCache { get; set; }
    }
}

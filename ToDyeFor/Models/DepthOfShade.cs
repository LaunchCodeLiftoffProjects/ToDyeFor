﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDyeFor.Models
{
    public enum DepthOfShade
    { //will not take perentage ammounts may need to change from enum to something else
        Pastel, //.25-.5%
        Pale, //1-2%
        Light, //3%
        Medium, //4%
        Full, //5%
        Deep, //6%
        Dark, //7%
        Black //8%
    }
}

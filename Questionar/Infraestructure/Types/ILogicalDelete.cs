﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Types
{
    public interface ILogicalDelete
    {
        bool Active { get; set; }
    }
}

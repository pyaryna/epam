﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns
{
    public interface IRandomGuidProvider
    {
        Guid RandomGuid { get; }
    }
}

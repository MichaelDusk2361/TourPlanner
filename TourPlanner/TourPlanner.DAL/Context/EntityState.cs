﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.DAL.Context {
    public enum EntityState {
        Unchanged,
        Added,
        Deleted,
        Modified
    }
}

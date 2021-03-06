﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oncology.Model
{
    public interface IIdentity<T>
    {
        int Id { get; set; }
        void UpdatePropertiesFrom(T that);
    }
}

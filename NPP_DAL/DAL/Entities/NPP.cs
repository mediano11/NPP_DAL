﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class NPP
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string ContactPhone { get; set; }

        public IEnumerable<Employee> Employees { get; set; }
    }
}

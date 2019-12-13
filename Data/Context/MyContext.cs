﻿using Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class MyContext :DbContext
    {
        public MyContext() : base("MyContext") { }
        public DbSet<Supplier>Suppliers { get; set; }
    }
}

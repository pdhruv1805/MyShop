﻿using MyShhop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShhop.DataAccess.SQL
{
    public class DataContext:DbContext
    {
        public DataContext()
            : base("DefaultConnection") { }

        public DbSet<Product> products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }

}

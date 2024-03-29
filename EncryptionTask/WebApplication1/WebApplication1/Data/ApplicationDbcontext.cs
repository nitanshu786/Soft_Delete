﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Data
{
    public class ApplicationDbcontext:DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> Option):base(Option)
        {

        }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}

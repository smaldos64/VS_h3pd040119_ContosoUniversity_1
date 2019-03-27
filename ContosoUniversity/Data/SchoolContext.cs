﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.ViewModels;

namespace ContosoUniversity.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext (DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<ContosoUniversity.Models.Student> Student { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<ContosoUniversity.ViewModels.StudentVM> StudentVM { get; set; }
        //public DbSet<ContosoUniversity.ViewModels.StudentVM> StudentVM { get; set; }
    }
}

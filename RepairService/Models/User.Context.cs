﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RepairService.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RepairServiceEntities : DbContext
    {
        public RepairServiceEntities()
            : base("name=RepairServiceEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Technician> Technicians { get; set; }
        public virtual DbSet<tbl_Admin> tbl_Admin { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Problem> Problems { get; set; }
        public virtual DbSet<AssignProblem> AssignProblems { get; set; }
    }
}
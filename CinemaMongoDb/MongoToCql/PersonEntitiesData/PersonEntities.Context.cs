﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PersonEntitiesData
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CinameNetworkEntities : DbContext
    {
        public CinameNetworkEntities()
            : base("name=CinameNetworkEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cinemas> Cinemas { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Genders> Genders { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Shows> Shows { get; set; }
        public virtual DbSet<Towns> Towns { get; set; }
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ezvax.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HospitalEntities : DbContext
    {
        public HospitalEntities()
            : base("name=HospitalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Clinica> Clinica { get; set; }
        public virtual DbSet<Comentariu> Comentariu { get; set; }
        public virtual DbSet<Postare> Postare { get; set; }
        public virtual DbSet<ProfilMedical> ProfilMedical { get; set; }
        public virtual DbSet<Programare> Programare { get; set; }
        public virtual DbSet<Resurse> Resurse { get; set; }
        public virtual DbSet<Simptome> Simptome { get; set; }
        public virtual DbSet<Stoc> Stoc { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Vaccin> Vaccin { get; set; }
    }
}

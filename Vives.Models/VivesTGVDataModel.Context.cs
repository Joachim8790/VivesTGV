﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vives.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class VivesTGVEntities : DbContext
    {
        public VivesTGVEntities()
            : base("VivesTGVEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<tblBestellijn> tblBestellijn { get; set; }
        public virtual DbSet<tblBestelling> tblBestelling { get; set; }
        public virtual DbSet<tblGebruiker> tblGebruiker { get; set; }
        public virtual DbSet<tblHotel> tblHotel { get; set; }
        public virtual DbSet<tblProduct> tblProduct { get; set; }
        public virtual DbSet<tblStad> tblStad { get; set; }
        public virtual DbSet<tblTraject> tblTraject { get; set; }
        public virtual DbSet<tblTreinplaats> tblTreinplaats { get; set; }
        public virtual DbSet<tblTussenlocatie> tblTussenlocatie { get; set; }
        public virtual DbSet<tblWinkelmandlijn> tblWinkelmandlijn { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<database_firewall_rules> database_firewall_rules { get; set; }
        public virtual DbSet<C__MigrationHistory1> C__MigrationHistory1Set { get; set; }
        public virtual DbSet<database_firewall_rules1> database_firewall_rules1 { get; set; }
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ArtlyV1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ArtlyDatabaseEntities : DbContext
    {
        public ArtlyDatabaseEntities()
            : base("name=ArtlyDatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<LtGender> LtGenders { get; set; }
        public virtual DbSet<LtProductCategory> LtProductCategories { get; set; }
        public virtual DbSet<LtProductType> LtProductTypes { get; set; }
        public virtual DbSet<LtRole> LtRoles { get; set; }
        public virtual DbSet<MsProduct> MsProducts { get; set; }
        public virtual DbSet<MsUser> MsUsers { get; set; }
        public virtual DbSet<TrUserAddress> TrUserAddresses { get; set; }
    }
}

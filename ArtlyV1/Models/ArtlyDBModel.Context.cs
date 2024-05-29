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
    using ArtlyV1.Repository;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;

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
        public virtual DbSet<LtPaymentMethod> LtPaymentMethods { get; set; }
        public virtual DbSet<LtProductCategory> LtProductCategories { get; set; }
        public virtual DbSet<LtProductType> LtProductTypes { get; set; }
        public virtual DbSet<LtRole> LtRoles { get; set; }
        public virtual DbSet<LtStatu> LtStatus { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<MsProduct> MsProducts { get; set; }
        public virtual DbSet<MsTransaction> MsTransactions { get; set; }
        public virtual DbSet<MsUser> MsUsers { get; set; }
        public virtual DbSet<TopUp> TopUps { get; set; }
        public virtual DbSet<TransactionDetail> TransactionDetails { get; set; }
        public virtual DbSet<TrUserAddress> TrUserAddresses { get; set; }

        public IQueryable<T> ActiveEntities<T>() where T : class
        {
            var query = Set<T>().AsQueryable();
            var parameter = Expression.Parameter(typeof(T), "e");
            var property = typeof(T).GetProperty("IsActive");

            if (property != null)
            {
                // If IsActive is nullable, we need to handle the conversion
                var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                var constant = Expression.Constant(true, property.PropertyType);

                Expression equality;
                if (property.PropertyType == typeof(bool?))
                {
                    var hasValue = Expression.Property(propertyAccess, "HasValue");
                    var value = Expression.Property(propertyAccess, "Value");
                    var notNull = Expression.Equal(hasValue, Expression.Constant(true));
                    var equalsTrue = Expression.Equal(value, Expression.Constant(true));
                    equality = Expression.AndAlso(notNull, equalsTrue);
                }
                else
                {
                    equality = Expression.Equal(propertyAccess, constant);
                }

                var lambda = Expression.Lambda<Func<T, bool>>(equality, parameter);
                query = query.Where(lambda);
            }

            return query;
        }
    }
}

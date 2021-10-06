﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AclaimDataConnectionChallenge
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class AdventureWorksLT2016Entities : DbContext
    {
        public AdventureWorksLT2016Entities()
            : base("name=AdventureWorksLT2016Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductDescription> ProductDescriptions { get; set; }
        public virtual DbSet<ProductModel> ProductModels { get; set; }
        public virtual DbSet<ProductModelProductDescription> ProductModelProductDescriptions { get; set; }
        public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
        public virtual DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }
        public virtual DbSet<BuildVersion> BuildVersions { get; set; }
        public virtual DbSet<vwGetProductOrderInfo> vwGetProductOrderInfoes { get; set; }
        public virtual DbSet<vGetAllCategory> vGetAllCategories { get; set; }
        public virtual DbSet<vProductAndDescription> vProductAndDescriptions { get; set; }
        public virtual DbSet<vProductModelCatalogDescription> vProductModelCatalogDescriptions { get; set; }
    
        [DbFunction("AdventureWorksLT2016Entities", "ufnGetAllCategories")]
        public virtual IQueryable<ufnGetAllCategories_Result> ufnGetAllCategories()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<ufnGetAllCategories_Result>("[AdventureWorksLT2016Entities].[ufnGetAllCategories]()");
        }
    
        [DbFunction("AdventureWorksLT2016Entities", "ufnGetCustomerInformation")]
        public virtual IQueryable<ufnGetCustomerInformation_Result> ufnGetCustomerInformation(Nullable<int> customerID)
        {
            var customerIDParameter = customerID.HasValue ?
                new ObjectParameter("CustomerID", customerID) :
                new ObjectParameter("CustomerID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<ufnGetCustomerInformation_Result>("[AdventureWorksLT2016Entities].[ufnGetCustomerInformation](@CustomerID)", customerIDParameter);
        }
    
        public virtual ObjectResult<GetCustomerPurchaseData_Result> GetCustomerPurchaseData(string userFilter, Nullable<decimal> amountAbove, Nullable<decimal> amountBelow)
        {
            var userFilterParameter = userFilter != null ?
                new ObjectParameter("userFilter", userFilter) :
                new ObjectParameter("userFilter", typeof(string));
    
            var amountAboveParameter = amountAbove.HasValue ?
                new ObjectParameter("amountAbove", amountAbove) :
                new ObjectParameter("amountAbove", typeof(decimal));
    
            var amountBelowParameter = amountBelow.HasValue ?
                new ObjectParameter("amountBelow", amountBelow) :
                new ObjectParameter("amountBelow", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetCustomerPurchaseData_Result>("GetCustomerPurchaseData", userFilterParameter, amountAboveParameter, amountBelowParameter);
        }
    
        public virtual int uspLogError(ObjectParameter errorLogID)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspLogError", errorLogID);
        }
    
        public virtual int uspPrintError()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspPrintError");
        }
    }
}
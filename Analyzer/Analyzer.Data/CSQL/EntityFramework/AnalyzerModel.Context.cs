﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Analyzer.Data.CSQL.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AnalyzerDBContext : DbContext
    {
        public AnalyzerDBContext()
            : base("name=AnalyzerDBContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<T_Price> T_Price { get; set; }
        public virtual DbSet<T_EPS> T_EPS { get; set; }
        public virtual DbSet<T_EPS_Audited> T_EPS_Audited { get; set; }
    }
}
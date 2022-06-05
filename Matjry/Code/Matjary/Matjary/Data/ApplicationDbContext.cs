using System;
using System.Collections.Generic;
using System.Text;
using Matjary.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Matjary.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Invoices> Invoices { get; set; }
        public virtual DbSet<InvoicesProducts> InvoicesProducts { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderProduct> OrderProduct { get; set; }
        public virtual DbSet<Owner> Owner { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<ProductPersons> ProductPersons { get; set; }
        public virtual DbSet<ProductPhoto> ProductPhoto { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Quotations> Quotations { get; set; }
        public virtual DbSet<QuotationsProducts> QuotationsProducts { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<VatTable> VatTable { get; set; }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.seed();
        //}

    }
}


using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using KangtingBiz.Domain.Models;
using KangtingBiz.Infrastructure.Context.ModelConfiguration;

namespace KangtingBiz.Infrastructure.Context
{
    public partial class KangtingContext : DbContext
    {
        public KangtingContext()
            : base("name=KangtingConn")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OrderLine> OrderLines { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<ProductHolding> ProductHoldings { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductTransaction> ProductTransactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new PHConfiguration());
            modelBuilder.Configurations.Add(new PTConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new OrderLineConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());

            
        }
    }
}

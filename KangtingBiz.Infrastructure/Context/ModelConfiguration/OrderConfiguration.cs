using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KangtingBiz.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace KangtingBiz.Infrastructure.Context.ModelConfiguration
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            this.ToTable("Orders");

            this.HasKey(p => p.EntityId).
                 Property(p => p.EntityId).
                 HasColumnName("OrderID");        


            //Addressinfo
            this.Property(e => e.Address.City).
                HasColumnName("City");
            this.Property(e => e.Address.AddressLine).
                          HasColumnName("AddressLine");
            this.Property(e => e.Address.Dist).
                          HasColumnName("Dist");
            this.Property(e => e.Address.PostalCode).
              HasColumnName("PostalCode");

            this.HasRequired<Customer>(o=>o.Customer).
                WithMany(c=>c.Orders).
                HasForeignKey<int>(o => o.CustomerID);

            this.HasMany<OrderLine>(o => o.OrderLines).
                WithRequired(ol => ol.Order).
                HasForeignKey<int>(ol => ol.OrderID);



        }
    }
}

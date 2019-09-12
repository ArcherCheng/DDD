using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KangtingBiz.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace KangtingBiz.Infrastructure.Context.ModelConfiguration
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            this.ToTable("Customers");
            this.HasKey(p => p.EntityId).
                 Property(p => p.EntityId).
                 HasColumnName("CustomerID");
             
            //Addressinfo
            this.Property(e => e.Address.City).
                HasColumnName("City");
            this.Property(e => e.Address.AddressLine).
                          HasColumnName("AddressLine");
            this.Property(e => e.Address.Dist).
                          HasColumnName("Dist");
            this.Property(e => e.Address.PostalCode).
              HasColumnName("PostalCode");         

            this.HasMany<Order>(c => c.Orders).
                WithRequired(o => o.Customer).
                HasForeignKey<int>(o => o.CustomerID); 
        }
    }
}

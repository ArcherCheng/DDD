using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KangtingBiz.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace KangtingBiz.Infrastructure.Context.ModelConfiguration
{
    public class OrderLineConfiguration : EntityTypeConfiguration<OrderLine>
    {
        public OrderLineConfiguration()
        {
            this.ToTable("OrderLines");           
            this.HasKey(e => e.EntityId).
                 Property(e => e.EntityId).
                 HasColumnName("OrderLineID");

            this.HasKey(p => new { p.EntityId, p.OrderID });

            this.HasRequired(ol => ol.Product).WithMany().HasForeignKey(ol => ol.ProductID);

            this.HasRequired(ol => ol.Order).
                WithMany().
                HasForeignKey(ol => ol.OrderID);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KangtingBiz.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace KangtingBiz.Infrastructure.Context.ModelConfiguration
{
    public class PHConfiguration : EntityTypeConfiguration<ProductHolding>
    {

        public PHConfiguration()
        {
            this.ToTable("ProductHoldings");

            this.HasKey(p => p.EntityId).
                 Property(p => p.EntityId).
                 HasColumnName("ProductHoldingID");

                



            //     this.HasRequired(ph => ph.Product)
            //.WithOptional(p => p.ProductHolding)
            //.Map(m => m.MapKey("ProductHoldingID"));

            //    builder
            //              .HasOne(p => p.Prospect)
            //              .WithOne()
            //              .HasForeignKey<ProspectDto>(pe => pe.ID);
        }
    }
}

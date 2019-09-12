using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KangtingBiz.Domain.Models;
using System.Data.Entity.ModelConfiguration;


namespace KangtingBiz.Infrastructure.Context.ModelConfiguration
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            this.ToTable("Products");

            this.HasKey(p => p.EntityId).
                 Property(p => p.EntityId).
                 HasColumnName("ProductID");

            this.Property(p => p.ProductName).IsRequired()   ;
            this.Property(p => p.UnitPrice).IsRequired() ;

            this.HasOptional(p => p.Category).WithMany().HasForeignKey(p => p.CategoryID);
            this.HasOptional(p => p.ProductHolding).WithRequired(p => p.Product);

            //            builder.Entity<AccountGroup>()
            //.HasOptional(x => x.User)
            //.WithMany()
            //.Map(m => m.MapKey("ModifiedBy"));




        }

    }
}

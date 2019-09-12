using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KangtingBiz.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace KangtingBiz.Infrastructure.Context.ModelConfiguration
{
    public class PTConfiguration : EntityTypeConfiguration<ProductTransaction>
    {
        public PTConfiguration()
        {
            this.ToTable("ProductTransactions");

            this.HasKey(p => p.EntityId).
                 Property(p => p.EntityId).
                 HasColumnName("ProductTransactionID");
        }
    }
}

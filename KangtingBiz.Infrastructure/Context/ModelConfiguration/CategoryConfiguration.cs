using KangtingBiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KangtingBiz.Infrastructure.Context.ModelConfiguration
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            this.ToTable("Categories");
            this.HasKey(p => p.EntityId).
                 Property(p => p.EntityId).
                 HasColumnName("CategoryID");
        }
    }
}

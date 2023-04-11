using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Configurations
{
    internal class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200); // zorunlu alan ve max 50 
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(15,3)"); // toplam 15, virgülden sonra 3 karakter = 12,3 gibi

            builder.ToTable("Products");

            builder.HasOne(x=> x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId); // there is a one to many relationship therefore, we specified to categortID value as a foreign key
        }
    }
}

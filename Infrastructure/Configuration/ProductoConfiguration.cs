
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class ProductoConfiguration: IEntityTypeConfiguration<Producto>
{
public void Configure(EntityTypeBuilder<Producto> builder)
{
    throw new NotImplementedException();
}
}

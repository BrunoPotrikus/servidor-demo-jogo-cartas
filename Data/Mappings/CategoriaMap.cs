using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServidorDemoJogoCartas.Models;

namespace ServidorDemoJogoCartas.Data.Mappings
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo)
                .IsRequired()
                .HasColumnName("Titulo")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Simbolo)
                .IsRequired()
                .HasColumnName("Simbolo")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(1024);

            builder.HasIndex(x => x.Titulo, "IX_Categoria_Titulo")
                .IsUnique();
        }
    }
}

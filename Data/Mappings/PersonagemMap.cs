using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServidorDemoJogoCartas.Models;

namespace ServidorDemoJogoCartas.Data.Mappings
{
    public class PersonagemMap : IEntityTypeConfiguration<Personagem>
    {
        public void Configure(EntityTypeBuilder<Personagem> builder)
        {
            builder.ToTable("Personagem");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Magia)
                .IsRequired()
                .HasColumnName("Magia")
                .HasColumnType("INT");

            builder.Property(x => x.Forca)
                .IsRequired()
                .HasColumnName("Forca")
                .HasColumnType("INT");

            builder.Property(x => x.Fogo)
                .IsRequired()
                .HasColumnName("Fogo")
                .HasColumnType("INT");

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnName("Descricao")
                .HasColumnType("TEXT");

            builder.HasOne(x => x.Categoria)
                .WithMany(x => x.Personagens)
                .HasConstraintName("FK_Personagem_Categoria")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

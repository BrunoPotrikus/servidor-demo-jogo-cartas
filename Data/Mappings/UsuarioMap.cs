using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServidorDemoJogoCartas.Models;

namespace ServidorDemoJogoCartas.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(60);

            builder.Property(x => x.Sobrenome)
                .IsRequired()
                .HasColumnName("Sobrenome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(60);

            builder.Property(x => x.Apelido)
                .IsRequired()
                .HasColumnName("Apelido")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(60);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(60);

            builder.Property(x => x.Senha)
                .IsRequired()
                .HasColumnName("Senha")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(16);

            builder.HasMany(x => x.Personagens)
                .WithMany(x => x.Usuarios)
                .UsingEntity<Dictionary<string, object>>(
                    "UsuarioPersonagem",
                    usuario => usuario.HasOne<Personagem>()
                    .WithMany()
                    .HasForeignKey("UsuarioId")
                    .HasConstraintName("FK_UsuarioPersonagem_UsuarioId"),
                    personagem => personagem.HasOne<Usuario>()
                    .WithMany()
                    .HasForeignKey("PersonagemId")
                    .HasConstraintName("FK_UsuarioPersonagem_PersoangemId")
                );   
        }
    }
}

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

            builder.Property(x => x.Nome.NomeUsuario)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(60);

            builder.Property(x => x.Nome.Sobrenome)
                .IsRequired()
                .HasColumnName("Sobrenome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(60);

            builder.Property(x => x.Nome.Apelido)
                .IsRequired()
                .HasColumnName("Apelido")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(60);

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

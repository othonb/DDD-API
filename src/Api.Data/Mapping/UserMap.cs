using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
  public class UserMap : IEntityTypeConfiguration<UserEntity>
  {
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        // Nome da tabela
        builder.ToTable("User");

        // Chave primária
        builder.HasKey(u => u.Id);

        // Índice
        builder.HasIndex(u => u.Email).IsUnique();

        // Campo obrigatório com tamanho máximo igual a 100 caracteres
        builder.Property(u => u.Name).IsRequired().HasMaxLength(100);

        // Email é um campo com tamanho máximo de 100 caracteres
        builder.Property(u => u.Email).HasMaxLength(100);

    }
  }
}
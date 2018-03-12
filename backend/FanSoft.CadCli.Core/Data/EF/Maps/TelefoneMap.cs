using FanSoft.CadCli.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FanSoft.CadCli.Core.Data.EF.Maps
{
    public class TelefoneMap : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.ToTable(nameof(Telefone));

            builder
                .HasKey(k => k.Id);

            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Numero)
               .HasColumnType("varchar(11)")
               .IsRequired();

            builder.HasOne(col => col.Cliente)
                .WithMany(col => col.Telefones)
                .HasForeignKey(fk=>fk.ClienteId);

        }
    }
}

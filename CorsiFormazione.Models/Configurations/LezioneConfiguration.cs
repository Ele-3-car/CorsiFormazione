using CorsiFormazione.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsiFormazione.Models.Configurations
{
    public class LezioneConfiguration : IEntityTypeConfiguration<Lezione>
    {
        public void Configure(EntityTypeBuilder<Lezione> builder)
        {
            builder.ToTable("CalendarioLezioni");
            builder.HasKey(k => new { k.NomeCorso, k.DataOraInizio});
            builder.Property(p => p.Erogazione)
                .HasColumnName("ModoErogazione")
                .HasConversion<string>();
            builder.HasOne(k => k.CorsoAssociato)
                .WithMany(k => k.Lezioni)
                .HasForeignKey(k => k.NomeCorso);
        }
    }
}

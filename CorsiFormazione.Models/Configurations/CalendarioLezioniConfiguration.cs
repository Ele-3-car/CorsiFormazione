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
    internal class CalendarioLezioniConfiguration : IEntityTypeConfiguration<CalendarioLezioni>
    {
        public void Configure(EntityTypeBuilder<CalendarioLezioni> builder)
        {
            builder.ToTable("CalendarioLezioni");
            builder.HasKey(k => new { k.DataOraFine, k.DataOraInizio });
            builder.Property(p => p.Erogazione)
                .HasColumnName("ModoErogazione")
                .HasConversion<string>();
            /*builder.Property(p => p.DataOraInizio)
                .HasColumnName("DataOraInizio");
            builder.Property(p => p.DataOraFine)
                .HasColumnName("DataOraFine");*/
        }
    }
}

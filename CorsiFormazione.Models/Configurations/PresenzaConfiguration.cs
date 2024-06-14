﻿using CorsiFormazione.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsiFormazione.Models.Configurations
{
    public class PresenzaConfiguration : IEntityTypeConfiguration<Presenza>
    {
        public void Configure(EntityTypeBuilder<Presenza> builder)
        {
            builder.ToTable("Presenza");
            builder.HasKey(k => new { k.NomeAlunno, k.CognomeAlunno });
            builder.Property(p => p.Ingrezzo)
                .HasColumnName("DataOraIngresso");
            builder.Property(p => p.Uscita)
                .HasColumnName("DataOraUscita");
        }
    }
}

using CorsiFormazione.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsiFormazione.Models.Context
{
    public class MyDbContext : DbContext
    {
        public DbSet<Utente> Utenti { get; set; }
        public DbSet<Corso> Corsi { get; set; }
        public DbSet<Docente> Docenti { get; set; }
        public DbSet<Lezione> Lezioni { get; set; }
        public DbSet<Presenza> Presenze { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> config) : base(config) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

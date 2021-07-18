using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebAPI_HiriartCorales.Models
{
    public partial class AgendaPersonal : DbContext
    {
        public AgendaPersonal()
            : base("name=AgendaPersonal")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Contactoes> Contactoes { get; set; }
        public virtual DbSet<Diarios> Diarios { get; set; }
        public virtual DbSet<Eventoes> Eventoes { get; set; }
        public virtual DbSet<ListaContactoes> ListaContactoes { get; set; }
        public virtual DbSet<ListaEventoes> ListaEventoes { get; set; }
        public virtual DbSet<Memos> Memos { get; set; }
        public virtual DbSet<Notificacions> Notificacions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contactoes>()
                .HasMany(e => e.Eventoes)
                .WithOptional(e => e.Contactoes)
                .HasForeignKey(e => e.Contacto_ContactoID);

            modelBuilder.Entity<ListaContactoes>()
                .HasMany(e => e.Eventoes)
                .WithOptional(e => e.ListaContactoes)
                .HasForeignKey(e => e.ListaContacto_ListaContactoID);

            modelBuilder.Entity<ListaEventoes>()
                .HasMany(e => e.Diarios)
                .WithOptional(e => e.ListaEventoes)
                .HasForeignKey(e => e.ListaEvento_ListaEventoID);
        }
    }
}

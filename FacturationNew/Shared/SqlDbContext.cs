
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturation.Shared
{
    public class SqlDbContext : DbContext
    {

        public SqlDbContext(DbContextOptions<SqlDbContext> options)
           : base(options)
        {
        }
        public DbSet<Facture> Facture { get; set; }
        /*public DbSet<ChiffreAffaire> ChiffreAffaire { get; set; }*/

        // Insertion de donnée dans la database au lancement de la migration (création) de la database
        // Est donc executé une seule fois, avec la commande "Add-Migration 'NomMigration'"
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Facture>().HasData(new Facture
            {
                id = 3,
                code = "F666",
                client = "John Test",
                dateEmission = new DateTime(2021, 01, 25),
                montantDu = 666
            });
            modelBuilder.Entity<Facture>().HasData(new Facture
            {
                id = 1,
                code = "F001",
                client = "John Cologne",
                dateEmission = new DateTime(2018, 02, 10),
                dateReglement = new DateTime(2018, 04, 25),
                montantDu = 15535,
                montantRegle = 15535
            });
        }
    }
}
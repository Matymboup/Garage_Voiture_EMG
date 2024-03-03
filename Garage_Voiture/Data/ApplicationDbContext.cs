using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Garage_Voiture.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Garage_Voiture.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Marque> Marques { get; set; }
        public DbSet<Modele> Modeles { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Voiture> Voiture { get; set; } = default!;
        public DbSet<Repair> Reparations { get; set; }
      

    }
}

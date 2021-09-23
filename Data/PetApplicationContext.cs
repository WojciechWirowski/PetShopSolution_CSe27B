using Czikoroko.Wojciech.PetShop.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Czikoroko.Wojciech.PetShop.Data
{
    public class PetApplicationContext : DbContext
    {
        public PetApplicationContext(DbContextOptions<PetApplicationContext> opt) : base(opt)
        {
        }

        public DbSet<PetEntity> Pets { get; set; }
        public DbSet<PetTypeEntity> PetTypes { get; set; }
        public DbSet<OwnerEntity> Owners { get; set; }
    }
}
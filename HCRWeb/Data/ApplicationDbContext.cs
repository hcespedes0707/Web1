using HCRWeb.Model;
using Microsoft.EntityFrameworkCore;

namespace HCRWeb.Data
{
    public class ApplicationDbContext :DbContext
    {
       

        public virtual DbSet<Usuario> Usuario { set; get; }

        public virtual DbSet<Imagen> Imagen { set; get; }

        public virtual DbSet<Pelicula> Pelicula { set; get; }


        public ApplicationDbContext( DbContextOptions options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

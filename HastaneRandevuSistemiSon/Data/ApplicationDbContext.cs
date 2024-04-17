using HastaneRandevuSistemiSon.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HastaneRandevuSistemiSon.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Birim> Birims
        {
            get;
            set;
        }
        public DbSet<Doktor> Doktors
        {
            get;
            set;
        }
        public DbSet<Hasta> Hastas
        {
            get;
            set;
        }
        public DbSet<Hastalik> Hastaliks
        {
            get;
            set;
        }
        public DbSet<Poliklinik> Polikliniks
        {
            get;
            set;
        }
        public DbSet<Randevu> Randevus
        {
            get;
            set;
        }
    }
}
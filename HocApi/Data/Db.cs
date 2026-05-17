using HocApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HocApi.Data
{
    public class Db : DbContext
    {
        public Db(DbContextOptions<Db> options) : base(options)
        {
        }
        public DbSet<Product> Products {  get; set; }
    }
}

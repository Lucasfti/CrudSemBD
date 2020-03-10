using CrudSemBD.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CrudSemBD.Context
{
    public class DBCrud : DbContext
    {
        public DBCrud() : base("BancoSQL")
        {

        }

        public DbSet<PessoaModel> Pessoas { get; set; }
        public DbSet<SexoModel> Sexos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
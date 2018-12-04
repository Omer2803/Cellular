using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Cellular.Common.Models;

namespace Cellular.MainDal
{
    public class CellularDbContext : DbContext
    {
        public CellularDbContext() : base("name=Cellular")
        {
            Database.SetInitializer(new CellularDbContextInitializer());
        }

        public virtual DbSet<Client> Clients{ get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Line> Lines{ get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Call> Calls{ get; set; }
        public virtual DbSet<SMS> SMSes{ get; set; }
        public virtual DbSet<ClientType> ClientTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Line>()
               .HasKey(l => l.PhoneNumber);

            modelBuilder.Entity<Client>()
                .HasKey(c => c.Id)
                .Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<Employee>()
                .HasKey(e => e.Id)
                .Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
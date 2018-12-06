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

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Line> Lines { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Call> Calls { get; set; }
        public virtual DbSet<SMS> SMSes { get; set; }
        public virtual DbSet<ClientType> ClientTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Line>()
               .HasKey(l => l.PhoneNumber);

            var clients = modelBuilder.Entity<Client>();
            clients
                .HasKey(c => c.Id)
                .HasRequired(c => c.Registrator)
                .WithMany()
                .HasForeignKey(c => c.RegisteredBy);

            clients.Property(c => c.Id)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<Employee>()
                .HasKey(e => e.Id)
                .Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            var smses = modelBuilder.Entity<SMS>();
            smses
                .HasRequired(s => s.Sender)
                .WithMany()
                .HasForeignKey(s => s.SenderNumber)
                .WillCascadeOnDelete(false);
            smses
                .HasRequired(s => s.Dest)
                .WithMany()
                .HasForeignKey(s => s.DestinationNumber)
                .WillCascadeOnDelete(false);

            var calls = modelBuilder.Entity<Call>();
            calls
                .HasRequired(c => c.Caller)
                .WithMany()
                .HasForeignKey(c => c.CallerNumber)
                .WillCascadeOnDelete(false);
            calls
                .HasRequired(c => c.Dest)
                .WithMany()
                .HasForeignKey(c => c.DestinationNumber)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Package>()
                .HasRequired(p => p.Line)
                .WithMany()
                .HasForeignKey(p => p.LineNumber)
                .WillCascadeOnDelete();
        }
    }
}
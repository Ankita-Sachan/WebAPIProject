using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ClientApplication.Models.Mapping;

namespace ClientApplication.Models
{
    public partial class SampleContext : DbContext
    {
        static SampleContext()
        {
            Database.SetInitializer<SampleContext>(null);
        }

        public SampleContext()
            : base("Name=SampleContext")
        {
        }

        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Contact1> Contacts1 { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AspNetRoleMap());
            modelBuilder.Configurations.Add(new AspNetUserClaimMap());
            modelBuilder.Configurations.Add(new AspNetUserLoginMap());
            modelBuilder.Configurations.Add(new AspNetUserMap());
            modelBuilder.Configurations.Add(new ClientMap());
            modelBuilder.Configurations.Add(new ContactMap());
            modelBuilder.Configurations.Add(new Contact1Map());
            modelBuilder.Configurations.Add(new EmployeeMap());
        }
    }
}

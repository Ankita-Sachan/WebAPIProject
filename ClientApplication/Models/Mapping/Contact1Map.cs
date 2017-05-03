using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClientApplication.Models.Mapping
{
    public class Contact1Map : EntityTypeConfiguration<Contact1>
    {
        public Contact1Map()
        {
            // Primary Key
            this.HasKey(t => t.ContactID);

            // Properties
            this.Property(t => t.FirstName)
                .IsRequired();

            this.Property(t => t.LastName)
                .IsRequired();

            this.Property(t => t.EmailId)
                .IsRequired();

            this.Property(t => t.Phoneno)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Contacts");
            this.Property(t => t.ContactID).HasColumnName("ContactID");
            this.Property(t => t.ClientID).HasColumnName("ClientID");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.EmailId).HasColumnName("EmailId");
            this.Property(t => t.Phoneno).HasColumnName("Phoneno");
            this.Property(t => t.Age).HasColumnName("Age");

            // Relationships
            this.HasRequired(t => t.Client)
                .WithMany(t => t.Contacts)
                .HasForeignKey(d => d.ClientID);

        }
    }
}

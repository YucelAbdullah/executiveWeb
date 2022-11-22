using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace executiveData
{
    public class Customer : EntityBase
    {
        public string Name { get; set; }
        public string? AuthorizedPerson { get; set; }

        public int PhoneNumber { get; set; }

        public virtual ICollection<Project> Projects { get; set; } = new HashSet<Project>();

    }
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {

            builder
                .HasMany(p => p.Projects)
                .WithOne(p => p.Customer)
                .HasForeignKey(p => p.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        }




    }
}

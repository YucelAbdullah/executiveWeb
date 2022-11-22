using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace executiveData
{
    public class Address : EntityBase
    {
        public Guid ApplicationUserId { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Project> Projects { get; set; } = new HashSet<Project>();


    }

    public class AddressEntityTypeConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {

            builder
                .HasMany(p => p.Projects)
                .WithOne(p => p.Address)
                .HasForeignKey(p => p.AddressId)
                .OnDelete(DeleteBehavior.Cascade);
        }




    }
}


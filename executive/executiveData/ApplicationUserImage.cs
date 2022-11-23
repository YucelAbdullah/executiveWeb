

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace executiveData
{
    public class ApplicationUserImage:EntityBase
    {

        public Guid ApplicationUserId { get; set; }
        public byte[]? Image { get; set; }

        public virtual ApplicationUser? ApplicationUser { get; set; }

        public class ApplicationUserImageEntityTypeConfiguration : IEntityTypeConfiguration<ApplicationUserImage>
        {
            public void Configure(EntityTypeBuilder<ApplicationUserImage> builder)
            {
                builder
                    .Property(p => p.Image)
                    .IsRequired();
            }
        }
    }
}

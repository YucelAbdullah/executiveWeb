
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace executiveData
{
    public class ProjectImage
    {
        public Guid ProjectId { get; set; }
        public byte[] Image { get; set; }


        public virtual Project? Project { get; set; }

        public class ProductImageEntityTypeConfiguration : IEntityTypeConfiguration<ProjectImage>
        {
            public void Configure(EntityTypeBuilder<ProjectImage> builder)
            {
                builder
                    .Property(p => p.Image)
                    .IsRequired();
            }
        }
    }
}

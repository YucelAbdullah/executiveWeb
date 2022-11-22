using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Xml.Linq;

namespace executiveData
{
    public enum Genders
    {
        [Display(Name = "Erkek")]
        Male,
        [Display(Name = "Kadın")]
        Female
    }
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public Genders? Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime JobStartDate { get; set; }
        public DateTime LeavingDate { get; set; }


        public virtual ICollection<ApplicationUserImage> ApplicationUserImages { get; set; } = new HashSet<ApplicationUserImage>();

        public virtual ICollection<Project> Projects { get; set; } = new HashSet<Project>();

    }
    public class ApplicationUserEntityTypeConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {

            builder
                 .HasMany(p => p.ApplicationUserImages)
                 .WithOne(p => p.ApplicationUser)
                 .HasForeignKey(p => p.ApplicationUserId)
                 .OnDelete(DeleteBehavior.Cascade);





        }
    }
}
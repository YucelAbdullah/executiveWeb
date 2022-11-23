using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace executiveData
{

    public enum ProjectStatus
    {
        New, Canceled, OnProgress, Finished
    }
    public class Project : EntityBase
    {
        [Display(Name = "Ad")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        public int ClosedArea { get; set; }

        public ProjectStatus Status { get; set; }

        public Guid CustomerId { get; set; }

        [Display(Name = "Açıklamalar")]
        [DataType(DataType.MultilineText)]
        public string? Descriptions { get; set; }

        public DateTime? Deadline { get; set; }


        public Guid AddressId { get; set; }
        public virtual Address? Address { get; set; }
        public virtual Customer Customer { get; set; }


        //[NotMapped]

        //public string ImageSrc => ProjectImage.Any() ? $"data:image/jpeg;base64, {Convert.ToBase64String(ProjectImage.First().Image)}" : "/Images/resim-yok.jpg";

        public virtual ICollection <ApplicationUser> ApplicationUsers { get; set; } = new HashSet<ApplicationUser>();

        public virtual ICollection<ProjectImage> ProjectImages { get; set; } = new HashSet<ProjectImage>();




    }
    public class ProjectEntityTypeConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {

            builder
                 .HasMany(p => p.ProjectImages)
                 .WithOne(p => p.Project)
                 .HasForeignKey(p => p.ProjectId)
                 .OnDelete(DeleteBehavior.Cascade);





        }
    }
}

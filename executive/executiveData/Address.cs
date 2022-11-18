using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace executiveData
{
    internal class Address : EntityBase
    {
        public Guid ApplicationUserId { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }


    }
}

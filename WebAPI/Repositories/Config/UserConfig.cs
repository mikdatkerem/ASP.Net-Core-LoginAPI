using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Models;

namespace WebAPI.Repositories.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User { Id = 1, Name = "miko", password = 159753 },
                new User { Id = 2, Name = "kero", password = 147852 },
                new User { Id = 3, Name = "miky", password = 369852 });
        }
    }
}

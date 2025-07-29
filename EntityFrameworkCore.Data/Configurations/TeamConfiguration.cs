using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Data.Configurations
{
    internal class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Team> builder)
        {
            builder.HasData(
                    new Team
                    {
                        Id = 1,
                        Name = "Tivoli Gardens F.C.",
                        CreatedDate = DateTimeOffset.UtcNow.DateTime
                    },
                    new Team
                    {
                        Id = 2,
                        Name = "Waterhouse F.C.",
                        CreatedDate = DateTimeOffset.UtcNow.DateTime
                    },
                    new Team
                    {
                        Id = 3,
                        Name = "Humble Lions F.C.",
                        CreatedDate = DateTimeOffset.UtcNow.DateTime
                    }
                );
        }
    }

    internal class LeagueConfiguration : IEntityTypeConfiguration<League>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<League> builder)
        {
            builder.HasData(
                    new League
                    {
                        Id = 1,
                        Name = "Jamaica Premiere League",
                    },
                    new League
                    {
                        Id = 2,
                        Name = "English Premiere League",
                    },
                    new League
                    {
                        Id = 3,
                        Name = "La Liga",
                    }
                );
        }
    }
}

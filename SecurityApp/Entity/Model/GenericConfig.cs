using Entity.Model.Security;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    internal class GenericConfig
    {
        public void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(i => i.UserName).IsUnique();
        }
        public void ConfigurePerson(EntityTypeBuilder<Person> builder)
        {
            builder.HasIndex(i => i.document).IsUnique();
            builder.HasIndex(i => i.email).IsUnique();
            builder.HasIndex(i => i.phone).IsUnique();
        }

    }
}

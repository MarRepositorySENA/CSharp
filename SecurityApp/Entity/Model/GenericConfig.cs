using Entity.Model.Security;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    internal class GenericConfig
    {
        public void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(i => i.UserName).IsUnique();
            builder.HasIndex(i => i.passsword).IsUnique();
        }
        public void ConfigurePerson(EntityTypeBuilder<Person> builder)
        {
            builder.HasIndex(i => i.document).IsUnique();
            builder.HasIndex(i => i.email).IsUnique();
            builder.HasIndex(i => i.phone).IsUnique();
            builder.HasIndex(i => i.birthDate).IsUnique();
            
        }

        public void ConfigureRole(EntityTypeBuilder<Role> builder)
        {
            builder.HasIndex(i => i.code).IsUnique();
            builder.HasIndex(i => i.name).IsUnique();
         
            
        }
        public void ConfigureView(EntityTypeBuilder<View> builder)
        {
            builder.HasIndex(i => i.code).IsUnique();
            builder.HasIndex(i => i.name).IsUnique();
            builder.HasIndex(i => i.route).IsUnique();
        }
        public void ConfigureModule(EntityTypeBuilder<Module> builder)
        {
            builder.HasIndex(i => i.code).IsUnique();
            builder.HasIndex(i => i.name).IsUnique();
        }
        
    }
}

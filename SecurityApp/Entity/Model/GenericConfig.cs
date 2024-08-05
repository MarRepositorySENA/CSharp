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
        public void ConfigureUser(EntityTypeBuilder<Users> builder)
        {
            builder.HasIndex(i => i.username).IsUnique();
            builder.HasIndex(i => i.password).IsUnique();
        }
        public void ConfigurePerson(EntityTypeBuilder<Persons> builder)
        {
            builder.HasIndex(i => i.document).IsUnique();
            builder.HasIndex(i => i.email).IsUnique();
            builder.HasIndex(i => i.phone).IsUnique();
            builder.HasIndex(i => i.birthDate).IsUnique();
            
        }

        public void ConfigureRole(EntityTypeBuilder<Roles> builder)
        {
            builder.HasIndex(i => i.code).IsUnique();
            builder.HasIndex(i => i.name).IsUnique();
         
            
        }
        public void ConfigureView(EntityTypeBuilder<Views> builder)
        {
            builder.HasIndex(i => i.code).IsUnique();
            builder.HasIndex(i => i.name).IsUnique();
            builder.HasIndex(i => i.route).IsUnique();
        }
        public void ConfigureModules(EntityTypeBuilder<Modules> builder)
        {
            builder.HasIndex(i => i.code).IsUnique();
            builder.HasIndex(i => i.name).IsUnique();
        }

        public void ConfigureUserRoles(EntityTypeBuilder<Users_Roles> builder)
        {
            builder.HasIndex(i => i.code).IsUnique();
        }
        public void ConfigureRolesViews(EntityTypeBuilder<Roles_Views> builder)
        {
            builder.HasIndex(i => i.code).IsUnique();
        }
    }
}

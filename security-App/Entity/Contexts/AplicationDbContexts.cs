using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Contexts

{
    public class AplicationDbContexts : DbContext

    {
            protected readonly IConfiguration _configuration;
            public AplicationDbContexts(DbContextOptions<AplicationDbContexts> options, IConfiguration configuration)
            : base(options)
            {
                _configuration = configuration;
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //DataInicial.Data(modeBuilder);
            base.OnModelCreating(modelBuilder);
            }


        //ajuste de tipo de dato datetime




        //<summary>
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        }



}


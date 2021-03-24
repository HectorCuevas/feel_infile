﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FEL_API.Models
{
    public class FEL_APIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public FEL_APIContext() : base("name=FEL_APIContext")
        {
        }
      /*  protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<FEL_APIContext>(null);
            base.OnModelCreating(modelBuilder);
        }*/

        public System.Data.Entity.DbSet<FEL_API.Models.SolicitudAPI> SolicitudAPIs { get; set; }

        public System.Data.Entity.DbSet<FEL_API.Models.DatosFox> DatosFoxes { get; set; }
    }
}
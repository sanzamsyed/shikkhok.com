using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace KnowYourProfDesign.Models
{
    public class MyDbContext:DbContext
    {
        public DbSet<UserAccount> userAccount { get; set; }

        public System.Data.Entity.DbSet<KnowYourProfDesign.Models.ContactUs> ContactUs { get; set; }

        public System.Data.Entity.DbSet<KnowYourProfDesign.Models.Master> Masters { get; set; }

        public System.Data.Entity.DbSet<KnowYourProfDesign.Models.Review> Reviews { get; set; }
    }
}
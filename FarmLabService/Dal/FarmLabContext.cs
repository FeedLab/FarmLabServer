using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmLabService.DataObjects;
using Microsoft.EntityFrameworkCore;

namespace FarmLabService.Dal
{
    public class FarmLabContext : DbContext
    {
        public FarmLabContext(DbContextOptions<FarmLabContext> options)
            : base(options)
        { }

        public DbSet<UserItem> Users { get; set; }
    }
}

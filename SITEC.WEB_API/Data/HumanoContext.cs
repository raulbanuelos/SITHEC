using Microsoft.EntityFrameworkCore;
using SITEC.WEB_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SITEC.WEB_API.Data
{
    public class HumanoContext : DbContext
    {
        public HumanoContext(DbContextOptions<HumanoContext> options)
            :base(options)
        {

        }

        public DbSet<Humano> Humanos { get; set; }
    }
}

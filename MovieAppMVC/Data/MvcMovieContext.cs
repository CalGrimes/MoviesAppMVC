using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieAppMVC.Models;

namespace MovieAppMVC.Data
{
    public class MovieAppMVCContext : DbContext
    {
        public MovieAppMVCContext (DbContextOptions<MovieAppMVCContext> options)
            : base(options)
        {
        }

        public DbSet<MovieAppMVC.Models.Movie> Movie { get; set; } = default!;
    }
}

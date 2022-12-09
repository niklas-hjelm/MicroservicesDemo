using DomainCommons.Models;
using Microsoft.EntityFrameworkCore;

namespace HeroApi.DataAccess.Contexts;

public class HeroContext : DbContext
{
    public DbSet<Hero> Heroes { get; set; }

    public HeroContext(DbContextOptions options) : base(options)
    {

    }
}
using HeroApi.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace HeroApi.DataAccess.Contexts;

public class HeroContext : DbContext
{
    public DbSet<Hero> Heroes { get; set; }

    public HeroContext(DbContextOptions options) : base(options)
    {
        try
        {
            if (Database.GetService<IDatabaseCreator>() is RelationalDatabaseCreator databaseCreator)
            {
                if (!databaseCreator.CanConnect()) databaseCreator.Create();
                if(!databaseCreator.HasTables()) databaseCreator.CreateTables();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
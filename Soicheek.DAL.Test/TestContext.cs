using Microsoft.EntityFrameworkCore;
using Soicheek.DAL;

namespace Soicheek.DAL.Test;

public class TestContext
{
    public SoicheekContext SoicheekContext { get; set; }

    public TestContext(string dbName)
    {
        SoicheekContext = CreateSoicheekDbContext(dbName);
    }

    public void Dispose()
    {
        SoicheekContext?.Database.EnsureDeleted();
        SoicheekContext?.Dispose();
    }

    private SoicheekContext CreateSoicheekDbContext(string dbName)
    {
        var context = new SoicheekContext(CreateDbContextOptions(dbName));
        return context;
    }

    private DbContextOptions<SoicheekContext> CreateDbContextOptions(string dbName)
    {
        var contextOptionsBuilder = new DbContextOptionsBuilder<SoicheekContext>();
        contextOptionsBuilder.UseInMemoryDatabase(dbName);
        //contextOptionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        return contextOptionsBuilder.Options;
    }
}

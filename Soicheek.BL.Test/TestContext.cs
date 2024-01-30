using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Soicheek.BL.Services;
using Soicheek.DAL;

namespace Soicheek.BL.Test;

public class TestContext
{
    public SoicheekContext SoicheekContext { get; private set; }
    public IMapper Mapper { get; private set; }

    public TestContext(string dbName)
    {
        Mapper = CreateMapper();
        SoicheekContext = CreateSoicheekDbContext(dbName);
    }

    public void Dispose()
    {
        SoicheekContext?.Database.EnsureDeleted();
        SoicheekContext?.Dispose();
    }

    private IMapper CreateMapper()
    {
        var mapperConfiguration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(typeof(MappingProfile));
        });
        return mapperConfiguration.CreateMapper();

    }

    private SoicheekContext CreateSoicheekDbContext(string dbName)
    {
        return new SoicheekContext(CreateDbContextOptions(dbName));
    }

    private DbContextOptions<SoicheekContext> CreateDbContextOptions(string dbName)
    {
        var contextOptionsBuilder = new DbContextOptionsBuilder<SoicheekContext>();
        contextOptionsBuilder.UseInMemoryDatabase(dbName);
        return contextOptionsBuilder.Options;
    }
}

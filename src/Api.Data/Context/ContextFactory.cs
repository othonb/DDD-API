using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Api.Data.Context
{
  public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
  {
    private readonly IConfiguration _configuration;

    public ContextFactory(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    public MyContext CreateDbContext(string[] args)
    {
        // Usado para criar as migrações
        var connectionString = _configuration.GetConnectionString("CommanderConnection");

        var optionsBuilder = new DbContextOptionsBuilder<MyContext>();

        optionsBuilder.UseMySql(connectionString);

        return new MyContext(optionsBuilder.Options);
    }
  }
}
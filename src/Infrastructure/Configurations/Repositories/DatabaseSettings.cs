namespace Infrastructure.Configurations.Repositories;

public class DatabaseSettings
{
    public string ConnectionString { get; set; } = default!;

    public string DatabaseName { get; set; } = default!;
}

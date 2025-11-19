using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain.Repositories;
using ProductCatalog.Infrastructure.Data;

namespace ProductCatalog.Infrastructure.Repositories;

public class ProductAnalyticsRepository : IProductAnalyticsRepository
{
    private readonly AppDbContext _context;
    private readonly string _connectionString;

    public ProductAnalyticsRepository(AppDbContext context)
    {
        _context = context;
        _connectionString = _context.Database.GetConnectionString()
                           ?? throw new InvalidOperationException("No connection string configured.");
    }

    public async Task<ProductAnalyticsSummary> GetSummaryAsync()
    {
        await using var connection = new SqliteConnection(_connectionString);

        const string sql = @"
            SELECT 
                COUNT(*)              AS TotalProducts,
                IFNULL(SUM(Stock), 0) AS TotalStock,
                IFNULL(AVG(Price), 0) AS AveragePrice
            FROM Products;";

        var result = await connection.QuerySingleAsync<ProductAnalyticsSummary>(sql);
        return result;
    }
}

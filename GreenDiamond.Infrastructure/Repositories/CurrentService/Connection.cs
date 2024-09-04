using Microsoft.EntityFrameworkCore;
using GreenDiamond.Domain.Interface.GreenDiaiondConnection;
using Microsoft.Extensions.Caching.Memory;

namespace GreenDiamond.Infrastructure.Repositories.CurrentService
{
    public class Connection : IConnection
    {
        //private readonly GreenDiamondContext _context;
        private readonly IMemoryCache _memoryCache;

        public string? ConnectionString { get; set; }

        public Connection(/*GreenDiamondContext context,*/ IMemoryCache memoryCache)
        {
            //_context = context;
            _memoryCache = memoryCache;
        }

        public async Task<bool> SetGreenDimoand(string greenDimoand)
        {
            if (_memoryCache.TryGetValue(greenDimoand, out string connectionString))
            {
                ConnectionString = connectionString;
                return true;
            }

            connectionString = await GetGreenDimaondConnectionStringAsync(greenDimoand);

            if (connectionString != null)
            {
                _memoryCache.Set(greenDimoand, connectionString, TimeSpan.FromMinutes(30)); 
                ConnectionString = connectionString;
            }
            return true;
        }

        internal async Task<string> GetGreenDimaondConnectionStringAsync(string greenDimoand)
        {
            return "Server=SSLLP-63;Database=GreenDiamond;User Id=sa;Password=sa;MultipleActiveResultSets=true;TrustServerCertificate=True;";

        }
    }
}

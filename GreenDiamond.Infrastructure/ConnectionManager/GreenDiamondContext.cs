using GreenDiamond.Domain.Interface.GreenDiaiondConnection;
using Microsoft.EntityFrameworkCore;

namespace GreenDiamond.Infrastructure
{
    public partial class GreenDiamondContext
    {
        private readonly IConnection _connection;

        public string ConnectionString { get; set; }

        public GreenDiamondContext(
            DbContextOptions<GreenDiamondContext> options,
            IConnection Connection)
            : base(options)
        {
            _connection = Connection;
            ConnectionString = _connection.ConnectionString;
        }

        protected override async void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (optionsBuilder.IsConfigured)
            {
                string connection = ConnectionString;
                if (!string.IsNullOrEmpty(connection)) 
                {
                    _ = optionsBuilder.UseSqlServer(connection);
                }
            }
        }
    }
}

using GreenDiamond.Domain.UnitOfWork;
using GreenDiamond.Domain.Interfaces.GreenDiamond;

namespace GreenDiamond.Infrastructure.UnitOfWork
{
    public class UnitOfWorkGreenDiamond : IUnitOfWorkGreenDiamond, IAsyncDisposable
    {
        private bool _disposed = false;

        private readonly GreenDiamondContext _gdcDbContext;
        public IClassOfTradeRepository ClassOfTradeRepository { get; }

        public UnitOfWorkGreenDiamond(  
            GreenDiamondContext gdcDbContext,  
            IClassOfTradeRepository classOfTradeRepository
            )
        {
            _gdcDbContext = gdcDbContext;
            ClassOfTradeRepository = classOfTradeRepository;
        }

        public void Commit()
        {
            EnsureNotDisposed();
            _gdcDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            EnsureNotDisposed();
                await _gdcDbContext.SaveChangesAsync();
        }

        public void Rollback()
        {
            EnsureNotDisposed();
            Dispose();
        }

        public async Task RollbackAsync()
        {
            EnsureNotDisposed();
            await DisposeAsync();
        }

        protected virtual void EnsureNotDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(UnitOfWork));
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _gdcDbContext?.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeAsync(true);
            GC.SuppressFinalize(this);
        }
        protected virtual async ValueTask DisposeAsync(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_gdcDbContext != null)
                    {
                        await _gdcDbContext.DisposeAsync();
                    }
                }
                _disposed = true;
            }
        }
    }
}

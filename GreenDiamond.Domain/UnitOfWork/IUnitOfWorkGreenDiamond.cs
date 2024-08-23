using GreenDiamond.Domain.Interfaces.GreenDiamond;

namespace GreenDiamond.Domain.UnitOfWork
{
    public interface IUnitOfWorkGreenDiamond : IDisposable
    {
        IClassOfTradeRepository ClassOfTradeRepository { get; }


        void Commit();

        void Rollback();

        Task CommitAsync();

        Task RollbackAsync();
    }
}

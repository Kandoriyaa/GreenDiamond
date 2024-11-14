using GreenDiamond.Domain.Interface.GreenDiamond;
using GreenDiamond.Domain.Interfaces.GreenDiamond;

namespace GreenDiamond.Domain.UnitOfWork
{
    public interface IUnitOfWorkGreenDiamond : IDisposable
    {
        IClassOfTradeRepository ClassOfTradeRepository { get; }
        IClotheDisplayRepository ClotheDisplayRepository { get; }
        ILoginRepository LoginRepository { get; }
        ICustomerRepository CustomerRepository { get; }


        void Commit();

        void Rollback();

        Task CommitAsync();

        Task RollbackAsync();
    }
}

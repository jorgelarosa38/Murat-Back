using Project.Repository;

namespace Project.UnitOfWork
{
    public interface IUnitOfWork
    {
        ITablaMaestraRepository TablaMaestra { get; }
        IComboRepository Combo { get; }
        ISecurityRepository Security { get; }
        IWriteOperationRepository WriteOperation { get; }
        IUserRepository User { get; }
    }
}

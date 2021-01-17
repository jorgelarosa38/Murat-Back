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
        IPublicadoRepository Publicado { get; }
        ICommonRepository Common { get; }
        ISliderRepository Slider { get; }
        IMarcaRepository Marca { get; }
        IProductoRepository Producto { get; }
    }
}

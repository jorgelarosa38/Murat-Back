using Project.Repository;
using Project.UnitOfWork;
using Microsoft.Extensions.Configuration;

namespace Project.DataAccess
{
    public class ProjectUnitOfWork : IUnitOfWork
    {
        public ISecurityRepository Security { get; private set; }
        public ITablaMaestraRepository TablaMaestra { get; private set; }
        public IComboRepository Combo { get; private set; }
        public IWriteOperationRepository WriteOperation { get; private set; }
        public IUserRepository User { get; private set; }
        public IPublicadoRepository Publicado { get; private set; }
        public ICommonRepository Common { get; private set; }
        public ISliderRepository Slider { get; private set; }
        public IMarcaRepository Marca { get; private set; }
        public IProductoRepository Producto { get; private set; }

        public ProjectUnitOfWork(string connectionString, IConfiguration _configuration)
        {
            Security = new SecurityRepository(connectionString, _configuration);
            TablaMaestra = new TablaMaestraRepository(connectionString);
            Combo = new ComboRepository(connectionString);
            WriteOperation = new WriteOperationRepository(connectionString);
            User = new UserRepository(connectionString);
            Publicado = new PublicadoRepository(connectionString);
            Common = new CommonRepository(connectionString);
            Slider = new SliderRepository(connectionString);
            Producto = new ProductoRepository(connectionString);
            Marca = new MarcaRepository(connectionString);
        }
    }
}

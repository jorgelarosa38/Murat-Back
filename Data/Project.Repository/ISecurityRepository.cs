using Project.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public interface ISecurityRepository
    {
        Task<List<DetalleUsuario>> ValidarAccesos(Credenciales credenciales);
    }
}

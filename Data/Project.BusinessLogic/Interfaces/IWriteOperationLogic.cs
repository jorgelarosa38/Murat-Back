using Project.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogic.Interfaces
{
    public interface IWriteOperationLogic
    {
        Task<object> WriteOperation(WriteOperation writeOperation);
    }
}

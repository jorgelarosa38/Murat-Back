using System.Threading.Tasks;

namespace Project.BusinessLogic.Interfaces
{
    public interface IComboLogic
    {
        Task<object> ListarCombo(int TIPO, string PARM1, string PARM2, string PARM3, string PARM4, int VALOR);
    }
}

using RHManager.Domain.Entities;

namespace RHManager.Application.Interfaces
{
    public interface IFuncionarioAppService : IAppServiceBase<Funcionario>
    {
        decimal ObterSalarioLiquido(Funcionario funcionario);
        
    }
}

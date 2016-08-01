using RHManager.Domain.Entities;

namespace RHManager.Domain.Interfaces.Services
{
    public interface IFuncionarioService : IServiceBase<Funcionario>
    {
        decimal ObterSalarioLiquido(Funcionario funcionario);
    }
}

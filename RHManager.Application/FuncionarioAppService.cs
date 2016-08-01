using RHManager.Application.Interfaces;
using RHManager.Domain.Entities;
using RHManager.Domain.Interfaces.Services;

namespace RHManager.Application
{
    public class FuncionarioAppService : AppServiceBase<Funcionario>, IFuncionarioAppService
    {
        private readonly IFuncionarioService _funcionarioService;
        public FuncionarioAppService(IFuncionarioService funcionarioService)
            :base(funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }
        

        public decimal ObterSalarioLiquido(Funcionario funcionario)
        {
            return _funcionarioService.ObterSalarioLiquido(funcionario);
        }
    }
}

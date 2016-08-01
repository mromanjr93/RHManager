using RHManager.Domain.Entities;
using RHManager.Domain.Interfaces.Repositories;
using RHManager.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHManager.Domain.Services
{
    public class FuncionarioService : ServiceBase<Funcionario>, IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
            :base(funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }
        

        public decimal ObterSalarioLiquido(Funcionario funcionario)
        {
            return funcionario.SalarioLiquido();
        }
    }
}

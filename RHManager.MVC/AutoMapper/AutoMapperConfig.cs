using AutoMapper;
using RHManager.Domain.Entities;
using RHManager.MVC.ViewModels;

namespace RHManager.MVC.AutoMapper
{
    public class AutoMapperConfig
    {
        

        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                //Mapeia as classes de ViewModel para classes de Domínio                
                x.CreateMap<Funcionario, FuncionarioViewModel>();


                //Mapeia as classes de Domínio para classes de ViewModel
                
                x.CreateMap<FuncionarioViewModel, Funcionario>();                
            });  
        }

    }
}
using AutoMapper;
using RHManager.Application.Interfaces;
using RHManager.Domain.Entities;
using RHManager.MVC.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RHManager.MVC.Controllers
{
    /// <summary>
    /// Esta classe tem como objetivo estabelecer as Actions do MVC para funcionários
    /// e estabelecer a Injeção de Dependência para consumir os Services de Funcionários    /// 
    /// </summary>
    public class FuncionariosController : Controller
    {
        #region Properties
        private readonly IFuncionarioAppService _funcionarioApp;
        #endregion

        #region Constructor
        public FuncionariosController(IFuncionarioAppService funcionarioApp)
        {
            _funcionarioApp = funcionarioApp;
        }
        #endregion

        #region HttpMethods MVC
        // GET: Funcionarios
        public ActionResult Index()
        {
            var funcionarios = Mapper.Map<IEnumerable<Funcionario>, IEnumerable<FuncionarioViewModel>>(_funcionarioApp.GetAll());

            foreach (var item in funcionarios)
            {
                item.SalarioLiquido = _funcionarioApp.ObterSalarioLiquido(Mapper.Map<FuncionarioViewModel, Funcionario>(item));                    
             }

            return View(funcionarios);
        }

        // GET: Funcionarios/Details/5
        public ActionResult Details(int id)
        {
            var funcionario = _funcionarioApp.GetById(id);
            var funcionarioViewModel = this._GetFuncionarioToView(funcionario);
            return View(funcionarioViewModel);
        }

        // GET: Funcionarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Funcionarios/Create
        [HttpPost]
        public ActionResult Create(FuncionarioViewModel funcionario)
        {
            if (ModelState.IsValid)
            {
                var funcionarioDomain = this._GetFuncionarioToDomain(funcionario);

                _funcionarioApp.Add(funcionarioDomain);

                return RedirectToAction("Index");                
            }
            return View();
        }

        // GET: Funcionarios/Edit/5
        public ActionResult Edit(int id)
        {
            var funcionarioViewModel = Mapper.Map<Funcionario, FuncionarioViewModel>(_funcionarioApp.GetById(id));
            return View(funcionarioViewModel);
        }

        // POST: Funcionarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FuncionarioViewModel funcionario)
        {
            if (ModelState.IsValid)
            {
                var funcionarioDomain = this._GetFuncionarioToDomain(funcionario);

                _funcionarioApp.Update(funcionarioDomain);

                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Funcionarios/Delete/5
        public ActionResult Delete(int id)
        {
            var funcionario = _funcionarioApp.GetById(id);
            var funcionarioViewModel = this._GetFuncionarioToView(funcionario);
            return View(funcionarioViewModel);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var funcionario = _funcionarioApp.GetById(id);
            _funcionarioApp.Remove(funcionario);
            return RedirectToAction("Index");
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Utiliza o Mapper para Mapear a entidade Funcionario para FuncionarioViewModel
        /// </summary>
        /// <param name="funcionario">Objeto do tipo funcionário</param>
        /// <returns>FuncionarioViewModel</returns>
        private FuncionarioViewModel _GetFuncionarioToView(Funcionario funcionario)
        {
            return Mapper.Map<Funcionario, FuncionarioViewModel>(funcionario);
        }

        /// <summary>
        /// Utiliza o Mapper para Mapear a entidade FuncionarioViewModel para Funcionario
        /// </summary>
        /// <param name="funcionario">Objeto do tipo FuncionarioViewModel</param>
        /// <returns>Funcionario</returns>
        private Funcionario _GetFuncionarioToDomain(FuncionarioViewModel funcionario)
        {
            return Mapper.Map<FuncionarioViewModel, Funcionario>(funcionario);
        }
        #endregion
    }
}

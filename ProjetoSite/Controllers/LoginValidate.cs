using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoSite.Data;
using ProjetoSite.Models.Entities;
using ProjetoSite.Utilitario;

namespace ProjetoSite.Controllers {
    public class LoginValidateController:Controller {
        private readonly AplicativoDBContext _dbContext;

        public LoginValidateController(AplicativoDBContext dbContext) {
            _dbContext = dbContext;
        }

        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string ValidarUsuario) {
            try {
                
                var fornecedor = _dbContext.Fornecedores.FirstOrDefault(x => x.Email == ValidarUsuario);

                if(fornecedor != null) {
                    
                    ViewBag.LoginBemSucedido = "Login Efetuado com sucesso";
                    return View("IndexLogin","LoginValidate");
                }
                else {
                    ViewBag.ErrorMessage = "Fornecedor não encontrado.";
                    return View("IndexLogin","LoginValidate");
                }
            }
            catch(Exception ex) {
                ViewBag.ErrorMessage = $"Erro ao processar o login: {ex.Message}";
                return View("IndexLogin","LoginValidate");
            }
        }
    }
}

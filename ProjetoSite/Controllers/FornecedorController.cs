using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoSite.Data;
using ProjetoSite.Models;
using ProjetoSite.Models.Entities;

namespace ProjetoSite.Controllers {
    public class FornecedorController:Controller {
        private readonly AplicativoDBContext dbContext;
        public FornecedorController(AplicativoDBContext dbContext) {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult Formulario() {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Formulario(AddFornecedorViewModel viewModel) {

            var fornecedor = new Fornecedor {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                NomeFantasia = viewModel.NomeFantasia,
                CNPJ = viewModel.CNPJ,
            };

            await dbContext.Fornecedores.AddAsync(fornecedor);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List","Fornecedor");
        }
        [HttpGet]
        public async Task<IActionResult> List() {
            var fornecedores = await dbContext.Fornecedores.ToListAsync();

            return View(fornecedores);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id) {
            var Fornecedor = await dbContext.Fornecedores.FindAsync(id);
            return View(Fornecedor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Fornecedor viewModel) {
            var fornecedor = await dbContext.Fornecedores.FindAsync(viewModel.Id);
            if(fornecedor is not null) {
                fornecedor.Name = viewModel.Name;
                fornecedor.Email = viewModel.Email;
                fornecedor.Phone = viewModel.Phone;
                fornecedor.NomeFantasia = viewModel.NomeFantasia;
                fornecedor.CNPJ = viewModel.CNPJ;

                await dbContext.SaveChangesAsync();
            }
            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Fornecedor viewModel) {
            var fornecedor = await dbContext.Fornecedores.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            if(fornecedor is not null) {
                dbContext.Fornecedores.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Fornecedor");
        }

        public async Task<IActionResult> Login() {
            return View();
        }

    }
}

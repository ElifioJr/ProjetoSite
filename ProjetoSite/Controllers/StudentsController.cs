using Microsoft.AspNetCore.Mvc;
using ProjetoSite.Data;
using ProjetoSite.Models;
using ProjetoSite.Models.Entities;

namespace ProjetoSite.Controllers
    {
    public class StudentsController : Controller
        {
            private readonly AplicativoDBContext dbContext;
            public StudentsController(AplicativoDBContext dbContext)
            {
                this.dbContext = dbContext;
            }

        //End-Point para adicionar novos estudantes;
        [HttpGet]
        public IActionResult Add()
            {
            return View();
            }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel) 
            {

            var student = new Student
                {
                    Name = viewModel.Name,
                    Email = viewModel.Email,
                    Phone = viewModel.Phone,
                    Subscribed = viewModel.Subscribed,
                };
                
                await dbContext.Students.AddAsync(student);
                await dbContext.SaveChangesAsync();

                return View();
            }
        }
    }

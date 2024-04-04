using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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


        [HttpGet]
        public IActionResult Add()
            {
            return View();
            }

        //EndPoint Para adicionar novos estudantes;
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
        [HttpGet]
        public async Task<IActionResult> List()
            {
            var students = await dbContext.Students.ToListAsync();

            return View(students);
            }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
            {
            var students = await dbContext.Students.FindAsync(id);
            return View(students);
            }

        [HttpPost]
        public async Task<IActionResult> Edit(Student viewModel)
            {
            var students = await dbContext.Students.FindAsync(viewModel.Id);
            if (students is not null)
                {
                students.Name = viewModel.Name;
                students.Email = viewModel.Email;
                students.Phone = viewModel.Phone;
                students.Subscribed = viewModel.Subscribed;

                await dbContext.SaveChangesAsync();
                }
            return RedirectToAction("List", "Students");
            }

        [HttpPost]
        public async Task<IActionResult> Delete(Student viewModel)
            {
            var student = await dbContext.Students.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);
                if (student is not null)
                {
                dbContext.Students.Remove(viewModel);
                await dbContext.SaveChangesAsync();
                }
            return RedirectToAction("List", "Students");
            }
        }
    }

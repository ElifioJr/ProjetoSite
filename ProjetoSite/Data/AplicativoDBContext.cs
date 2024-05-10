using Microsoft.EntityFrameworkCore;
using ProjetoSite.Models;
using ProjetoSite.Models.Entities;

namespace ProjetoSite.Data {
    public class AplicativoDBContext:DbContext {
        public AplicativoDBContext(DbContextOptions<AplicativoDBContext> options) : base(options) {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

    }
}

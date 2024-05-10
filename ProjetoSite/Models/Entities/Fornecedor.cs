using System.ComponentModel.DataAnnotations;

namespace ProjetoSite.Models.Entities {
    public class Fornecedor {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string NomeFantasia { get; set; }

        
        [Required(ErrorMessage = "CNPJ Obrigatório !")]
        public string CNPJ { get; set; }
    }

}

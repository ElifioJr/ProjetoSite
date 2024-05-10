using System.ComponentModel.DataAnnotations;

namespace ProjetoSite.Models {
    public class LoginViewModel {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "CNPJ Obrigatório !")]
        public string ValidarUsuario { get; set; }
    }
}

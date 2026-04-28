using System.ComponentModel.DataAnnotations;

namespace GameStoreMVC.Models
{
    // Usado pelo Repositório para representar o Banco
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string? Cargo { get; set; }
    }
    public class LoginViewModel
    {
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }

    public class CriarContaViewModel
    {
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres.")]
        public string Senha { get; set; } = string.Empty;

        [Required(ErrorMessage = "A confirmação de senha é obrigatória.")]
        [Compare("Senha", ErrorMessage = "As senhas não conferem.")]
        public string ConfirmarSenha { get; set; } = string.Empty;
    }
}

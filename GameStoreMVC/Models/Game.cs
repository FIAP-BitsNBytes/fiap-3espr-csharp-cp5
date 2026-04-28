using System.ComponentModel.DataAnnotations;

namespace GameStoreMVC.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O gênero é obrigatório.")]
        public string Genero { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal Preco { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; } = DateTime.Today;
    }
}
 
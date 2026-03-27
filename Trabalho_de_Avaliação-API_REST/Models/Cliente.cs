

using System.ComponentModel.DataAnnotations;

namespace ModelsAPI;

public class Cliente
{
    public int Id{get; set;}
    [Required(ErrorMessage = "O nome do cliente é obrigatório")]
    [MaxLength(80, ErrorMessage = "Nome do cliente deve ter entre 3 e 100 caracteres.")]
    [MinLength(3, ErrorMessage = "Nome do cliente deve ter entre 3 e 100 caracteres.")]
    public string Nome{get; set;} = string.Empty;
    [Required(ErrorMessage = "O email do cliente é obrigatório")]
    [EmailAddress(ErrorMessage = "Email em formato inválido.")]
    public string Email{get; set;} = string.Empty;
    [Required(ErrorMessage = "A idade do cliente é obrigatório")]
    [Range(typeof(int), "18", "120", ErrorMessage = "Idade mínima é 18 anos.")]
    public int Idade{get; set;}
}
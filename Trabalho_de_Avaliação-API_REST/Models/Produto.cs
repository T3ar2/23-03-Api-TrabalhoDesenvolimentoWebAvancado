using System.ComponentModel.DataAnnotations;

namespace ModelsAPI;

public class Produto{
    public int Id{set; get;}
    [Required(ErrorMessage = "O nome é obrigatório")]
    [MaxLength(120, ErrorMessage = "Nome deve ter entre 3 e 120 caracteres.")]
    [MinLength(3, ErrorMessage ="Nome deve ter entre 3 e 120 caracteres.")]
    public string Nome{set; get;} = string.Empty;
    [Range(typeof(decimal), "1", "9999999999,99", ErrorMessage = "Preço deve ser maior que zero.")]
    public decimal Preco {set; get;}
    [Range(typeof(int), "0", "999999999,99", ErrorMessage = "Estoque não pode ser negativo.")]
    public int Estoque{set; get;}

}
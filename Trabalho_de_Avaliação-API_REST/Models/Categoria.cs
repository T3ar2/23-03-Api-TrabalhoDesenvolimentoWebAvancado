

using System.ComponentModel.DataAnnotations;

namespace ModelsAPI;

public class Categoria
{
   public int Id{get; set;} 
   [Required(ErrorMessage = "Nome da categoria é obrigatório.")]
   [MaxLength(80, ErrorMessage = "Nome da categoria deve ter entre 3 e 80 caracteres.")]
   [MinLength(3, ErrorMessage = "Nome da categoria deve ter entre 3 e 80 caracteres.")]
   public string Nome{get; set;} = string.Empty;
   [MaxLength(200, ErrorMessage = "Descrição deve ter no máximo 200 caracteres.")]
   public string Descricao{get; set;} = string.Empty;
}
using System.ComponentModel.DataAnnotations;

namespace WebApi.Model;

public class Perfil(
    int id,
    string nomeUsuario,
    string loginUsuario,
    string email
    )
{
    [Key]
    public int Id { get; set; } = id;
    [Required]
    [MinLength(15, ErrorMessage = "nome deve ter um tamanho mínimo de 15 caracteres")]
    [MaxLength(50, ErrorMessage = "nome deve ter um tamanho mínimo de 50 caracteres")]
    public string NomeUsuario { get; set; } = nomeUsuario;
    [Required]
    [MinLength(15, ErrorMessage = "login deve ter um tamanho mínimo de 15 caracteres")]
    [MaxLength(50, ErrorMessage = "login deve ter um tamanho mínimo de 50 caracteres")]
    public string LoginUsuario { get; set; } = loginUsuario;
    
    [Required]
    [RegularExpression(@"/^[a-z0-9.]+@[a-z0-9]+\.[a-z]+\.([a-z]+)?$/i")]
    [MinLength(15, ErrorMessage = "login deve ter um tamanho mínimo de 15 caracteres")]
    [MaxLength(60, ErrorMessage = "login deve ter um tamanho mínimo de 50 caracteres")]
    public string Email { get; set; } = email;
    
}
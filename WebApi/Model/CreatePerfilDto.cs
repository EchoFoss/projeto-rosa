namespace WebApi.Model;

public record CreatePerfilDto(
    string NomeUsuario,
    string LoginUsuario,
    string Email
)
{
    public string NomeUsuario { get; set; } = NomeUsuario;
    public string LoginUsuario { get; set; } = LoginUsuario;
    public string Email { get; set; } = Email;


    public Perfil toPerfil()
    {
        return new Perfil(
            this.NomeUsuario,
            this.LoginUsuario,
            this.Email
        );
    }
}


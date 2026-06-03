using ProjetoLoginIB.Models;

namespace ProjetoLoginIB.interfaces
{
    public class IUsuarioRepositorio
    {
        LoginViewModel Validar(string Email, string Senha);
    }
}

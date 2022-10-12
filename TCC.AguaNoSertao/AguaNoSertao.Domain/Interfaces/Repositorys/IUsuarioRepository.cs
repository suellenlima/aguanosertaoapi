using AguaNoSertao.Domain.Entities;

namespace AguaNoSertao.Domain.Interfaces.Repositorys
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario ConsultarUsuario(int idUsuario);
    }
}

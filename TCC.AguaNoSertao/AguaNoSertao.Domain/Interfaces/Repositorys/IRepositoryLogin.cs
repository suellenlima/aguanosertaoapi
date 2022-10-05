using AguaNoSertao.Domain.Entities;

namespace AguaNoSertao.Domain.Interfaces.Repositorys
{
    public interface IRepositoryLogin : IRepositoryBase<Login>
    {
        Login ConsultarLogin(string email, string senha);
    }
}

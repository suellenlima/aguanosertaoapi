using AguaNoSertao.Domain.Entities;

namespace AguaNoSertao.Domain.Interfaces.Repositorys
{
    public interface ILoginRepository : IBaseRepository<Login>
    {
        Login ConsultarEmailLogin(string email);
        Login ConsultarLogin(string email, string senha);
    }
}

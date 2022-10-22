using AguaNoSertao.Domain.Entities;

namespace AguaNoSertao.Domain.Interfaces.Repositorys
{
    public interface ILoginRepository : IBaseRepository<Login>
    {
        Login ConsultarLoginPeloEmail(string email);
        Login ConsultarLogin(string email, string senha);
        Login ConsultarLoginPelaGuidVerificacao(string guidVerificacao);
    }
}

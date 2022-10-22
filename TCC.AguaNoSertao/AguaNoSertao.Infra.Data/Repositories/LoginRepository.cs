using AguaNoSertao.Domain.Entities;
using AguaNoSertao.Domain.Interfaces.Repositorys;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace AguaNoSertao.Infra.Data.Repositories
{
    public class LoginRepository : BaseRepository<Login>, ILoginRepository
    {
        private readonly SqlContext _sqlContext;

        public LoginRepository(SqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public Login ConsultarLogin(string email, string senha)
        {
            var login = _sqlContext.Logins.Include(e => e.Usuario).ThenInclude(e => e.Endereco).Where(e => e.Email == email && e.Senha == senha).FirstOrDefault();

            return login;
        }

        public Login ConsultarLoginPeloEmail(string email)
        {
            var login = _sqlContext.Logins.Include(e => e.Usuario).Where(e => e.Email == email).FirstOrDefault();

            return login;
        }

        public Login ConsultarLoginPelaGuidVerificacao(string guidVerificacao)
        {
            var login = _sqlContext.Logins.Include(e => e.Usuario).Where(e => e.GuidVerificacao == guidVerificacao).FirstOrDefault();

            return login;
        }
    }
}

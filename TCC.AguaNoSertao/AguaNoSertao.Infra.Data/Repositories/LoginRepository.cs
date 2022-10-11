using AguaNoSertao.Domain.Entities;
using AguaNoSertao.Domain.Interfaces.Repositorys;
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
            var login = _sqlContext.Logins.Where(e => e.Email == email && e.Senha == senha).FirstOrDefault();

            return login;
        }

        public Login ConsultarEmailLogin(string email)
        {
            var login = _sqlContext.Logins.Where(e => e.Email == email).FirstOrDefault();

            return login;
        }
    }
}

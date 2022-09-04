using AguaNoSertao.Domain.Entities;
using AguaNoSertao.Domain.Interfaces.Repositorys;

namespace AguaNoSertao.Infra.Data.Repositories
{
    public class RepositoryLogin : RepositoryBase<Login>, IRepositoryLogin
    {
        private readonly SqlContext _sqlContext;

        public RepositoryLogin(SqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }
    }
}

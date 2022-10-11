using AguaNoSertao.Domain.Entities;
using AguaNoSertao.Domain.Interfaces.Repositorys;

namespace AguaNoSertao.Infra.Data.Repositories
{
    public class ContatoFormRepository : BaseRepository<ContatoForm>, IContatoFormRepository
    {
        public ContatoFormRepository(SqlContext sqlContext) : base(sqlContext)
        {
        }
    }
}

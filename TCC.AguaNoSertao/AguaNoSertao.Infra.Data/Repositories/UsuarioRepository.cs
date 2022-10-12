using AguaNoSertao.Domain.Entities;
using AguaNoSertao.Domain.Interfaces.Repositorys;
using Microsoft.EntityFrameworkCore;

namespace AguaNoSertao.Infra.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly SqlContext _sqlContext;

        public UsuarioRepository(SqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public Usuario ConsultarUsuario(int idUsuario)
        {
            var usuario = _sqlContext.Usuarios.Include(e => e.Endereco).Where(e => e.Id == idUsuario).FirstOrDefault();

            return usuario;
        }
    }
}

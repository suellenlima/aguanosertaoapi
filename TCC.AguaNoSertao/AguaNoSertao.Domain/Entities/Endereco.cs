using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AguaNoSertao.Domain.Entities
{
    public class Endereco : BaseEntities
    {
        public string Logradouro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
    }
}

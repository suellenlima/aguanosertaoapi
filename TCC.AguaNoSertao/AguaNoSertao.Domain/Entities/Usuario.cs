using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AguaNoSertao.Domain.Entities
{
    public class Usuario : BaseEntities
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public Endereco Endereco { get; set; }
    }
}

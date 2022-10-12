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

        public Endereco()
        {
            Logradouro = string.Empty;
            Cidade = string.Empty;
            Estado = string.Empty;
            Cep = string.Empty;
            Usuario = null;
            UsuarioId = default;
        }
    }
}

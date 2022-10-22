namespace AguaNoSertao.Domain.Entities
{
    public class Login : BaseEntities
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool IsDisponivel { get; set; }
        public string? GuidVerificacao { get; set; } 
        public Usuario Usuario { get; set; }
    }
}

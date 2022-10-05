namespace AguaNoSertao.Domain.Entities
{
    public class ContatoForm : BaseEntities
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Mensagem { get; set; }
    }
}

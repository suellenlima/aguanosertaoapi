namespace AguaNoSertao.Domain.Interfaces.Integration
{
    public interface IEmailIntegration
    {
        void EnviarEmailRecuperarSenha(string nome, string guidRecuperação, string email);
    }
}

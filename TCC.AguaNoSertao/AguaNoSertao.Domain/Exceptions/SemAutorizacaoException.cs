namespace AguaNoSertao.Domain.Exceptions
{
    public class SemAutorizacaoException : Exception
    {
        public SemAutorizacaoException() : base("Sem autorização.")
        {
        }

        public SemAutorizacaoException(string? message) : base("Sem autorização.", new Exception(message))
        {
        }
    }
}

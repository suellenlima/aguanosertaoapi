using Newtonsoft.Json;

namespace AguaNoSertao.Domain.DTO
{
    public class Erro
    {
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("innerMessage")]
        public string InnerMessage { get; set; }
    }
}

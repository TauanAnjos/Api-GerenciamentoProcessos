using System.Text.Json.Serialization;

namespace GerenciamentoProcessos.Controllers.Enuns
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusPrazo
    {
        Recurso = 1,
        Contestacao = 2,
        Manifestacao = 3,
        Apelacao = 4,
        Embargos = 5
    }
}

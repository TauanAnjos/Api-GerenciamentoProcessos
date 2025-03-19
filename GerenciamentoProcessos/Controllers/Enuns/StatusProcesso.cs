using System.Text.Json.Serialization;

namespace GerenciamentoProcessos.Controllers.Enuns
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusProcesso
    {
        Ativo = 1,
        Inativo = 2,
        Andamento = 3
    }
}

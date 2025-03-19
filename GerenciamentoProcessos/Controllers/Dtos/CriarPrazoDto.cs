using GerenciamentoProcessos.Controllers.Enuns;

namespace GerenciamentoProcessos.Controllers.Dtos
{
    public class CriarPrazoDto
    {
        public Guid? ProcessoId { get; set; }
        public string? Tipo { get; set; }
        public DateOnly? DataVencimento { get; set; }
        public StatusPrazo StatusPrazo { get; set; }
    }
}

using GerenciamentoProcessos.Controllers.Enuns;

namespace GerenciamentoProcessos.Controllers.Dtos
{
    public class ProcessosDto
    {
        public Guid Id { get; set; }
        public string? Numero { get; set; }
        public string? OrgaoResponsavel { get; set; }
        public string? Assunto { get; set; }
        public StatusProcesso StatusProcesso { get; set; }
        public ProcuradorDto? Procurador { get; set; }
        public ClienteDto? Cliente { get; set; }
        public PrazoDto? Prazo { get; set; }
    }
}

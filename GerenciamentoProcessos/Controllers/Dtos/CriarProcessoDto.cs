using GerenciamentoProcessos.Controllers.Enuns;

namespace GerenciamentoProcessos.Controllers.Dtos
{
    public class CriarProcessoDto
    {
        public string Numero { get; set; }
        public string OrgaoResponsavel { get; set; }
        public string Assunto { get; set; }
        public StatusProcesso StatusProcesso { get; set; }
        public Guid? ProcuradorId { get; set; }
        public Guid? ClienteId { get; set; }
    }
}

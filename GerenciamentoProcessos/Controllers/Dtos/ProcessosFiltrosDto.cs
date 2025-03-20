namespace GerenciamentoProcessos.Controllers.Dtos
{
    public class ProcessosFiltrosDto
    {
        public Guid Id { get; set; }
        public string? Numero { get; set; }
        public string? OrgaoResponsavel { get; set; }
        public string? Assunto { get; set; }
    }
}

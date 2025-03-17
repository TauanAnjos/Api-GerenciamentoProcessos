namespace GerenciamentoProcessos.Controllers.Dtos
{
    public class CriarDocumentoDto
    {
        public Guid? ProcessoId { get; set; }
        public string? Nome { get; set; }
        public string? Tipo { get; set; }
        public string? CaminhoArquivo { get; set; }
    }
}

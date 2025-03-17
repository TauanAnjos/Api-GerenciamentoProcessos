﻿namespace GerenciamentoProcessos.Controllers.Dtos
{
    public class CriarDistribuicaoProcessoDto
    {
        public Guid? ProcessoId { get; set; }
        public Guid? ProcuradorOrigemId { get; set; }
        public Guid? ProcuradorDestinoId { get; set; }
        public DateTime? DataTransferencia { get; set; }
    }
}

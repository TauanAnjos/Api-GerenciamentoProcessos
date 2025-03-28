﻿using GerenciamentoProcessos.Controllers.Dtos;

namespace GerenciamentoProcessos.Services.Interfaces
{
    public interface IProcuradorAppService
    {
        void CriarProcurador(CriarProcuradorDto criarProcuradorDto);
        void EditarProcurador(Guid id, EditarProcuradorDto editarProcuradorDto);
        ProcuradorDto BuscarProcuradorPorId(Guid id);
        List<ProcuradorDto> ListarProcuradores();
        void DeletarProcurador(Guid id);
    }
}

﻿using GerenciamentoProcessos.Controllers.Dtos;

namespace GerenciamentoProcessos.Services.Interfaces
{
    public interface IPrazoAppService
    {
        void CriarPrazo(CriarPrazoDto criarPrazoDto);
        void EditarPrazo(Guid id, EditarPrazoDto editarPrazoDto);
        PrazoDto BuscarPrazoPorId(Guid id);
        List<PrazoDto> ListarPrazos();
        void DeletarPrazo(Guid id);
    }
}

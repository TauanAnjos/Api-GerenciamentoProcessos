using GerenciamentoProcessos.Controllers.Dtos;

namespace GerenciamentoProcessos.Services.Interfaces
{
    public interface IProcessosAppService
    {
        void CriarProcesso(CriarProcessoDto criarProcessoDto);
        void EditarProcesso(Guid id);
        ProcessosDto BuscarProcessoPorId(Guid id);
        List<ProcessosDto> ListarProcessos();
        void DeletarProcesso(Guid id);

    }
}

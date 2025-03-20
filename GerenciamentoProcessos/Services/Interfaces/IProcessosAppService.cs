using GerenciamentoProcessos.Controllers.Dtos;

namespace GerenciamentoProcessos.Services.Interfaces
{
    public interface IProcessosAppService
    {
        void CriarProcesso(CriarProcessoDto criarProcessoDto);
        void EditarProcesso(Guid id, EditarProcessoDto editarProcessoDto);
        ProcessosDto BuscarProcessoPorId(Guid id);
        List<ProcessosDto> ListarProcessos(ProcessosFiltrosDto processosDto);
        void DeletarProcesso(Guid id);
        ProcessosDto BuscarProcessoPorClientePorId(Guid clienteId);

    }
}

using GerenciamentoProcessos.Controllers.Dtos;
using GerenciamentoProcessos.Services.Interfaces;

namespace GerenciamentoProcessos.Services.AppServices
{
    public class ProcessosAppService : IProcessosAppService
    {
        public ProcessosDto BuscarProcessoPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void CriarProcesso(CriarProcessoDto criarProcessoDto)
        {
            throw new NotImplementedException();
        }

        public void DeletarProcesso(DeletarProcessoDto deletarProcessoDto)
        {
            throw new NotImplementedException();
        }

        public void EditarProcesso(EditarProcessoDto editarProcessoDto)
        {
            throw new NotImplementedException();
        }

        public List<ProcessosDto> ListarProcessos()
        {
            throw new NotImplementedException();
        }
    }
}

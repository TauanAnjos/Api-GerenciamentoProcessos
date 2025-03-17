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

        public void DeletarProcesso(Guid id)
        {
            throw new NotImplementedException();
        }

        public void EditarProcesso(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<ProcessosDto> ListarProcessos()
        {
            throw new NotImplementedException();
        }
    }
}

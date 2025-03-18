using GerenciamentoProcessos.Controllers.Dtos;
using GerenciamentoProcessos.Services.Interfaces;

namespace GerenciamentoProcessos.Services.AppServices
{
    public class PrazoAppService : IPrazoAppService
    {
        public PrazoDto BuscarPrazoPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void CriarPrazo(CriarPrazoDto criarPrazoDto)
        {
            throw new NotImplementedException();
        }

        public void DeletarPrazo(Guid id)
        {
            throw new NotImplementedException();
        }

        public void EditarPrazo(Guid id, EditarPrazoDto editarPrazoDto)
        {
            throw new NotImplementedException();
        }

        public List<PrazoDto> ListarPrazos()
        {
            throw new NotImplementedException();
        }
    }
}

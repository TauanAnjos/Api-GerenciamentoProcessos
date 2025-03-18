using AutoMapper;
using GerenciamentoProcessos.Controllers.Dtos;
using GerenciamentoProcessos.Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CriarProcessoDto, Processo>();
        CreateMap<CriarClienteDto, Cliente>();
        CreateMap<CriarDistribuicaoProcessoDto, DistribuicaoProcesso>();
        CreateMap<CriarDocumentoDto, Documento>();
        CreateMap<CriarPrazoDto, Prazo>();
        CreateMap<CriarProcuradorDto, Procurador>();
    }
}

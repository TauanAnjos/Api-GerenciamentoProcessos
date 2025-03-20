using AutoMapper;
using GerenciamentoProcessos.Controllers.Dtos;
using GerenciamentoProcessos.Controllers.Enuns;
using GerenciamentoProcessos.Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CriarProcessoDto, Processo>().ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)src.StatusProcesso));
        CreateMap<CriarClienteDto, Cliente>();
        CreateMap<CriarDistribuicaoProcessoDto, DistribuicaoProcesso>();
        CreateMap<CriarDocumentoDto, Documento>();
        CreateMap<CriarPrazoDto, Prazo>().ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)src.StatusPrazo));
        CreateMap<CriarProcuradorDto, Procurador>();

        CreateMap<Processo, ProcessosDto>().ForMember(dest => dest.StatusProcesso, opt => opt.MapFrom(src => (StatusProcesso)src.Status))
            .ForMember(dest => dest.Prazo, opt => opt.MapFrom(src => src.Prazos));
        CreateMap<Cliente, ClienteDto>();
        CreateMap<DistribuicaoProcesso, DistribuicaoProcessoDto>();
        CreateMap<Documento, DocumentoDto>();
        CreateMap<Procurador, ProcuradorDto>();
        CreateMap<Prazo, PrazoDto>().ForMember(dest => dest.StatusPrazo, opt => opt.MapFrom(src => (StatusPrazo)src.Status));
    }
}

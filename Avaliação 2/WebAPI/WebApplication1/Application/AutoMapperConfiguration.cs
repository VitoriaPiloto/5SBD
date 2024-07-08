using AutoMapper;
using WebApplication1.Model;
using WebApplication1.ViewModel;

namespace WebApplication1.Application
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Pedidos, PedidosViewModel>();
               
            CreateMap<PedidosViewModel, Pedidos>();

            CreateMap<ItensPedidoViewModel, ItensPedido>()
                .ForMember(dto => dto.Quantidade , x => x.MapFrom(y => y.Quantidade))
                .ForMember(dto => dto.IdProduto, x => x.MapFrom(y => y.IdProduto));

            CreateMap<ItensPedido, ItensPedidoViewModel>()
                .ForMember(dto => dto.IdProduto, x => x.MapFrom(y => y.IdProduto))
                .ForMember(dto => dto.Quantidade, x => x.MapFrom(y => y.Quantidade));
            
            CreateMap<ComprasEstoqueViewModel, ComprasEstoque>()
                .ForMember(dto => dto.Quantidade , x => x.MapFrom(y => y.Quantidade))
                .ForMember(dto => dto.CodigoProduto, x => x.MapFrom(y => y.CodigoProduto));

            CreateMap<ComprasEstoque, ComprasEstoqueViewModel>()
                .ForMember(dto => dto.CodigoProduto, x => x.MapFrom(y => y.CodigoProduto))
                .ForMember(dto => dto.Quantidade, x => x.MapFrom(y => y.Quantidade));
        }
    }
}

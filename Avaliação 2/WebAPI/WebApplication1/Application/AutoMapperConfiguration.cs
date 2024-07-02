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
        }
    }
}

using WebApplication1.Model;

namespace WebApplication1.ViewModel
{
    public class PedidosViewModel
    {
        public string DataCompra { get; set; }

        public string DataPagamento { get; set; }

        public string Cpf { get; set; }

        public IList<ItensPedidoViewModel> ItensPedidos { get; set; }
    }
}

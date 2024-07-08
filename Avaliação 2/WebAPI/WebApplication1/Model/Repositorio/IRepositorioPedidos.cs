namespace WebApplication1.Model.Repositorio
{
    public interface IRepositorioPedidos
    {
        public IList<Pedidos> ObterPedidos();

        public bool SalvarPedido(Pedidos pedido);

        public int ObterProximaChave();
    }
}

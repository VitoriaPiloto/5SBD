namespace WebApplication1.Model.Repositorio
{
    public interface IRepositorioItensPedido
    {
        public IList<ItensPedido> ObterItensPedidos();

        public IList<ItensPedido> ObterItemPedido(string codigoPedido);

        public bool SalvarItensPedido(ItensPedido itemPedido);

        public int ObterProximaChave();
    }
}

namespace WebApplication1.Model.Repositorio
{
    public interface IRepositorioClientes
    {
        public IList<Clientes> ObterClientes();

        public bool SalvarCliente(Clientes cliente);
    }
}

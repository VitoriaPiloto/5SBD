namespace WebApplication1.Model.Repositorio
{
    public interface IRepositorioComprasEstoque
    {
        public bool SalvarComprasEstoque(ComprasEstoque comprasEstoque);

        public int ObterProximaChave();

    }
}

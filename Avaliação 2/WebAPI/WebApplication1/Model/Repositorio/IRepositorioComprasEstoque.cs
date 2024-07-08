namespace WebApplication1.Model.Repositorio
{
    public interface IRepositorioComprasEstoque
    {
        public IList<ComprasEstoque> ObterComprasEstoques();

        public ComprasEstoque ObterCompraEstoque(string codigoProduto);

        public bool ExisteCompraPendenteParaProduto(string codigoProduto);

        public bool SalvarComprasEstoque(ComprasEstoque comprasEstoque);

        public bool ApagarCompraEstoque(ComprasEstoque comprasEstoque);

        public int ObterProximaChave();

    }
}

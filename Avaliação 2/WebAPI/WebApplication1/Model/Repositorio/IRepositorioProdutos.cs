namespace WebApplication1.Model.Repositorio
{
    public interface IRepositorioProdutos
    {
        public IList<Produtos> ObterProdutos();

        public Produtos ObterProduto(string codigoProduto);

        public bool SalvarProdutos(Produtos produto);

        public bool ProdutoExistente (string codigoProduto);
    }
}

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WebApplication1.Model.Repositorio
{
    public interface IRepositorioEstoque
    {
        public IList<Estoque> ObterItensDoEstoques();

        public Estoque ObterItemEstoque(string codigoproduto);

        public int ObterQuantidadeProduto(string codigoProduto);

        public bool SalvarEstoque(Estoque estoque);

        public bool AtualizarEstoque (Estoque estoque);
    }
}

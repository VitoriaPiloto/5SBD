using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.ViewModel
{
    public class ProdutosViewModel
    {
        public string Sku { get; set; }

        public string NomeProduto { get; set; }

        public string Moeda { get; set; }

        public double Preco { get; set; }
    }
}

namespace WebApplication1.Model.Repositorio
{
    public interface IRepositorioAtendimentos
    {
        public bool SalvarAtendimento(Atendimentos atendimento);

        public int ObterProximaChave();
    }
}

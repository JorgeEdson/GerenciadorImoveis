namespace GerenciadorImoveis.Dominio.Entidades
{
    public abstract class Entidade
    {
        protected Entidade(Usuario cadastradoPor)
        {            
            
        }

        protected Entidade()
        {
            
        }

        public long Id { get; set; }
        public bool Ativo { get; set; }
    }
}

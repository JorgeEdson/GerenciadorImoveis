namespace GerenciadorImoveis.Dominio.Entidades
{
    public abstract class Entidade
    {
        protected Entidade(Usuario cadastradoPor)
        {
            
            DataCadastro = DateTime.Now;
        }

        protected Entidade()
        {
            DataCadastro = DateTime.Now;            
        }

        public long Id { get; set; }
        
        public DateTime DataCadastro { get; set; }        
        public DateTime? DataAtualizacao { get; set; }
        public bool Ativo { get; set; }
    }
}

namespace GerenciadorImoveis.Dominio.Entidades
{
    public class Evento : Entidade
    {
        #region Propriedades                
        public string Descricao { get; private set; }
        #endregion

        #region Construtores
        public Evento(Usuario usuarioAcao, DateTime data, string descricao)
        {
            CadastradoPor = usuarioAcao;
            DataCadastro = data;
            Descricao = descricao;
            Ativo = true;
        }
        public Evento()
        {
            Ativo = true;
        }
        #endregion

    }
}

namespace GerenciadorImoveis.Dominio.Entidades
{
    public class Planta : Entidade
    {
        #region Propriedades
        public long ImovelId { get; private set; }
        public Imovel Imovel { get; private set; }
        public long ArquivoId { get; private set; }
        public Arquivo Arquivo { get; private set; }
        #endregion

        #region Construtores
        public Planta(Imovel imovel, Arquivo arquivo, Usuario cadastradoPor)
        {
            Imovel = imovel;
            Arquivo = arquivo;
            CadastradoPor = cadastradoPor;
            Ativo = true;
        }
        public Planta()
        {
            Ativo = true;
        }
        #endregion

    }
}
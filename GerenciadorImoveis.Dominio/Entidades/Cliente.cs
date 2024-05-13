namespace GerenciadorImoveis.Dominio.Entidades
{
    public class Cliente : Entidade
    {
        #region Propriedades
        public string Nome { get; private set; }
        public string Nacionalidade { get; private set; }
        public string Profissao { get; private set; }
        public long DocumentoId { get; private set; }
        public Documento Documento { get; private set; }
        public long EnderecoId { get; private set; }
        public Endereco Endereco { get; private set; }        
        public ICollection<Imovel> Imoveis { get; private set; }
        //public ICollection<Contrato> Contratos { get; private set; }
        #endregion

        #region Construtores
        public Cliente(string nome, string nacionalidade, string profissao,Documento documento,Endereco endereco, Usuario cadastradoPor)
        {
            Nome = nome;
            Nacionalidade = nacionalidade;
            Profissao = profissao;
            Documento = documento;
            Endereco = endereco;
            CadastradoPor = cadastradoPor;
            Imoveis = new HashSet<Imovel>();
            //Contratos = new HashSet<Contrato>();
            Ativo = true;
        }
        public Cliente()
        {
            Imoveis = new HashSet<Imovel>();
            //Contratos = new HashSet<Contrato>();
            Ativo = true;
        }
        #endregion

        #region Metodos publicos
        public void VincularDocumento(Documento documento)
        {
            Documento = documento;
        }

        public void VincularImovel(Imovel imovel)
        {
            Imoveis.Add(imovel);
        }   
        
        public void DesvincularImovel(Imovel imovel)
        {
            Imoveis.Remove(imovel);
        }
        
        //public void VincularContrato(Contrato contrato)
        //{
        //    Contratos.Add(contrato);
        //}
        
        public void VincularEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }
        
        public void AlterarNome(string nome)
        {
            Nome = nome;            
        }

        public void AlterarNacionalidade(string nacionalidade)
        {
            Nacionalidade = nacionalidade;
        }

        public void AlterarProfissao(string profissao)
        {
            Profissao = profissao;
        }

        public void AlterarEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }
        #endregion
    }
}

using GerenciadorImoveis.Dominio.Enumeradores;

namespace GerenciadorImoveis.Dominio.Entidades
{
    public class Evento : Entidade
    {
        #region Propriedades                
        public string Mensagem { get; private set; }
        public DateTime DataOcorrencia { get; private set; }
        public TipoEvento TipoEvento { get; private set; }
        public long UsuarioId { get; private set; }
        public Usuario UsuarioAcao { get; private set; }
        public long? ClienteId { get; private set; }
        public Cliente? Cliente { get; private set; }
        public long? EnderecoId { get; private set; }
        public Endereco? Endereco { get; private set; }
        public long? ImovelId { get; private set; }
        public Imovel? Imovel { get; private set; }
        public long? ArquivoId { get; private set; }
        public Arquivo? Arquivo { get; private set; }
        public long? MatriculaId { get; private set; }
        public Matricula? Matricula { get; private set; }
        public long? PlantaId { get; private set; }
        public Planta? Planta { get; private set; }
        #endregion

        #region Construtores
        public Evento(Usuario usuarioAcao, DateTime data, string mensagem, TipoEvento tipoEvento)
        {
            VincularUsuario(usuarioAcao);
            DataOcorrencia = data;
            Mensagem = mensagem;
            TipoEvento = tipoEvento;
            Ativo = true;
        }
        public Evento()
        {
            Ativo = true;
        }
        #endregion

        #region Metodos publicos
        public void VincularUsuario(Usuario usuario)
        {
            UsuarioAcao = usuario;
            UsuarioId = usuario.Id;
        }
        public void VincularCliente(Cliente cliente)
        {
            Cliente = cliente;
            ClienteId = cliente.Id;
        }
        public void VincularEndereco(Endereco endereco)
        {
            Endereco = endereco;
            EnderecoId = endereco.Id;
        }
        public void VincularImovel(Imovel imovel)
        {
            Imovel = imovel;
            ImovelId = imovel.Id;
        }
        public void VincularArquivo(Arquivo arquivo)
        {
            Arquivo = arquivo;
            ArquivoId = arquivo.Id;
        }
        public void VincularMatricula(Matricula matricula)
        {
            Matricula = matricula;
            MatriculaId = matricula.Id;
        }
        public void VincularPlanta(Planta planta)
        {
            Planta = planta;
            PlantaId = planta.Id;
        }

        #endregion

    }
}

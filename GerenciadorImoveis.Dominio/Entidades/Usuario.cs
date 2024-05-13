using GerenciadorImoveis.Dominio.Enumeradores;

namespace GerenciadorImoveis.Dominio.Entidades
{
    public class Usuario : Entidade
    {
        #region Propriedades
        public string NomeCompleto { get; private set; }
        public string NomeUsuario { get; private set; }
        public string Senha { get; private set; }
        public TipoUsuario TipoUsuario { get; private set; }
        public ICollection<Evento> Eventos { get; private set; }
        public ICollection<Cliente> ClientesCadastrados { get; private set; }
        public ICollection<Cliente> ClientesAlterados { get; private set; }
        public ICollection<Documento> DocumentosCadastrados { get; private set; }
        public ICollection<Documento> DocumentosAlterados { get; private set; }
        public ICollection<Imovel> ImoveisCadastrados { get; private set; }
        public ICollection<Imovel> ImoveisAlterados { get; private set; }
        public ICollection<Endereco> EnderecosCadastrados { get; private set; }
        public ICollection<Endereco> EnderecosAlterados { get; private set; }
        public ICollection<Planta> PlantasCadastradas { get; private set; }
        public ICollection<Planta> PlantasAlteradas { get; private set; }
        public ICollection<Matricula> MatriculasCadastradas { get; private set; }
        public ICollection<Matricula> MatriculasAlteradas { get; private set; }
        public ICollection<Arquivo> ArquivosCadastrados { get; private set; }        
        public ICollection<Arquivo> ArquivosAlterados { get; private set; }        
        public ICollection<Usuario> UsuariosCadastrados { get; private set; }
        public ICollection<Usuario> UsuariosAlterados { get; private set; }
        #endregion

        #region Construtores
        public Usuario(string nomeUsuario, string senha, TipoUsuario tipoUsuario)
        {
            NomeUsuario = nomeUsuario;
            Senha = senha;
            TipoUsuario = tipoUsuario;
            Ativo = true;
            Eventos = new HashSet<Evento>();
            ClientesCadastrados = new HashSet<Cliente>();
            ClientesAlterados = new HashSet<Cliente>();
            DocumentosCadastrados = new HashSet<Documento>();
            DocumentosAlterados = new HashSet<Documento>();
            ImoveisCadastrados = new HashSet<Imovel>();
            ImoveisAlterados = new HashSet<Imovel>();
            EnderecosCadastrados = new HashSet<Endereco>();
            EnderecosAlterados = new HashSet<Endereco>();
            PlantasCadastradas = new HashSet<Planta>();
            PlantasAlteradas = new HashSet<Planta>();
            MatriculasCadastradas = new HashSet<Matricula>();
            MatriculasAlteradas = new HashSet<Matricula>();
            ArquivosCadastrados = new HashSet<Arquivo>();
            ArquivosAlterados = new HashSet<Arquivo>();
            UsuariosCadastrados = new HashSet<Usuario>();
            UsuariosAlterados = new HashSet<Usuario>();
        }

        public Usuario()
        {
            Ativo = true;
            Eventos = new HashSet<Evento>();
            ClientesCadastrados = new HashSet<Cliente>();
            ClientesAlterados = new HashSet<Cliente>();
            DocumentosCadastrados = new HashSet<Documento>();
            DocumentosAlterados = new HashSet<Documento>();
            ImoveisCadastrados = new HashSet<Imovel>();
            ImoveisAlterados = new HashSet<Imovel>();
            EnderecosCadastrados = new HashSet<Endereco>();
            EnderecosAlterados = new HashSet<Endereco>();
            PlantasCadastradas = new HashSet<Planta>();
            PlantasAlteradas = new HashSet<Planta>();
            MatriculasCadastradas = new HashSet<Matricula>();
            MatriculasAlteradas = new HashSet<Matricula>();
            ArquivosCadastrados = new HashSet<Arquivo>();
            ArquivosAlterados = new HashSet<Arquivo>();
            UsuariosCadastrados = new HashSet<Usuario>();
            UsuariosAlterados = new HashSet<Usuario>();
        }
        #endregion

        #region Metodos publicos
        #endregion
    }
}

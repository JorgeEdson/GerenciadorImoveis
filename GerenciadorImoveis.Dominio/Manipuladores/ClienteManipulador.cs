using GerenciadorImoveis.Dominio.Comunicacao;
using GerenciadorImoveis.Dominio.Comunicacao.Requisicoes;
using GerenciadorImoveis.Dominio.Entidades;
using GerenciadorImoveis.Dominio.Enumeradores;
using GerenciadorImoveis.Dominio.Interfaces;
using GerenciadorImoveis.Dominio.Interfaces.Repositorios;

namespace GerenciadorImoveis.Dominio.Manipuladores
{
    public class ClienteManipulador
        (
            IClienteRepositorio clienteRepositorio,
            IUsuarioRepositorio usuarioRepositorio,            
            IDocumentoRepositorio documentoRepositorio,
            IEnderecoRepositorio enderecoRepositorio,
            IEventoRepositorio eventoRepositorio
        ) :
        IManipulador<CadastrarClienteRequisicao>
    {
        public async Task<ResultadoGenerico> Executar(CadastrarClienteRequisicao requisicao)
        {
            #region Validacao requisicao
            bool requisicaoValida;
            if (
                    string.IsNullOrEmpty(requisicao.Nome) ||
                    string.IsNullOrEmpty(requisicao.Nacionalidade) ||
                    string.IsNullOrEmpty(requisicao.Profissao) ||
                    string.IsNullOrEmpty(requisicao.DocumentoIdentificador) ||
                    requisicao.TipoDocumento == 0 ||
                    string.IsNullOrEmpty(requisicao.Logradouro) ||
                    string.IsNullOrEmpty(requisicao.Bairro) ||
                    string.IsNullOrEmpty(requisicao.Cidade) ||
                    requisicao.UF == 0 ||
                    string.IsNullOrEmpty(requisicao.Cep) ||
                    requisicao.CadastradoPorId == 0
                )
                requisicaoValida = false;
            else
                requisicaoValida = true;

            if (!requisicaoValida)
                return new ResultadoGenerico(false, "Dados obrigatorios nao preenchidos", requisicao);
            #endregion

            #region Usuario responsavel
            //recuperar usuario responsavel
            var usuarioResponsavel = await usuarioRepositorio
                .ObterAtivoPorIdAsync(requisicao.CadastradoPorId);

            if (usuarioResponsavel == null)
                return new ResultadoGenerico
                    (
                        false,
                        "Usuário responsavel não encontrado",
                        requisicao.CadastradoPorId
                    );
            #endregion

            #region Documento
            // Verifica se o documento já existe
            var documento = await documentoRepositorio
                .ObterDocumentoPorIdentificadorAsync(requisicao.DocumentoIdentificador);

            if (documento != null)
                return new ResultadoGenerico(false, "Documento já cadastrado", documento);


            //montar documento
            documento = new Documento
                (
                    requisicao.DocumentoIdentificador,
                    (TipoDocumento)requisicao.TipoDocumento                    
                );

            //salvar documento
            await documentoRepositorio.SalvarAsync(documento);
            #endregion

            #region Endereco
            //montar endereco
            var endereco = new Endereco
                (
                    requisicao.Logradouro,
                    requisicao.Bairro,
                    requisicao.Cidade,
                    (UF)requisicao.UF,
                    requisicao.Cep                    
                );

            //salvar endereco
            await enderecoRepositorio.SalvarAsync(endereco);
            #endregion

            #region Cliente
            //montar cliente
            var cliente = new Cliente
                (
                    requisicao.Nome,
                    requisicao.Nacionalidade,
                    requisicao.Profissao,
                    documento,
                    endereco                    
                );

            //salvar cliente
            await clienteRepositorio.SalvarAsync(cliente);
            #endregion

            #region Evento
            //montar evento
            var evento = new Evento
                (
                    usuarioResponsavel,
                    DateTime.Now,
                    $"Cadastro - Cliente: {cliente.Nome} | Documento: {documento.Identificador}",
                    TipoEvento.CADASTRO
                );

            //salvar evento
            await eventoRepositorio.SalvarAsync(evento);
            #endregion

            return new ResultadoGenerico(true, "Cliente cadastrado com sucesso", cliente);
        }
    }
}

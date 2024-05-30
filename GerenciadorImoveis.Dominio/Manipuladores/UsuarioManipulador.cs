

using GerenciadorImoveis.Dominio.Ajudantes;
using GerenciadorImoveis.Dominio.Comunicacao;
using GerenciadorImoveis.Dominio.Comunicacao.Requisicoes;
using GerenciadorImoveis.Dominio.Entidades;
using GerenciadorImoveis.Dominio.Enumeradores;
using GerenciadorImoveis.Dominio.Interfaces.Repositorios;

namespace GerenciadorImoveis.Dominio.Manipuladores
{
    public class UsuarioManipulador
        (
            IUsuarioRepositorio usuarioRepositorio,
            IEventoRepositorio eventoRepositorio
        )
    {
        public async Task<ResultadoGenerico> Executar(AutenticarUsuarioRequisicao requisicao) 
        {
            try
            {
                #region Validacao requisicao
                bool requisicaoValida;
                if (
                    string.IsNullOrEmpty(requisicao.NomeUsuario) ||
                    string.IsNullOrEmpty(requisicao.Senha)
                   )
                    requisicaoValida = false;
                else
                    requisicaoValida = true;

                if (!requisicaoValida)
                    return new ResultadoGenerico(false, "Dados obrigatorios nao preenchidos", requisicao);
                #endregion

                #region Autenticar Usuario                
                var usuario = await usuarioRepositorio
                    .AutenticarUsuario
                    (
                        requisicao.NomeUsuario, 
                        Encriptacao.AdicionarCriptografia(requisicao.Senha)
                    );

                if (usuario == null)
                    return new ResultadoGenerico(false, "Usuario nao encontrado", requisicao);
                
                //montar evento
                var eventoAutenticacao = new Evento
                (
                    usuario,
                    DateTime.Now,
                    $"Autenticado - Usuario: {usuario.NomeUsuario}",
                    TipoEvento.AUTENTICACAO
                );

                //salvar evento
                await eventoRepositorio.SalvarAsync(eventoAutenticacao);
                #endregion

                return new ResultadoGenerico(true, "Usuario autenticado", usuario);
            }
            catch (Exception ex)
            {
                return new ResultadoGenerico(false, ex.Message, requisicao);
            }

        }
    }
}

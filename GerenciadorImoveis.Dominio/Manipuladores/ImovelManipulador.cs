using GerenciadorImoveis.Dominio.Comunicacao;
using GerenciadorImoveis.Dominio.Comunicacao.Requisicoes;
using GerenciadorImoveis.Dominio.Entidades;
using GerenciadorImoveis.Dominio.Enumeradores;
using GerenciadorImoveis.Dominio.Interfaces;
using GerenciadorImoveis.Dominio.Interfaces.Repositorios;
using Microsoft.AspNetCore.Http;

namespace GerenciadorImoveis.Dominio.Manipuladores
{
    public class ImovelManipulador
        (
            IUsuarioRepositorio usuarioRepositorio,
            IClienteRepositorio clienteRepositorio,
            IImovelRepositorio imovelRepositorio,            
            IEnderecoRepositorio enderecoRepositorio,
            IMatriculaRepositorio matriculaRepositorio,
            IPlantaRepositorio plantaRepositorio,
            IEventoRepositorio eventoRepositorio,
            IArquivoRepositorio arquivoRepositorio,
            IManipularArquivo manipuladorArquivo
        ) :
        IManipuladorComListaArquivos<CadastrarImovelRequisicao, IFormFile>
    {
        public async Task<ResultadoGenerico> Executar(CadastrarImovelRequisicao requisicao, List<IFormFile> listaArquivos)
        {
            try 
            {
                #region Validacao requisicao
                bool requisicaoValida;
                if (
                        requisicao.CadastradoPorId == 0 ||
                        requisicao.TipoImovel == 0 ||
                        requisicao.ImovelStatus == 0 ||
                        requisicao.ProprietarioId == 0 ||
                        string.IsNullOrEmpty(requisicao.Logradouro) ||
                        string.IsNullOrEmpty(requisicao.Bairro) ||
                        string.IsNullOrEmpty(requisicao.Cidade) ||
                        requisicao.UF == 0 ||
                        string.IsNullOrEmpty(requisicao.Cep) ||
                        requisicao.AreaTerreno == 0 ||
                        requisicao.ValorAquisicao == 0 ||
                        string.IsNullOrEmpty(requisicao.DataAquisicao)
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

                #region Proprietario
                //recuperar proprietario
                var proprietario = await clienteRepositorio
                    .ObterAtivoPorIdAsync(requisicao.ProprietarioId);

                if (proprietario == null)
                    return new ResultadoGenerico
                        (
                            false,
                            "Proprietario não encontrado",
                            requisicao.ProprietarioId
                        );
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

                //montar evento
                var eventoEndereco = new Evento
                    (
                        usuarioResponsavel,
                        DateTime.Now,
                        $"Cadastro - Endereco: {endereco.Logradouro}",
                        TipoEvento.CADASTRO
                     );
                eventoEndereco.VincularEndereco(endereco);

                //salvar evento
                await eventoRepositorio.SalvarAsync(eventoEndereco);
                #endregion

                #region Imovel
                //montar imovel            
                var imovel = new Imovel
                    (
                        (TipoImovel)requisicao.TipoImovel,
                        proprietario,
                        endereco,
                        requisicao.AreaTerreno,
                        requisicao.AreaEdificacao,
                        requisicao.ValorAquisicao,
                        DateTime.Parse(requisicao.DataAquisicao),
                        (ImovelStatus)requisicao.ImovelStatus,
                        usuarioResponsavel);

                //salvar imovel e pegar o id do imovel
                var idImovelSalvo = await imovelRepositorio.SalvarAsync(imovel);

                //montar evento
                var eventoImovel = new Evento
                    (
                        usuarioResponsavel,
                        DateTime.Now,
                        $"Cadastro - Imovel: {imovel.Id}",
                        TipoEvento.CADASTRO
                    );
                eventoImovel.VincularImovel(imovel);

                //salvar evento
                await eventoRepositorio.SalvarAsync(eventoImovel);
                #endregion

                #region Matricula
                //pegar arquivo de matricula
                var arquivoMatricula = listaArquivos.FirstOrDefault(x => x.Name == "matricula");

                if (arquivoMatricula == null)
                    return new ResultadoGenerico(false, "Arquivo de matricula não encontrado", requisicao);

                //montar arquivo entidade
                var arquivoMatriculaEntidade = new Arquivo(TipoArquivo.MATRICULA);

                //salvar aquivo entidade
                await arquivoRepositorio.SalvarAsync(arquivoMatriculaEntidade);

                //salvar arquivo em disco
                var caminhoArquivoMatricula
                    = await manipuladorArquivo.SalvarArquivoAsync(arquivoMatricula, idImovelSalvo);

                //atualizar entidade com caminho e salva a matricula
                arquivoMatriculaEntidade.AtualizarCaminho(caminhoArquivoMatricula.Dados.ToString());
                await arquivoRepositorio.AtualizarAsync(arquivoMatriculaEntidade);

                //montar matricula
                var matricula = new Matricula(imovel, arquivoMatriculaEntidade);

                //salvar matricula
                await matriculaRepositorio.SalvarAsync(matricula);

                //montar evento
                var eventoArquivoMatricula = new Evento
                    (
                        usuarioResponsavel,
                        DateTime.Now,
                        $"Cadastro - Matricula do Imovel {imovel.Id} | Arquivo: {arquivoMatricula.FileName}",
                        TipoEvento.CADASTRO
                    );
                eventoArquivoMatricula.VincularMatricula(matricula);

                //salvar evento
                await eventoRepositorio.SalvarAsync(eventoArquivoMatricula);
                #endregion

                #region Planta
                //pegar arquivo de Planta
                var arquivoPlanta = listaArquivos.FirstOrDefault(x => x.Name == "planta");

                if (arquivoPlanta != null)
                {
                    //montar arquivo entidade
                    var arquivoPlantaEntidade = new Arquivo(TipoArquivo.PLANTA);

                    //salvar aquivo entidade
                    await arquivoRepositorio.SalvarAsync(arquivoPlantaEntidade);

                    //salvar arquivo em disco
                    var caminhoArquivoPlanta
                        = await manipuladorArquivo.SalvarArquivoAsync(arquivoPlanta, idImovelSalvo);

                    //atualizar entidade com caminho
                    arquivoPlantaEntidade.AtualizarCaminho(caminhoArquivoPlanta.Dados.ToString());
                    await arquivoRepositorio.AtualizarAsync(arquivoPlantaEntidade);

                    //montar planta
                    var planta = new Planta(imovel, arquivoPlantaEntidade);

                    //salvar planta
                    await plantaRepositorio.SalvarAsync(planta);

                    //montar evento
                    var eventoArquivoPlanta = new Evento
                        (
                            usuarioResponsavel,
                            DateTime.Now,
                            $"Cadastro - Planta do imovel {imovel.Id} | Arquivo: {arquivoPlanta.FileName}",
                            TipoEvento.CADASTRO
                        );
                    eventoArquivoPlanta.VincularPlanta(planta);

                    //salvar evento
                    await eventoRepositorio.SalvarAsync(eventoArquivoPlanta);
                }
                #endregion

                return new ResultadoGenerico(true, "Imovel cadastrado com sucesso", imovel);
            }
            catch (Exception ex)
            {
                return new ResultadoGenerico(false, ex.Message, requisicao);
            }            
        }
    }
}

using GerenciadorImoveis.Dominio.Comunicacao;
using GerenciadorImoveis.Dominio.Interfaces;
using Microsoft.AspNetCore.Http;

namespace GerenciadorImoveis.Infraestrutura.EntradaSaida
{
    public class ManipularArquivo : IManipularArquivo
    {
        //cria uma propriedade com o caminho raiz e ja passa um valor fixo
        private string CaminhoRaiz { get; set; } = "C:\\ArquivosGerenciadorImoveis";

        public async Task<ResultadoGenerico> SalvarArquivoAsync(IFormFile arquivo, long idImovel)
        {
            try
            {
                // Verifica se o arquivo é nulo ou se não tem conteúdo
                if (arquivo == null || arquivo.Length == 0)
                    return new ResultadoGenerico(false, "Arquivo não especificado ou vazio", null);

                // Cria o diretório alvo se não existir
                if (!Directory.Exists(CaminhoRaiz))
                    Directory.CreateDirectory(CaminhoRaiz);

                // Cria o nome da pasta com base no idArquivo
                var nomePasta = "Imovel - "+idImovel.ToString();

                // Constrói o caminho completo da pasta do arquivo
                var caminhoPasta = Path.Combine(CaminhoRaiz, nomePasta);

                // Cria a pasta se não existir
                if (!Directory.Exists(caminhoPasta))
                    Directory.CreateDirectory(caminhoPasta);

                // Gera um nome do arquivo com base no idArquivo mantendo a extensao
                var nomeArquivo = $"{arquivo.FileName}{Path.GetExtension(arquivo.FileName)}";

                // Constrói o caminho completo do arquivo
                var caminhoArquivo = Path.Combine(caminhoPasta, nomeArquivo);

                // Copia o conteúdo do arquivo para o destino
                using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
                {
                    await arquivo.CopyToAsync(stream);
                }

                return new ResultadoGenerico(true, "Arquivo salvo com sucesso!", caminhoArquivo);
            }
            catch (Exception ex)
            {
                return new ResultadoGenerico(false, ex.Message, null);
            }
        }
    }
}

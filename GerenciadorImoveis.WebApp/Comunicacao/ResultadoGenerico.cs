using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorImoveis.Dominio.Comunicacao
{
    public class ResultadoGenerico(bool sucesso, string mensagem, object dados)
    {
        public bool Sucesso { get; set; } = sucesso;
        public string Mensagem { get; set; } = mensagem;
        public object Dados { get; set; } = dados;
    }
}

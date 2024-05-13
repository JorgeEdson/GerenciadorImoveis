using GerenciadorImoveis.Dominio.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorImoveis.Dominio.Entidades
{
    public class Endereco : Entidade
    {
        //criar region para propriedades, construtor e metodos
        #region Propriedades
        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public UF UF { get; private set; }
        public string Cep { get; private set; }
        public ICollection<Cliente> Clientes { get; private set; }
        public long ImovelId { get; private set; }
        public Imovel Imovel { get; private set; }
        #endregion
        #region Construtores
        public Endereco(string logradouro, string bairro, string cidade, UF uf, string cep, Usuario cadastradoPor)
        {
            Logradouro = logradouro;
            Bairro = bairro;
            Cidade = cidade;
            UF = uf;
            Cep = cep;
            CadastradoPor = cadastradoPor;
            Ativo = true;
        }
        public Endereco()
        {
            Ativo = true;
        }

        #endregion
        #region Metodos Publicos
        public void AlterarLogradouro(string logradouro)
        {
            Logradouro = logradouro;
        }
        public void AlterarBairro(string bairro)
        {
            Bairro = bairro;
        }
        public void AlterarCidade(string cidade)
        {
            Cidade = cidade;
        }
        public void AlterarUF(UF uf)
        {
            UF = uf;
        }
        public void AlterarCep(string cep)
        {
            Cep = cep;
        }
        
        public void DesativarEndereco()
        {
            Ativo = false;
        }
        #endregion

    }
}

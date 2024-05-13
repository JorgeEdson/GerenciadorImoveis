using GerenciadorImoveis.Dominio.Entidades;
using GerenciadorImoveis.Dominio.Interfaces.Repositorios;
using GerenciadorImoveis.Infraestrutura.Contexto;
using System;

namespace GerenciadorImoveis.Infraestrutura.Repositorios
{
    public class EventoRepositorio : RepositorioBase<Evento>, IEventoRepositorio
    {
        public EventoRepositorio(ContextoBancoDeDados contexto) : base(contexto)
        {
                
        }
    }
}

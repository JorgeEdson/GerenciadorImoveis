using GerenciadorImoveis.Dominio.Entidades;
using GerenciadorImoveis.Dominio.Interfaces.Repositorios;
using GerenciadorImoveis.Infraestrutura.Contexto;

namespace GerenciadorImoveis.Infraestrutura.Repositorios
{
    public class PlantaRepositorio : RepositorioBase<Planta>, IPlantaRepositorio
    {
        public PlantaRepositorio(ContextoBancoDeDados contexto) : base(contexto)
        {
        }
    }
}

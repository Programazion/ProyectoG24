using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public interface IRepositorioEquipo
    { 
        public Equipo AddEquipo(Equipo equipo, int idmunicipio, int idDT);
    }
}
using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public class RepositorioPartido : IRepositorioPartido
    {

        private readonly DataContext _dataContext = new DataContext();
        public Partido AddPartido(Partido partido, int idLocal, int idVisitante)
        {
            DateTime FechaHora = new DateTime(2022,09,08);
        
            var equipolocalEncontrado = _dataContext.Equipos.Find(idLocal);
            partido.Local = equipolocalEncontrado;

            
            var equipoVisitanteEncontrado = _dataContext.Equipos.Find(idVisitante);
            partido.Visitante = equipoVisitanteEncontrado;

            var partidoInsertado = _dataContext.Partidos.Add(partido);
            _dataContext.SaveChanges();
            return partidoInsertado.Entity;
        }
    }
}
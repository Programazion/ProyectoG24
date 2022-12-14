using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public class RepositorioPosicion : IRepositorioPosicion
    {

        private readonly DataContext _dataContext = new DataContext();
        public Posicion AddPosicion(Posicion posicion)
        {
            var posicionInsertado = _dataContext.Posiciones.Add(posicion);
            _dataContext.SaveChanges();
            return posicionInsertado.Entity;
        }
        public IEnumerable<Posicion> GetAllPosiciones()
        {
            return  _dataContext.Posiciones;
        }   
    }
}
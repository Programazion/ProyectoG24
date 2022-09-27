using Microsoft.EntityFrameworkCore; // Revisar Repositorios DT
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public class RepositorioDT : IRepositorioDT
    {

        private readonly DataContext _dataContext = new DataContext();
        public DirectorTecnico AddDT(DirectorTecnico directorTecnico)
        {
            var DTInsertado = _dataContext.DTs.Add(directorTecnico);
            _dataContext.SaveChanges();
            return dtInsertado.Entity;
        }
    }
}

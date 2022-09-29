using Torneo.App.Dominio;
using Torneo.App.Persistencia;
namespace Torneo.App.Consola
{
    class Program
    {
        private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio();
        private static IRepositorioDT _repoDT = new RepositorioDT();
        private static IRepositorioEquipo _repoEquipo = new RepositorioEquipo();
        private static IRepositorioPartido _repoPartido = new RepositorioPartido();
        static void Main(string[] args)
        {
            int opcion = 0;
            do
            {
                Console.WriteLine("1. Insertar Municipio");
                Console.WriteLine("2. Insertar Director Técnico");
                Console.WriteLine("3. Insertar Equipo");
                Console.WriteLine("4. Insertar Partido");
                Console.WriteLine("0. Salir");
                opcion = Int32.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        AddMunicipio();
                        break;
                    case 2:
                        AddDT();
                        break;
                    case 3:
                        AddEquipo();
                        break;
                    case 4:
                        AddPartido();
                        break;
                }
            } while (opcion != 0);
        }
        private static void AddMunicipio()
        {
            Console.WriteLine("Escriba el nombre del municipio");
            string nombre = Console.ReadLine();
            var municipio = new Municipio
            {
                Nombre = nombre,
            };
            _repoMunicipio.AddMunicipio(municipio);
        }

        private static void AddDT()
        {
            Console.WriteLine("Escriba el nombre del DT");
            string nombre = Console.ReadLine();
            Console.WriteLine("Escriba el número de Documento");
            string documento = Console.ReadLine();
            Console.WriteLine("Escriba el telefono del DT");
            string telefono = Console.ReadLine();
            var directorTecnico = new DirectorTecnico
            {
                Nombre = nombre,
                Documento = documento,
                Telefono = telefono,
            };
            _repoDT.AddDT(directorTecnico);
        }
        private static void AddEquipo()
        {
            Console.WriteLine("Escriba el nombre del Equipo");
            string nombre = Console.ReadLine();
            Console.WriteLine("Escriba el id municipio");
            int idMunicipio = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Escriba el id del DT");
            int idDT = Int32.Parse(Console.ReadLine());
            var equipo = new Equipo
            {
                Nombre = nombre,
            };
            _repoEquipo.AddEquipo(equipo, idMunicipio, idDT);
        }
        private static void AddPartido()
        {
            Console.WriteLine("Digite la fecha del partido (mm-dd-yyyy):");
            string fechaHora = (Console.ReadLine());
            DateTime myDate = DateTime.Parse(fechaHora); //Código DevTeam
            
            /*DateTime FechaHora = new DateTime(2022,09,08);
            Console.WriteLine("Date = {0}", FechaHora);
            string str = FechaHora.ToString();*/

            Console.WriteLine("Escriba el ID del Equipo Local");
            int idLocal = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Escriba el marcador local");
            int marcadorLocal = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Escriba el ID del Equipo Visitante");
            int idVisitante = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Escriba el marcador visitante");
            int marcadorVisitante = Int32.Parse(Console.ReadLine());
            var partido = new Partido
            {
                MarcadorLocal = marcadorLocal,
                MarcadorVisitante = marcadorVisitante,
                FechaHora = myDate,
            };
            _repoPartido.AddPartido(partido, idLocal, idVisitante);
        }
    }
}
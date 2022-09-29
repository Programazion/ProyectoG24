using Torneo.App.Dominio;
using Torneo.App.Persistencia;
namespace Torneo.App.Consola
{
    class Program
    {
        private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio();
        private static IRepositorioDT _repoDT = new RepositorioDT();
        private static IRepositorioEquipo _repoEquipo = new RepositorioEquipo();
        private static IRepositorioPosicion _repoPosicion = new RepositorioPosicion();
        private static IRepositorioJugador _repoJugador = new RepositorioJugador();
        private static IRepositorioPartido _repoPartido = new RepositorioPartido();
        static void Main(string[] args)
        {
            int opcion = 0;
            do
            {
                Console.WriteLine("1. Insertar Municipio");
                Console.WriteLine("2. Insertar Director Técnico");
                Console.WriteLine("3. Insertar Equipo");
                Console.WriteLine("4. Insertar Posicion");
                Console.WriteLine("5. Insertar Jugador");
                Console.WriteLine("6. Insertar Partido");
                Console.WriteLine("7. Mostrar Municipios inscritos");
                Console.WriteLine("8. Mostrar Dts inscritos");
                Console.WriteLine("9. Mostrar Equipos inscritos");
                Console.WriteLine("10. Mostrar Jugadores Activos");
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
                        AddPosicion();
                        break;
                    case 5:
                        AddJugador();
                        break;

                    case 6:
                        AddPartido();
                        break;
                    case 7: 
                        GetAllMunicipios();
                        break;
                    case 8: 
                        GetAllDTs(); //Revisar desde acá todos los GetALl
                        break;
                    case 9: 
                        GetAllEquipos();
                        break;
                    /*case 10: 
                        GetAllPosiciones();
                        break;
                    case 11: 
                        GetAllJugadores();
                        break;
                    case 12: 
                        GetAllPartidos();
                        break;*/
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
        private static void AddPosicion()
        {
            Console.WriteLine("Escriba el nombre de la posicion");
            string nombre = Console.ReadLine();
            var posicion = new Posicion
            {
                Nombre = nombre,
            };
            _repoPosicion.AddPosicion(posicion);
        }
        private static void AddJugador()
        {
            Console.WriteLine("Escriba el nombre del jugador");
            string nombre = Console.ReadLine();

            Console.WriteLine("Escriba el numero del jugador");
            int numero = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Digite el iD del Equipo:");
            int idEquipo = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Digita el ID de la posicion");
            int idPosicion = Int32.Parse(Console.ReadLine());
            var jugador = new Jugador
            {
                Nombre = nombre,
                Numero = numero,
            };
            _repoJugador.AddJugador(jugador, idEquipo, idPosicion);
        }
        private static void GetAllMunicipios()
        {
            foreach (var municipio in _repoMunicipio.GetAllMunicipios())
            {
                Console.WriteLine(municipio.Id + " " + municipio.Nombre);
            }
        }
        private static void GetAllDTs() 
        {
            foreach (var dt in _repoDT.GetAllDTs())
            {
                Console.WriteLine(dt.Id + " " + dt.Nombre + " " + dt.Documento + " " + dt.Telefono + " " );
            }
        }
        private static void GetAllEquipos()
        {
            foreach (var equipo in _repoEquipo.GetAllEquipos())
            {
                Console.WriteLine(equipo.Id + "\t" + equipo.Nombre 
                + "\t"+ equipo.Municipio.Nombre + "\t" + equipo.DirectorTecnico.Nombre);
            }
        }
        /*private static void GetAllPartidos() //Por implementar
        {
            foreach (var partido in _repoPartido.GetAllPartidos())
            {
                Console.WriteLine(partido.Id + " " + partido.Nombre);
            }
        }
        private static void GetAllPosiciones() //Por implementar
        {
            foreach (var posicion in _repoPosicion.GetAllPosiciones())
            {
                Console.WriteLine(posicion.Id + " " + posicion.Nombre);
            }
        }
        private static void GetAllJugadores() //GetAll por implementar
        {
            foreach (var jugador in _repoJugador.GetAllJugadores())
            {
                Console.WriteLine(jugador.Id + " " + jugador.Nombre);
            }
        }*/
    }
}
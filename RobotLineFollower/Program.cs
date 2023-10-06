using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace RobotLineFollower
{
    class Program
    {
        static void Main(string[] args)
        {
            Robot robot = new Robot();

            // Simulación: Ambos sensores sobre la línea
            robot.SensorLeft.IsOnBlack = true;
            robot.SensorRight.IsOnBlack = true;
            robot.EvaluateSensors();

            // Simulación: Sensor izquierdo sobre la línea y derecho no
            robot.SensorLeft.IsOnBlack = true;
            robot.SensorRight.IsOnBlack = false;
            robot.EvaluateSensors();

            // Búsqueda en "mision.bin"
            Console.WriteLine("Ingrese la fecha de inicio (formato: dd/MM/yyyy):");
            DateTime fechaDesde;
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, DateTimeStyles.None, out fechaDesde))
            {
                Console.WriteLine("Formato incorrecto. Intente nuevamente.");
            }

            Console.WriteLine("Ingrese la fecha de finalización (formato: dd/MM/yyyy):");
            DateTime fechaHasta;
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, DateTimeStyles.None, out fechaHasta))
            {
                Console.WriteLine("Formato incorrecto. Intente nuevamente.");
            }

            MostrarRegistros(fechaDesde, fechaHasta);

            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }

        private static void MostrarRegistros(DateTime fechaDesde, DateTime fechaHasta)
        {
            List<Registro> registros = DeserializarRegistros(fechaDesde, fechaHasta);

            Console.WriteLine($"Registros desde {fechaDesde} hasta {fechaHasta}:");
            foreach (var registro in registros)
            {
                Console.WriteLine($"Fecha/Hora: {registro.FechaHora}, Sensor 1: {registro.ValorSensor1}, Sensor 2: {registro.ValorSensor2}");
            }
        }

        private static List<Registro> DeserializarRegistros(DateTime fechaDesde, DateTime fechaHasta)
        {
            List<Registro> registros = new List<Registro>();

            // Verificar si el archivo existe
            if (!File.Exists("mision.bin"))
            {
                Console.WriteLine("El archivo mision.bin no existe.");
                return registros;
            }

            using (FileStream fs = new FileStream("mision.bin", FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                while (fs.Position < fs.Length)
                {
                    Registro registro = (Registro)formatter.Deserialize(fs);
                    if (registro.FechaHora.Date >= fechaDesde.Date && registro.FechaHora.Date <= fechaHasta.Date)
                    {
                        registros.Add(registro);
                    }
                }
            }
            return registros;
        }
    }
}

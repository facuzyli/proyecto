using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotLineFollower
{
    [Serializable]
    public class Registro
    {
        public DateTime FechaHora { get; set; }
        public bool ValorSensor1 { get; set; }
        public bool ValorSensor2 { get; set; }

        public Registro(bool valorSensor1, bool valorSensor2)
        {
            FechaHora = DateTime.Now;
            ValorSensor1 = valorSensor1;
            ValorSensor2 = valorSensor2;
        }
    }
}

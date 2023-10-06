using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotLineFollower
{
    /// <summary>
    /// Representa un sensor infrarrojo del robot.
    /// </summary>
    public class Sensor
    {
        /// <summary>
        /// Indica si el sensor está sobre una línea negra.
        /// True si está sobre la línea, False en caso contrario.
        /// </summary>
        public bool IsOnBlack { get; set; }
    }
}

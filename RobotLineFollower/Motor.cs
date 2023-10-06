using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotLineFollower
{
    
    /// <summary>
    /// Representa un motor del robot.
    /// </summary>
    public class Motor
    {
        /// <summary>
        /// Mueve el motor hacia adelante.
        /// </summary>
        public void MoveForward()
        {
            Console.WriteLine("El motor está moviéndose hacia adelante.");
        }

        /// <summary>
        /// Gira el motor hacia la izquierda.
        /// </summary>
        public void TurnLeft()
        {
            Console.WriteLine("El motor está girando hacia la izquierda.");
        }

        /// <summary>
        /// Gira el motor hacia la derecha.
        /// </summary>
        public void TurnRight()
        {
            Console.WriteLine("El motor está girando hacia la derecha.");
        }

        /// <summary>
        /// Mueve el motor hacia atrás.
        /// </summary>
        public void MoveBackward()
        {
            Console.WriteLine("El motor está moviéndose hacia atrás.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotLineFollower
{
    /// <summary>
    /// Define una interfaz para el comportamiento asociado con un estado del robot.
    /// </summary>
    public interface Estado
    {
        void Handle(Robot robot);
    }

    public class Avanzar : Estado
    {
        public void Handle(Robot robot)
        {
            robot.MotorLeft.MoveForward();
            robot.MotorRight.MoveForward();
        }
    }

    public class GirarIzquierda : Estado
    {
        public void Handle(Robot robot)
        {
            robot.MotorLeft.TurnLeft();
        }
    }

    public class GirarDerecha : Estado
    {
        public void Handle(Robot robot)
        {
            robot.MotorRight.TurnRight();
        }
    }

    public class RetrocederEmitirSonido : Estado
    {
        public void Handle(Robot robot)
        {
            robot.MotorLeft.MoveBackward();
            robot.MotorRight.MoveBackward();
            robot.Parlante.EmitSound();
        }
    }


}

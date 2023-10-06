using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace RobotLineFollower
{
    /// <summary>
    /// Representa el robot Line Follower.
    /// </summary>
    public class Robot
    {
        public Sensor SensorLeft { get; set; }
        public Sensor SensorRight { get; set; }
        public Motor MotorLeft { get; set; }
        public Motor MotorRight { get; set; }
        public Parlante Parlante { get; set; }
        public Estado CurrentState { get; set; }

        public Robot()
        {
            SensorLeft = new Sensor();
            SensorRight = new Sensor();
            MotorLeft = new Motor();
            MotorRight = new Motor();
            Parlante = new Parlante();
            CurrentState = new Avanzar(); // Estado inicial
        }

        public void EvaluateSensors()
        {
            Estado previousState = CurrentState;

            if (SensorLeft.IsOnBlack && SensorRight.IsOnBlack)
                CurrentState = new Avanzar();
            else if (SensorLeft.IsOnBlack && !SensorRight.IsOnBlack)
                CurrentState = new GirarIzquierda();
            else if (!SensorLeft.IsOnBlack && SensorRight.IsOnBlack)
                CurrentState = new GirarDerecha();
            else
                CurrentState = new RetrocederEmitirSonido();

            if (previousState != CurrentState)
            {
                CurrentState.Handle(this);
                SerializarRegistro();
            }
        }

        private void SerializarRegistro()
        {
            Registro registro = new Registro(SensorLeft.IsOnBlack, SensorRight.IsOnBlack);
            using (FileStream fs = new FileStream("mision.bin", FileMode.Append))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, registro);
            }
        }
    }
}

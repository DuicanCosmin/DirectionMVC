using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class Car : INotifyPropertyChanged
    {
        public Car()
        {
            Speedometer = new Speedometer(this);
        }

        public Speedometer Speedometer { get; set; }

        public Wheel LeftWheel { get; set; } = new();

        public Wheel RightWheel { get; set; } = new();

        public SteeringWheel SteeringWheel { get; set; } = new();


        private double MaxSpeed { get; set; } = 100;

        private double MinSpeed { get; set; } = 0;

        private double Acceleration { get; set; } = 1;



        private double _speed = 100;

        public double Speed
        {
            get { return _speed; }
            set
            {
                if (_speed != value)
                {
                    if (value <= MaxSpeed && value >= MinSpeed)
                    {
                        

                        _speed = value;
                        RaisePropertyChanged(nameof(Speed));
                        Speedometer.Update();
                    }

                }
            }
        }


        public void Turn(int input)
        {



            SteeringWheel.Turn(input);

            LeftWheel.Turn(SteeringWheel.SteeringAngle);
            RightWheel.Turn(SteeringWheel.SteeringAngle);

        }

        public void Recover()
        {

            RightWheel.Recover(Speed);
            LeftWheel.Recover(Speed);

            if (RightWheel.Angle != LeftWheel.Angle)
            {
                RightWheel.Angle = LeftWheel.Angle;
            }

            SteeringWheel.Recover(RightWheel.Angle);
        }





        public void ChangeSpeed(int SpeedIncrease)
        {
            Speed += SpeedIncrease * Acceleration;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}

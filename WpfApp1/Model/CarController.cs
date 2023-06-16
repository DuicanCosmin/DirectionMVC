using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfApp1.Model
{
    public class CarController:INotifyPropertyChanged
    {
        public Wheel LeftWheel { get; set; } = new();

        public Wheel RightWheel { get; set; } = new();

        public SteeringWheel SteeringWheel { get; set; } = new();


        private double MaxSpeed { get; set; } = 100;

        private double MinSpeed { get; set; } = 0;

        private double Acceleration { get; set; } = 1;



        private double _speed=100;

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
                        RaisePropertyChanged(nameof(SpeedometerScale));
                        RaisePropertyChanged(nameof(SpeedometerColor));
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

            if (RightWheel.Angle!=LeftWheel.Angle) 
            {
                RightWheel.Angle = LeftWheel.Angle;
            }

            SteeringWheel.Recover(RightWheel.Angle);
        }



        public double RecoveryFactor()
        {
            return 0;
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




        public double SpeedometerScale 
        { get 
            {
              
                
                return Math.Max(0.01,(Speed / 100));

            } 
        }



        public Brush SpeedometerColor
        { get
            {
                byte RValue = (byte)Math.Min(Math.Max(139 + (-1.05 * Speed ), 0), 255);
                byte GValue = (byte)Math.Min(Math.Max(0 + (1.39 * Speed), 0), 255);
                byte BValue = (byte)Math.Min(Math.Max(0 + (0.34 * Speed), 0), 255);

                return new SolidColorBrush(Color.FromRgb(RValue, GValue, BValue));
            } 
        }
    }
}

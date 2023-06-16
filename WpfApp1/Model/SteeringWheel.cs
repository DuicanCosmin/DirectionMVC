using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class SteeringWheel:INotifyPropertyChanged
    {
		private double _steeringAngle=0;

		public double SteeringAngle
		{
			get { return _steeringAngle; }
			set
            {
                if (_steeringAngle != value)
                {
                    if (value >= MinSteeringAngle && value <= MaxSteeringAngle)
                    {
                        _steeringAngle = value;
                        RaisePropertyChanged(nameof(SteeringAngle));
                    }

                }
            }


		}

        public void Turn(int Value)
        {
            SteeringAngle += Value*14; // 14 is the tick angle value. calculated at 1 and a half revolutions in 2 seconds.


        }

        public void Recover(double WheelAngle)
        {

            SteeringAngle = WheelAngle * 12;
        }



        private int MaxSteeringAngle = 540;

        private int MinSteeringAngle = -540;

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

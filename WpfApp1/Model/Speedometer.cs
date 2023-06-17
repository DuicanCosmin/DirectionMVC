using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfApp1.Model
{
    public class Speedometer: INotifyPropertyChanged
    {

        private Car _car;

        public Speedometer( Car ParentCar)
        {
            _car = ParentCar;
            Update();
        }


        private double  _speedometerScale;

        public double SpeedometerScale
        {
            get { return _speedometerScale; }
            set 
            {
                _speedometerScale = value;
                RaisePropertyChanged(nameof(SpeedometerScale));
            }
        }



        private Brush _speedometerColor;

        public Brush SpeedometerColor
        {
            get { return _speedometerColor; }
            set 
            {   _speedometerColor = value;
                RaisePropertyChanged(nameof(SpeedometerColor));
            }
        }

        public void Update()
        {
            SpeedometerScale= Math.Max(0.01, (_car.Speed / 100));

            byte RValue = (byte)Math.Min(Math.Max(139 + (-1.05 * _car.Speed), 0), 255);
            byte GValue = (byte)Math.Min(Math.Max(0 + (1.39 * _car.Speed), 0), 255);
            byte BValue = (byte)Math.Min(Math.Max(0 + (0.34 * _car.Speed), 0), 255);

            SpeedometerColor = new SolidColorBrush(Color.FromRgb(RValue, GValue, BValue));
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

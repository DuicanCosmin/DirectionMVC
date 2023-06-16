using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class Wheel:INotifyPropertyChanged
    {
        private double _angle =0;

        private int MaxAngle = 45;

        private int MinAngle = -45;

        public double Angle
        {
            get { return _angle; }
            set
            {   
                if (value >= MaxAngle)
                {
                    var a = 2;
                }


                if (_angle != value)
                {   
                    if (value >= MinAngle && value <= MaxAngle)
                    {
                        _angle = value;
                        RaisePropertyChanged(nameof(Angle));
                    }
                    else if (value < MinAngle)
                    {
                        _angle = MinAngle;
                        RaisePropertyChanged(nameof(Angle));
                    }
                    else
                    {
                        _angle=MaxAngle; 
                        RaisePropertyChanged(nameof(Angle));
                    }

                }
            }
        }

        public void Turn(double InputAngle)
        {   
       

            Angle = InputAngle / 12;


        }

        public void Recover (double Speed)
        {
            double AngleIncrement = 0;

            

            if (Angle!=0)
            {
                AngleIncrement = 0.005625 * double.Abs( Speed);

                if (Angle<0 ) 
                {
                   

                    if (Angle + AngleIncrement > 0)
                    {
                        Angle = 0;
                    }
                    else
                    {
                        Angle += AngleIncrement;
                    }
                }
                else
                {

                    if (Angle - AngleIncrement < 0)
                    {
                        Angle = 0;
                    }
                    else
                    {
                        Angle -= AngleIncrement;
                    }
                }
            }
            
            

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

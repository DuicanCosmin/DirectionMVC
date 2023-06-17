using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using WpfApp1.Model;

namespace WpfApp1.Controllers
{
    public class CarController : INotifyPropertyChanged
    {

        public Car Car { get; set; } = new Car();



        public event PropertyChangedEventHandler PropertyChanged;

        internal void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }





        private DispatcherTimer timer = new DispatcherTimer();



        public void Start()
        {
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += Update;
            timer.Start();
        }



        public async void Update(object sender, EventArgs e)
        {

            if (Keyboard.IsKeyDown(Key.A) || Keyboard.IsKeyDown(Key.Left))
            {
                Car.Turn(-1);
            }
            else if (Keyboard.IsKeyDown(Key.D) || Keyboard.IsKeyDown(Key.Right))
            {
                Car.Turn(1);
            }
            else
            {
                Car.Recover();
            }

            if (Keyboard.IsKeyDown(Key.W) || Keyboard.IsKeyDown(Key.Up))
            {
                Car.ChangeSpeed(1);
            }
            if (Keyboard.IsKeyDown(Key.S) || Keyboard.IsKeyDown(Key.Down))
            {
                Car.ChangeSpeed(-1);
            }

        }
    }
}

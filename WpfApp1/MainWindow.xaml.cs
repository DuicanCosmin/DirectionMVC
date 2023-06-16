using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfApp1.Model;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   
        private CarController ContextCar=new();

        public MainWindow()
        {
            InitializeComponent();

            Start();



            this.DataContext = ContextCar;
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
                ContextCar.Turn(-1);
            }
            else if (Keyboard.IsKeyDown(Key.D) || Keyboard.IsKeyDown(Key.Right))
            {
                ContextCar.Turn(1);
            }
            else
            {
                ContextCar.Recover();
            }
            
            if (Keyboard.IsKeyDown(Key.W) || Keyboard.IsKeyDown(Key.Up))
            {
                ContextCar.ChangeSpeed(1);
            }
            if (Keyboard.IsKeyDown(Key.S) || Keyboard.IsKeyDown(Key.Down))
            {
                ContextCar.ChangeSpeed(-1);
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureChangeEvent
{
    public class TemperatureChangeEventArgs : EventArgs
    {
        public double OldTemperature { get; }
        public double NewTemperature { get; }
        public double Difference { get; }
        public TemperatureChangeEventArgs(double OldTemperature, double NewTemperature) 
        {
            this.OldTemperature = OldTemperature;
            this.NewTemperature = NewTemperature;
            this.Difference = NewTemperature - OldTemperature;
        }
    }

    public class Thermostat
    {
        public event EventHandler<TemperatureChangeEventArgs> TemperatureChanged;

        private double CurrentTemperature;
        private double OldTemperature;

        public void SetTemperature(double NewTemperature)
        {
            if (NewTemperature != CurrentTemperature)
            {
                OldTemperature = CurrentTemperature;
                CurrentTemperature = NewTemperature;

                OnTemperatureChanged(OldTemperature, NewTemperature);
            }
        }

        private void OnTemperatureChanged(double OldTemperature, double NewTemperature)
        {
            OnTemperatureChanged(new TemperatureChangeEventArgs(OldTemperature, NewTemperature));
        }

        protected virtual void OnTemperatureChanged(TemperatureChangeEventArgs e)
        {
            TemperatureChanged?.Invoke(this, e);
        }
    }

    public class Display
    {
        public void Subscribe(Thermostat Thermostat)
        {
            Thermostat.TemperatureChanged += HandleTemperatureChanged;
        }

        private void HandleTemperatureChanged(object sender, TemperatureChangeEventArgs e)
        {
            Console.WriteLine("Temperature Changed");
            Console.WriteLine($"Temperature Changed From {e.OldTemperature}C");
            Console.WriteLine($"To {e.NewTemperature}C");
            Console.WriteLine($"Difference {e.Difference}C");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Thermostat Thermostat1 = new Thermostat();
            Display Display1 = new Display();
            Display1.Subscribe(Thermostat1);

            Thermostat1.SetTemperature(10);
            Console.WriteLine();
            Thermostat1.SetTemperature(15);

        }
    }
}

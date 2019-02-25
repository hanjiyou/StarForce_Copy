using System;

namespace Test
{
    public class Thermostat
    {
        private float _currentTemperature;
        private Action<float> temperatureChanged;
        public event Action<float> OnTemperatureChange
        {
            add { temperatureChanged += value; }
            remove { this.temperatureChanged -= value; }
        }

        public float CurrentTemperature {
            get { return _currentTemperature; }
            set
            {
                if (value != this._currentTemperature)
                {
                    this._currentTemperature = value;
                    temperatureChanged(_currentTemperature);
                }   
            }
        }
    }
}
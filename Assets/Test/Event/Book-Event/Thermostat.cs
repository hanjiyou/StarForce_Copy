using System;

namespace Test
{
    public class Thermostat
    {
        private float _currentTemperature;
        public Action<float> OnTemperatureChange { get; set; }
        public float CurrentTemperature {
            get { return _currentTemperature; }
            set
            {
                if (value != this._currentTemperature)
                {
                    this._currentTemperature = value;
                    OnTemperatureChange/*?*/.Invoke(1);
                }   
            }
        }
    }
}
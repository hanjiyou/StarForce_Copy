using UnityEngine;

namespace Test
{
    public class Execute:MonoBehaviour
    {
        private void Start()
        {
            Thermostat thermostat=new Thermostat();
            Cooler cooler=new Cooler(10);
            Heater heater=new Heater(90);
            thermostat.OnTemperatureChange += cooler.OnTemperatureChanged;
            thermostat.OnTemperatureChange += heater.OnTemperatureChanged;

            thermostat.CurrentTemperature = 50;
            Debug.Log("HHHHHHHHHHHHHHHHHHHHHHH");
            thermostat.OnTemperatureChange -= cooler.OnTemperatureChanged;
           // thermostat.OnTemperatureChange -= heater.OnTemperatureChanged;
            thermostat.CurrentTemperature = 20;

        }
    }
}
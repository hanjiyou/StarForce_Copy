using UnityEngine;

namespace Test
{
    public class Heater
    {
        public float Temperature { get; set; }
        public Heater(float tem)
        {
            this.Temperature = tem;
        }

        public void OnTemperatureChanged(float newTem)
        {
            if (newTem < Temperature)
            {
                Debug.Log("HHH heaterjiang问");
            }
            else
            {
                Debug.Log("HHH coller升温");
                
            }
        }
    }
}
using UnityEngine;

namespace Test
{
    public class Cooler
    {
        public float Temperature { get; set; }
        public Cooler(float tem)
        {
            this.Temperature = tem;
        }

        public void OnTemperatureChanged(float newTem)
        {
            if (newTem > Temperature)
            {
                Debug.Log("HHH coller升温");
            }
            else
            {
                Debug.Log("HHH collerjiang温");
                
            }
        }
    }
}